using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Interfaces.Handlers;
public interface IMessageHandler<TMessage>
{
    Task Handle(TMessage message);
}
