using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.MessageConsumer;
public interface IMessageConsumer<TMessage>
{
    Task ConsumeAsync(TMessage message, CancellationToken cancellationToken = default);
}
