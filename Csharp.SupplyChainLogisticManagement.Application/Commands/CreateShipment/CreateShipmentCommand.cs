using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Commands.CreateShipment;
public record CreateShipmentCommand
{
    public Guid MessageId { get; init; }
    public DateTime ShipmentDate { get; init; }
}
