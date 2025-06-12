using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Domain.Entities;
public class Products
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public ICollection<OrdersItems> OrdersItems { get; set; }
    public ICollection<ProductsInventory> ProductsInventory { get; set; }
}
