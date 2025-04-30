using Csharp.SupplyChainLogisticManagement.Application.Commands.CreateCustomer;
using Csharp.SupplyChainLogisticManagement.Application.Commands.CreateDelivery;
using Csharp.SupplyChainLogisticManagement.Application.Commands.CreateOrderItem;
using Csharp.SupplyChainLogisticManagement.Application.Commands.CreateShipment;
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
    public ICollection<CreateOrderItemCommand> OrderItems { get; set; } = new List<CreateOrderItemCommand>();
    public CreateDeliveryCommand Delivery { get; set; }
    public CreateShipmentCommand Shipment { get; set; }
}
