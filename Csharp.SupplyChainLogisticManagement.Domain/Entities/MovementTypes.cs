using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Domain.Entities;
public class MovementTypes
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<InventoryMovements> InventoryMovements { get; set; }
}
