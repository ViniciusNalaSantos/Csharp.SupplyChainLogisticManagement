using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Domain.Entities;
public class Shipments
{
    public int Id { get; set; }
    public int OrdersId { get; set; }
    public Orders Orders { get; set; }
    public DateTime ShipmentDate { get; set; }
}
