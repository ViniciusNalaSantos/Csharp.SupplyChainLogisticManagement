using Csharp.SupplyChainLogisticManagement.Application.Commands.CreateTransporter;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Commands.CreateDelivery;
public record CreateDeliveryCommand
{
    public Guid MessageId { get; set; }
    public int? TransporterId { get; set; }
    public DateTime DeliveryDate { get; set; }
    public CreateTransporterCommand? Transporter { get; set; }
}
