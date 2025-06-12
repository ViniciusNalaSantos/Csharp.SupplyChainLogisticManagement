using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Domain.Entities;
public class Warehouses
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<ProductsInventory> ProductsInventory { get; set; }
}
