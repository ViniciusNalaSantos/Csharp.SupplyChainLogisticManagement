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
    public async Task<Orders> ReturnOrderMappedFromMessage(OrderCreatedMessage message)
    {
        var order = new Orders
        {
            EmissionDate = message.EmissionDate,
            Price = Math.Round(message.Price, 2),
            CustomersId = message.CustomerId,
            SuppliersId = message.SupplierId
        };
        return order;
    }
}
