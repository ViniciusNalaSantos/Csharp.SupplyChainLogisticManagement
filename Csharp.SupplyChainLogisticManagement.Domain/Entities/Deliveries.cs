using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Domain.Entities;
public class Deliveries
{
    public int Id { get; set; }
    public int OrdersId { get; set; }
    public Orders Orders { get; set; }
    public int TransportersId { get; set; }
    public Transporters Transporters { get; set; }
    public DateTime DeliveryDate { get; set; }
}
