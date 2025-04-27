using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Domain.Entities;
public class Orders
{
    public int Id { get; set; }
    public DateTime EmissionDate { get; set; }
    public int? CustomersId { get; set; }
    public Customers Customers { get; set; }
    public int? SuppliersId { get; set; }
    public Suppliers Suppliers { get; set; }
    public decimal Price { get; set; }
    public ICollection<OrdersItems> OrdersItems { get; set; }
    public ICollection<Shipments> Shipments { get; set; }
    public ICollection<Deliveries> Deliveries { get; set; }
}
