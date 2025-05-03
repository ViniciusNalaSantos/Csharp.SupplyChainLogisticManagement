using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Infrastructure.EventBus;
using Microsoft.AspNetCore.Mvc;
using Xunit.Sdk;
using Csharp.SupplyChainLogisticManagement.Application.Messages;

namespace Csharp.SupplyChainLogisticManagement.WebApi.Controllers;

[ApiController]
[Route("/logichain")]
public class LogiChainController : ControllerBase
{
    private readonly IEventBus _eventBus;

    public LogiChainController(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }

    [HttpGet("orders/{id}")]
    public Orders GetOrderById(int id) 
    {
        return new Orders(); 
    }
    
    [HttpGet("orders")]
    public Orders GetOrdersByEmissionDate([FromQuery] DateTime EmissionDateStart, DateTime EmissionDateEnd)
    {
        return new Orders();
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
