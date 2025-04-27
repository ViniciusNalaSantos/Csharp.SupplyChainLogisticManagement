using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Messages;
public record ShipmentCreatedMessage
{
    public Guid MessageId { get; init; } = Guid.NewGuid();
    public DateTime ShipmentDate { get; init; }
}
