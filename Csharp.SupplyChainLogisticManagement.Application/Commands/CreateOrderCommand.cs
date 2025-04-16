using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Commands;
public class CreateOrderCommand
{
    public int OrderItemsId { get; set; }
    public DateTime EmissionDate { get; set; }
    public int CustomerId { get; set; }
    public int SupplierId { get; set; }
    public decimal Price { get; set; }
}
