using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Messages;
public record OrderSubmittedMessage
{
    public Guid OrderId { get; init; }
    public DateTime OrderDate { get; init; }
}
