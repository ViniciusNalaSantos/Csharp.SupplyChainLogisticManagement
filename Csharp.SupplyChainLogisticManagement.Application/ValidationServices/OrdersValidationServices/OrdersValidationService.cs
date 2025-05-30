using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Application.ValidationServices.CustomersValidationServices;
using Csharp.SupplyChainLogisticManagement.Application.ValidationServices.DeliveriesValidationServices;
using Csharp.SupplyChainLogisticManagement.Application.ValidationServices.OrdersItemsValidationServices;
using Csharp.SupplyChainLogisticManagement.Application.ValidationServices.ShipmentValidationServices;
using Csharp.SupplyChainLogisticManagement.Application.ValidationServices.SuppliersValidationServices;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.ValidationServices.OrdersValidationServices;
public class OrdersValidationService : IOrdersValidationService
{
    private readonly ICustomerValidationService _customerValidationService;
    private readonly ISuppliersValidationService _suppliersValidationService;
    private readonly IOrdersItemsValidationService _ordersItemsValidationService;
    private readonly IDeliveriesValidationService _deliveriesValidationService;
    private readonly IShipmentValidationService _shipmentValidationService;
    public OrdersValidationService(ICustomerValidationService customerValidationService, ISuppliersValidationService suppliersValidationService, IOrdersItemsValidationService ordersItemsValidationService,
        IDeliveriesValidationService deliveriesValidationService, IShipmentValidationService shipmentValidationService, IValidationErrorCollector validationErrorCollector)
    {
        _customerValidationService = customerValidationService;
        _suppliersValidationService = suppliersValidationService;
        _ordersItemsValidationService = ordersItemsValidationService;
        _deliveriesValidationService = deliveriesValidationService;
        _shipmentValidationService = shipmentValidationService;
    }
    public async Task ValidateOrderCreatedMessageAsync(OrderCreatedMessage message)
    {
        if (message.CustomerId != null && message.SupplierId != null)
        {
            throw new Exception("Cannot create an order filling CustomerId and SupplierId.");
        }
        
        if (message.CustomerId != null && message.Supplier != null)
        {
            throw new Exception("An order can only have a CustomerId or Supplier, not both at the same time.");
        }

        if (message.SupplierId != null && message.Customer != null)
        {
            throw new Exception("An order can only have a SupplierId or Customer, not both at the same time.");
        }

        if (message.CustomerId == null && message.Customer == null && message.SupplierId == null && message.Supplier == null)
        {
            throw new Exception("An order must have at least one of this fields filled: CustomerId, Customer, SupplierId, Supplier.");
        }

        if (message.Price < 0)
        {
            throw new Exception("An order cannot have a negative price");
        }

        if (message.Delivery != null && message.Shipment != null)
        {
            throw new Exception("An order can only have a Delivery or Shipment, not both at the same time.");
        }

        if (message.OrderItems.Count == 0)
        {
            throw new Exception("An order must have at least one OrderItem.");
        }

        if (message.Delivery != null)
        {
            if (message.Delivery.DeliveryDate < message.EmissionDate)
            {
                throw new Exception("The DeliveryDate cannot be before EmissionDate.");
            }
        }

        if (message.Shipment != null)
        {
            if (message.Shipment.ShipmentDate < message.EmissionDate)
            {
                throw new Exception("The ShipmentDate cannot be before EmissionDate.");
            }
        }

        await _customerValidationService.ValidateCustomerCreatedMessageAsync(message.Customer);        
        await _suppliersValidationService.ValidateSupplierCreatedMessageAsync(message.Supplier);        
        await _ordersItemsValidationService.ValidateOrderItemCreatedMessageAsync(message.OrderItems);
        await _deliveriesValidationService.ValidateDeliveryCreatedMessageAsync(message.Delivery);
        await _shipmentValidationService.ValidateShipmentCreatedMessageAsync(message.Shipment);
    }
}
