using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Infrastructure.EventBus;
using Microsoft.AspNetCore.Mvc;
using Xunit.Sdk;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Handlers;
using Csharp.SupplyChainLogisticManagement.Application.Queries;
using Csharp.SupplyChainLogisticManagement.Application.DTOs;
using Csharp.SupplyChainLogisticManagement.Application.Common.Constants;
using System.Drawing.Printing;
using System.Threading.Tasks;
using Csharp.SupplyChainLogisticManagement.Domain.Dto;

namespace Csharp.SupplyChainLogisticManagement.WebApi.Controllers;

[ApiController]
[Route("/logichain")]
public class LogiChainController : ControllerBase
{
    private readonly IEventBus _eventBus;
    private readonly IQueryHandler<GetOrderByIdQuery, List<Orders>> _getOrderByIdQueryHandler;
    private readonly IQueryHandler<GetOrdersByEmissionDateQuery, PagedResultDto<Orders>> _getOrdersByEmissionDateQueryHandler;

    public LogiChainController(IEventBus eventBus, IQueryHandler<GetOrderByIdQuery, List<Orders>> getOrderByIdQueryHandler, IQueryHandler<GetOrdersByEmissionDateQuery, PagedResultDto<Orders>> getOrdersByEmissionDateQueryHandler)
    {
        _eventBus = eventBus;
        _getOrderByIdQueryHandler = getOrderByIdQueryHandler;
        _getOrdersByEmissionDateQueryHandler = getOrdersByEmissionDateQueryHandler;        
    }

    [HttpGet("orders/{id}")]
    public async Task<PagedOrdersReturnDto<Orders>> GetOrderByIdAsync(int id) 
    {
        var query = new GetOrderByIdQuery { Id = id };
        var listOrders = await _getOrderByIdQueryHandler.Handle(query);
               
        return new PagedOrdersReturnDto<Orders>
        {
            ActualPage = 1,
            TotalPages = 1,
            PageLimit = PagedResult.PageSizeLimit,
            OrdersList = listOrders
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
            OrdersList = pagedOrdersDto.ListResults            
        };
    }

    [HttpPost("orders")]
    public async Task<IActionResult> PostOrders([FromBody] List<OrderCreatedMessage> listOrderCreatedMessage)
    {
        foreach (var orderCreatedMessage in listOrderCreatedMessage)
        {            
            await _eventBus.PublishAsync(orderCreatedMessage);
        }
        return Ok();        
    }
}
