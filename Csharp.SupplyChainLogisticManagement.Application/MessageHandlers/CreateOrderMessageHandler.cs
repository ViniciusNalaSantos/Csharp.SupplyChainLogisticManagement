using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Handlers;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.MessageHandlers;
public class CreateOrderMessageHandler : IMessageHandler<OrderCreatedMessage>
{
    private readonly ICustomersRepository _customersRepository;
    private readonly ISuppliersRepository _suppliersRepository;
    private readonly IOrdersRepository _ordersRepository;
    private readonly IProductsRepository _productsRepository;
    private readonly IOrdersItemsRepository _ordersItemsRepository;
    private readonly IShipmentsRepository _shipmentsRepository;
    private readonly IDeliveriesRepository _deliveriesRepository;
    private readonly ITransportersRepository _transportersRepository;
    public CreateOrderMessageHandler(ICustomersRepository customersRepository, ISuppliersRepository suppliersRepository, IOrdersRepository ordersRepository,
        IProductsRepository productsRepository, IOrdersItemsRepository ordersItemsRepository, IShipmentsRepository shipmentsRepository,
        IDeliveriesRepository deliveriesRepository, ITransportersRepository transportersRepository)
    {
        _customersRepository = customersRepository;
        _suppliersRepository = suppliersRepository;
        _ordersRepository = ordersRepository;
        _productsRepository = productsRepository;
        _ordersItemsRepository = ordersItemsRepository;
        _shipmentsRepository = shipmentsRepository;
        _deliveriesRepository = deliveriesRepository;
        _transportersRepository = transportersRepository;
    }
    public async void Handle(OrderCreatedMessage message)
    {
        Customers customer = null;
        if (message.Customer != null)
        {
            customer = await _customersRepository.GetCustomerFirstOrDefaultAsync(l => l.Email == message.Customer.Email);
            if (customer == null)
            {                
                customer = new Customers
                {
                    Name = message.Customer.Name,
                    Email = message.Customer.Email,
                    Address = message.Customer.Address
                };
                customer = await _customersRepository.InsertCustomerAsync(customer);                
            }
        }

        Suppliers supplier = null;
        if (message.Supplier != null)
        {
            supplier = await _suppliersRepository.GetSupplierFirstOrDefaultAsync(l => l.Email == message.Supplier.Email);
            if (supplier == null)
            {
                supplier = new Suppliers
                {
                    Name = message.Supplier.Name,
                    Email = message.Supplier.Email,
                    Phone = message.Supplier.Phone
                };
                supplier = await _suppliersRepository.InsertSupplierAsync(supplier);
            }
        }

        Orders order = new Orders
        {
            EmissionDate = message.EmissionDate,
            Price = Math.Round(message.Price, 2),
            CustomersId = customer?.Id ?? message.CustomerId,
            SuppliersId = supplier?.Id ?? message.SupplierId,
            
        };
        order = await _ordersRepository.InsertOrderAsync(order);
        
        foreach (var messageOrderItem in message.OrderItems)
        {
            Products product = null;
            if (messageOrderItem.Product != null)
            {
                product = await _productsRepository.GetProductFirstOrDefaultAsync(l => l.Description == messageOrderItem.Product.Description);
                if (product == null)
                {
                    product = new Products
                    {
                        Description = messageOrderItem.Product.Description,
                        Price = messageOrderItem.Product.Price
                    };
                    product = await _productsRepository.InsertProductAsync(product);
                }
            }

            var orderItem = new OrdersItems
            {
                OrdersId = order.Id,
                ProductsId = (int)(product?.Id ?? messageOrderItem.ProductId),
                Quantity = Math.Round(messageOrderItem.Quantity, 2)
            };
            orderItem = await _ordersItemsRepository.InsertOrderItemAsync(orderItem);            
        };
                
        Shipments shipment = null;
        if (message.Shipment != null)
        {
            shipment = new Shipments
            {
                OrdersId = order.Id,
                ShipmentDate = message.Shipment.ShipmentDate
            };
            shipment = await _shipmentsRepository.InsertShipmentAsync(shipment);            
        }

        Deliveries delivery = null;
        if (message.Delivery != null)
        {
            Transporters transporter = null;
            if (message.Delivery.Transporter != null)
            {
                transporter = await _transportersRepository.GetTransporterFirstOrDefaultAsync(l => l.Email == message.Delivery.Transporter.Email);
                if (transporter == null)
                {
                    transporter = new Transporters
                    {
                        Name = message.Delivery.Transporter.Name,
                        Email = message.Delivery.Transporter.Email,
                        Phone = message.Delivery.Transporter.Phone
                    };
                    transporter = await _transportersRepository.InsertTransporterAsync(transporter);
                }
            }
            
            delivery = new Deliveries
            {
                OrdersId = order.Id,
                TransportersId = (int)(transporter?.Id ?? message.Delivery.TransporterId),
            };
            delivery = await _deliveriesRepository.InsertDeliveryAsync(delivery);
        }
    }
}
