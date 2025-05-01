using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.CommandHandlers;
public interface IMessageHandler<TMessage>
{
    void Handle(TMessage message);
}
