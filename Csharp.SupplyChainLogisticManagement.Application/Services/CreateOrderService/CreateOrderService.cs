using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Services.CreateOrderService;
public class CreateOrderService : ICreateOrderService
{
    public CreateOrderService() { }

    public Orders ReturnOrderMappedFromMessage(OrderCreatedMessage message)
    {
        throw new NotImplementedException();
    }
}
