using Csharp.SupplyChainLogisticManagement.Application.CommandHandlers;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Commands.CreateOrder;
public class CreateOrderMessageHandler : IMessageHandler<OrderCreatedMessage>
{
    public void Handle(OrderCreatedMessage message)
    {
        throw new NotImplementedException();
    }
}
