using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Csharp.SupplyChainLogisticManagement.WebApi.Controllers;

[ApiController]
[Route("/logichain")]
public class LogiChainController : ControllerBase
{
    [HttpGet]
    public Orders GetOrders() {  return new Orders(); }
}
