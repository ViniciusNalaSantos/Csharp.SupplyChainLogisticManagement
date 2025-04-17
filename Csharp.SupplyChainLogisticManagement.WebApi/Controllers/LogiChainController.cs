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

    [HttpGet]
    public Orders GetOrders() {  return new Orders(); }

    [HttpPost]
    public IActionResult PostOrders()
    {
        var orderSubmittedMessage = new OrderSubmittedMessage()
        {
            OrderDate = DateTime.Now
        };
        _eventBus.PublishAsync(orderSubmittedMessage);
        return Ok();        
    }
}
