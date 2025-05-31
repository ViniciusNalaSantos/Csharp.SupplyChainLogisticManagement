using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Messages;
public record DeliveryCreatedMessage
{
    public Guid MessageId { get; init; } = Guid.NewGuid();
    public int? TransporterId { get; init; }
    public DateTime DeliveryDate { get; init; }
    public TransporterCreatedMessage? Transporter { get; init; }
}
