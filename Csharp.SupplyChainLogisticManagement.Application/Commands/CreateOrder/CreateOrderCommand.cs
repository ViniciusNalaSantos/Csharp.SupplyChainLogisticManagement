using Csharp.SupplyChainLogisticManagement.Application.Commands.CreateCustomer;
using Csharp.SupplyChainLogisticManagement.Application.Commands.CreateSupplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Commands.CreateOrder;
public record CreateOrderCommand
{
    public Guid MessageId { get; init; }
    public DateTime EmissionDate { get; set; }
    public int? CustomerId { get; set; }
    public CreateCustomerCommand Customer { get; set; }
    public int? SupplierId { get; set; }
    public CreateSupplierCommand Supplier { get; set; }
    public decimal Price { get; set; }
    //public ICollection<OrderItemCreatedMessage> OrderItems { get; set; } = new List<OrderItemCreatedMessage>();
    //public DeliveryCreatedMessage Delivery { get; set; }
    //public ShipmentCreatedMessage Shipment { get; set; }
}
