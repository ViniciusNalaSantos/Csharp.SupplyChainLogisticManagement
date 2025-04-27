using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Messages;
public record OrderCreatedMessage
{
    public Guid MessageId { get; init; } = Guid.NewGuid();
    public DateTime EmissionDate { get; set; }
    public int? CustomerId { get; set; }
    public CustomerCreatedMessage? Customer { get; set; }
    public int? SupplierId { get; set; }
    public SupplierCreatedMessage? Supplier { get; set; }
    public decimal Price { get; set; }
    public ICollection<OrderItemCreatedMessage> OrderItems { get; set; } = new List<OrderItemCreatedMessage>();
    public DeliveryCreatedMessage? Delivery { get; set; }
    public ShipmentCreatedMessage? Shipment { get; set; }
}
