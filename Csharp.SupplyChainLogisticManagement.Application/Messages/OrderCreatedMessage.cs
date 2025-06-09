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
    public string OrderNumber { get; init; }
    public DateTime EmissionDate { get; init; }
    public int? CustomerId { get; init; }
    public CustomerCreatedMessage? Customer { get; init; }
    public int? SupplierId { get; init; }
    public SupplierCreatedMessage? Supplier { get; init; }
    public decimal Price { get; init; }
    public ICollection<OrderItemsCreatedMessage> OrderItems { get; init; } = new List<OrderItemsCreatedMessage>();
    public DeliveryCreatedMessage? Delivery { get; init; }
    public ShipmentCreatedMessage? Shipment { get; init; }
}
