using Csharp.SupplyChainLogisticManagement.Application.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.UnitTests.TestUtils.Builders;
internal class OrderCreatedMessageBuilder
{
    private string _orderNumber = "ORD-001";
    private DateTime _emissionDate = DateTime.Today;
    private int? _customerId = null;
    private CustomerCreatedMessage? _customer = null;
    private int? _supplierId = null;
    private SupplierCreatedMessage? _supplier = null;
    private decimal _price = 1000m;
    private readonly List<OrderItemsCreatedMessage> _orderItems = new();
    private DeliveryCreatedMessage? _delivery = null;
    private ShipmentCreatedMessage? _shipment = null;

    public OrderCreatedMessageBuilder WithOrderNumber(string orderNumber)
    {
        _orderNumber = orderNumber;
        return this;
    }

    public OrderCreatedMessageBuilder WithEmissionDate(DateTime date)
    {
        _emissionDate = date;
        return this;
    }

    public OrderCreatedMessageBuilder WithCustomerId(int customerId)
    {
        _customerId = customerId;
        return this;
    }

    public OrderCreatedMessageBuilder WithCustomer(string name = "CustomerY", string email = "customer@email.com", string address = "Rua 1")
    {
        _customer = new CustomerCreatedMessage
        {
            Id = null,
            Name = name,
            Email = email,
            Address = address
        };
        return this;
    }

    public OrderCreatedMessageBuilder WithCustomer(CustomerCreatedMessage message)
    {
        _customer = message;
        return this;
    }

    public OrderCreatedMessageBuilder WithSupplierId(int supplierId)
    {
        _supplierId = supplierId;
        return this;
    }

    public OrderCreatedMessageBuilder WithSupplier(string name = "SupplierX", string email = "supplier@email.com", string phone = "123456789")
    {
        _supplier = new SupplierCreatedMessage
        {
            Id = null,
            Name = name,
            Email = email,
            Phone = phone
        };
        return this;
    }

    public OrderCreatedMessageBuilder WithPrice(decimal price)
    {
        _price = price;
        return this;
    }

    public OrderCreatedMessageBuilder AddOrderItem(string description = "Product A", decimal price = 50, decimal quantity = 2)
    {
        _orderItems.Add(new OrderItemsCreatedMessage
        {
            Product = new ProductCreatedMessage
            {
                Description = description,
                Price = price
            },
            Quantity = quantity
        });
        return this;
    }

    public OrderCreatedMessageBuilder WithProductIdOnly(int productId, decimal quantity = 2)
    {
        _orderItems.Add(new OrderItemsCreatedMessage
        {
            ProductId = productId,
            Product = null,
            Quantity = quantity
        });
        return this;
    }

    public OrderCreatedMessageBuilder WithShipment(DateTime? date = null)
    {
        _shipment = new ShipmentCreatedMessage
        {
            ShipmentDate = date ?? DateTime.Today.AddDays(1)
        };
        return this;
    }

    public OrderCreatedMessageBuilder WithDelivery(string transporterName = "TransFast", string email = "trans@email.com", string phone = "9999999")
    {
        _delivery = new DeliveryCreatedMessage
        {
            DeliveryDate = DateTime.Today.AddDays(3),
            Transporter = new TransporterCreatedMessage
            {
                Name = transporterName,
                Email = email,
                Phone = phone
            }
        };
        return this;
    }

    public OrderCreatedMessage Build()
    {        
        return new OrderCreatedMessage
        {
            OrderNumber = _orderNumber,
            EmissionDate = _emissionDate,
            CustomerId = _customerId,
            Customer = _customer,
            SupplierId = _supplierId,
            Supplier = _supplier,
            Price = _price,
            OrderItems = _orderItems,
            Shipment = _shipment,
            Delivery = _delivery
        };
    }
}