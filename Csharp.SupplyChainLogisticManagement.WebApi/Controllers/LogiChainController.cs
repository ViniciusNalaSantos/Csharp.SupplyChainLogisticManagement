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

namespace Csharp.SupplyChainLogisticManagement.WebApi.Controllers;

[ApiController]
[Route("/logichain")]
public class LogiChainController : ControllerBase
{
    private readonly IEventBus _eventBus;
    private readonly IQueryHandler<GetOrderByIdQuery, List<Orders>> _getOrderByIdQueryHandler;
    private readonly IQueryHandler<GetOrdersByEmissionDateQuery, List<Orders>> _getOrdersByEmissionDateQueryHandler;

    public LogiChainController(IEventBus eventBus, IQueryHandler<GetOrderByIdQuery, List<Orders>> getOrderByIdQueryHandler, IQueryHandler<GetOrdersByEmissionDateQuery, List<Orders>> getOrdersByEmissionDateQueryHandler)
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

        var pageSizeLimit = PagedResult.PageSizeLimit;
        var totalPages = (int)Math.Ceiling((double)listOrders.Count / pageSizeLimit);
        return new PagedOrdersReturnDto<Orders>
        {
            ActualPage = 1,
            TotalPages = totalPages,
            PageLimit = pageSizeLimit,
            OrdersList = listOrders
        };
    }
    
    [HttpGet("orders")]
    public async Task<PagedOrdersReturnDto<Orders>> GetOrdersByEmissionDate([FromQuery] DateTime EmissionDateStart, DateTime EmissionDateEnd)
    {
        var query = new GetOrdersByEmissionDateQuery
        {
            EmissionDateStart = EmissionDateStart,
            EmissionDateEnd = EmissionDateEnd
        };
        var listOrders = await _getOrdersByEmissionDateQueryHandler.Handle(query);
        var pageSizeLimit = PagedResult.PageSizeLimit;
        var totalPages = (int)Math.Ceiling((double)listOrders.Count / pageSizeLimit);
        return new PagedOrdersReturnDto<Orders>
        {
            ActualPage = 1,
            TotalPages = totalPages,
            PageLimit = pageSizeLimit,
            OrdersList = listOrders
        };
    }

    [HttpPost("orders")]
    public async Task<IActionResult> PostOrdersAsync([FromBody] List<OrderCreatedMessage> listOrderCreatedMessage)
    {
        foreach (var orderCreatedMessage in listOrderCreatedMessage)
        {            
            await _eventBus.PublishAsync(orderCreatedMessage);
        }
        return Ok();        
    }
}
