using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Messages;
public record DeliveryCreatedMessage
{
    public Guid MessageId { get; set; } = Guid.NewGuid();
    public int? TransporterId { get; set; }
    public DateTime DeliveryDate { get; set; }
    public TransporterCreatedMessage? Transporter { get; set; }   
}
