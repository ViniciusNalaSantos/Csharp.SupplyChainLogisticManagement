using Csharp.SupplyChainLogisticManagement.Application.Common.Constants;
using Csharp.SupplyChainLogisticManagement.Application.DTOs.InputDTOs;
using Csharp.SupplyChainLogisticManagement.Application.DTOs.ReturnDTOs;
using Csharp.SupplyChainLogisticManagement.Application.Exceptions;
using Csharp.SupplyChainLogisticManagement.Infrastructure.EventBus;
using Csharp.SupplyChainLogisticManagement.Application.Interfaces.Handlers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.OrdersMappers;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Application.Queries;
using Csharp.SupplyChainLogisticManagement.Application.ValidationServices;
using Csharp.SupplyChainLogisticManagement.Application.ValidationServices.OrdersValidationServices;
using Csharp.SupplyChainLogisticManagement.Domain.Dto;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Csharp.SupplyChainLogisticManagement.WebApi.Controllers;

[ApiController]
[Route("/logichain")]
public class LogiChainController : ControllerBase
{
    private readonly IEventBus _eventBus;
    private readonly IQueryHandler<GetOrderByIdQuery, ICollection<Orders>> _getOrderByIdQueryHandler;
    private readonly IQueryHandler<GetOrdersByEmissionDateQuery, PagedResultDto<Orders>> _getOrdersByEmissionDateQueryHandler;
    private readonly IOrdersValidationService _ordersValidationService;
    private readonly IOrdersMapper _ordersMapper;
    private readonly IValidationErrorCollector _validationErrorCollector;

    public LogiChainController(IEventBus eventBus, IQueryHandler<GetOrderByIdQuery, ICollection<Orders>> getOrderByIdQueryHandler, 
        IQueryHandler<GetOrdersByEmissionDateQuery, PagedResultDto<Orders>> getOrdersByEmissionDateQueryHandler, IOrdersValidationService ordersValidationService,
        IOrdersMapper ordersMapper, IValidationErrorCollector validationErrorCollector)
    {
        _eventBus = eventBus;
        _getOrderByIdQueryHandler = getOrderByIdQueryHandler;
        _getOrdersByEmissionDateQueryHandler = getOrdersByEmissionDateQueryHandler;
        _ordersValidationService = ordersValidationService;
        _ordersMapper = ordersMapper;
        _validationErrorCollector = validationErrorCollector;
    }

    [HttpGet("orders/{id}")]
    public async Task<PagedOrdersReturnDto<Orders>> GetOrderByIdAsync(int id) 
    {
        var query = new GetOrderByIdQuery { Id = id };
        var listOrders = await _getOrderByIdQueryHandler.Handle(query);
        var ordersMapped = await _ordersMapper.MapEntityToRetunDtoAsync(listOrders);

        return new PagedOrdersReturnDto<Orders>
        {
            ActualPage = 1,
            TotalPages = 1,
            PageLimit = PagedResult.PageSizeLimit,
            OrdersListCount = listOrders.Count,
            OrdersList = ordersMapped
        };
    }
    
    [HttpGet("orders")]
    public async Task<PagedOrdersReturnDto<Orders>> GetOrdersByEmissionDate([FromQuery] DateTime emissionDateStart, DateTime emissionDateEnd, int page)
    {
        var query = new GetOrdersByEmissionDateQuery
        {
            EmissionDateStart = emissionDateStart,
            EmissionDateEnd = emissionDateEnd,
            Page = page
        };
        var pagedOrdersDto = await _getOrdersByEmissionDateQueryHandler.Handle(query);
        
        return new PagedOrdersReturnDto<Orders>
        {
            ActualPage = page,
            TotalPages = pagedOrdersDto.TotalPages,
            PageLimit = PagedResult.PageSizeLimit,
            OrdersListCount = pagedOrdersDto.ListResultsCount,
            OrdersList = await _ordersMapper.MapEntityToRetunDtoAsync(pagedOrdersDto.ListResults)
        };
    }

    [HttpPost("orders")]
    public async Task<IActionResult> PostOrders([FromBody] List<InputOrderDto> listInputOrder)
    {
        var listOrderCreatedMessage = await _ordersMapper.MapInputToCreatedMessageAsync(listInputOrder);
        foreach (var orderCreatedMessage in listOrderCreatedMessage)
        {            
            await _ordersValidationService.ValidateOrderCreatedMessageAsync(orderCreatedMessage);                        
        }
        if (_validationErrorCollector.GetErrors().Any())
        {
            throw new ValidationServiceException(_validationErrorCollector.GetErrors());
        }
        foreach (var orderCreatedMessage in listOrderCreatedMessage)
        {
            await _eventBus.PublishAsync(orderCreatedMessage);
        }        
        return Ok();        
    }
}
