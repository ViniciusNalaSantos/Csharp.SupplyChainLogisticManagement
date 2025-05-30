using Csharp.SupplyChainLogisticManagement.Application.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.ValidationServices.OrdersItemsValidationServices;
public interface IOrdersItemsValidationService
{
    public Task ValidateOrderItemCreatedMessageAsync(ICollection<OrderItemCreatedMessage> messageList);
}
