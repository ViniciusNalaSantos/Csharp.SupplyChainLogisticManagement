using Csharp.SupplyChainLogisticManagement.Application.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.ValidationServices.OrdersItemsValidationServices;
public class OrdersItemsValidationService : IOrdersItemsValidationService
{
    public async Task ValidateOrderItemCreatedMessageAsync(OrderItemCreatedMessage message)
    {
        if (message.Quantity < 1 )
        {
            throw new Exception("An OrderItem must have at least quantity 1.");
        }
    }
}
