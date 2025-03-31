using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Domain.Entities;
public class OrdersItems
{
    public int OrdersId { get; set; }
    public Orders Orders { get; set; }
    public int ProductsId { get; set; }
    public Products Products { get; set; }
    public decimal Quantity { get; set; }
}
