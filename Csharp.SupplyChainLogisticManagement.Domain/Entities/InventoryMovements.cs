using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Domain.Entities;
public class InventoryMovements
{
    public int Id { get; set; }
    public int ProductsId { get; set; }
    public Products Products { get; set; }
    public int OriginWarehouseId { get; set; }
    public Warehouses OriginWarehouse { get; set; }    
    public int? DestinationWarehouseId { get; set; }
    public Warehouses? DestinationWarehouse { get; set; }
    public decimal QuantityMoved { get; set; }
    public int MovementTypesId { get; set; }
    public MovementTypes MovementTypes { get; set; }
    public DateTime MovementDate { get; set; }
}
