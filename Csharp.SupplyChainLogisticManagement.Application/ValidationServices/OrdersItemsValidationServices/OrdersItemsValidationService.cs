using Csharp.SupplyChainLogisticManagement.Application.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.ValidationServices.OrdersItemsValidationServices;
public class OrdersItemsValidationService : IOrdersItemsValidationService
{
    private readonly IValidationErrorCollector _validationErrorCollector;
    public OrdersItemsValidationService(IValidationErrorCollector validationErrorCollector)
    {
        _validationErrorCollector = validationErrorCollector;
    }
    public async Task ValidateOrderItemCreatedMessageAsync(ICollection<OrderItemsCreatedMessage> messageList)
    {
        if (messageList == null) { return; }

        foreach (var message in messageList)
        {
            if (message == null) { continue; }

            if (message.Quantity < 1)
            {
                _validationErrorCollector.Add("An OrderItem must have at least quantity 1.");
            }
        }
    }
}
