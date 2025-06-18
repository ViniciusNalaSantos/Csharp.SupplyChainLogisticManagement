using Csharp.SupplyChainLogisticManagement.Application.Common.Constants;
using Csharp.SupplyChainLogisticManagement.Application.DTOs.InputDTOs;
using Csharp.SupplyChainLogisticManagement.Application.DTOs.ReturnDTOs;
using Csharp.SupplyChainLogisticManagement.Application.Exceptions;
using Csharp.SupplyChainLogisticManagement.Application.Interfaces;
using Csharp.SupplyChainLogisticManagement.Application.Interfaces.Handlers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.OrdersMappers;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Application.Queries;
using Csharp.SupplyChainLogisticManagement.Application.ValidationServices;
using Csharp.SupplyChainLogisticManagement.Application.ValidationServices.OrdersValidationServices;
using Csharp.SupplyChainLogisticManagement.Domain.Dto;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Infrastructure.EventBus;
using Csharp.SupplyChainLogisticManagement.Infrastructure.TokenGenerators;
using Csharp.SupplyChainLogisticManagement.WebApi.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
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
    private readonly ITokenGenerator _tokenGenerator;

    public LogiChainController(IEventBus eventBus, IQueryHandler<GetOrderByIdQuery, ICollection<Orders>> getOrderByIdQueryHandler, 
        IQueryHandler<GetOrdersByEmissionDateQuery, PagedResultDto<Orders>> getOrdersByEmissionDateQueryHandler, IOrdersValidationService ordersValidationService,
        IOrdersMapper ordersMapper, IValidationErrorCollector validationErrorCollector, ITokenGenerator tokenGenerator)
    {
        _eventBus = eventBus;
        _getOrderByIdQueryHandler = getOrderByIdQueryHandler;
        _getOrdersByEmissionDateQueryHandler = getOrdersByEmissionDateQueryHandler;
        _ordersValidationService = ordersValidationService;
        _ordersMapper = ordersMapper;
        _validationErrorCollector = validationErrorCollector;
        _tokenGenerator = tokenGenerator;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginInput request)
    {        
        //if (request.Username == "admin" && request.Password == "123") // Replace with real auth logic
        //{
            var token = _tokenGenerator.GenerateToken(request.Username);
            return Ok(new { token });
        //}

        //return Unauthorized();
    }

    [Authorize]
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

    [Authorize]
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

    [Authorize]
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
