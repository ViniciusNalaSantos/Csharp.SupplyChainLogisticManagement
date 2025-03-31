using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Domain.Entities;
public class ProductsStock
{
    public int Id { get; set; }
    public int ProductsId { get; set; }
    public Products Products { get; set; }
    public int WarehousesId { get; set; }
    public Warehouses Warehouses { get; set; }
}
