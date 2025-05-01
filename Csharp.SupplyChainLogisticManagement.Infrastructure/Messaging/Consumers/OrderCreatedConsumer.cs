using Csharp.SupplyChainLogisticManagement.Application.CommandHandlers;
using Csharp.SupplyChainLogisticManagement.Application.Commands.CreateOrder;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Application.Services.CreateCustomerService;
using Csharp.SupplyChainLogisticManagement.Application.Services.CreateOrderService;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Infrastructure.DatabaseContext;
using Csharp.SupplyChainLogisticManagement.Infrastructure.MessageConsumer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Consumers;
public sealed class OrderCreatedConsumer : IMessageConsumer<OrderCreatedMessage>
{
    private readonly ILogger<OrderCreatedConsumer> _logger;
    private readonly LogiChainDbContext _context;
    private readonly IMessageHandler<OrderCreatedMessage> _messageHandler;

    public OrderCreatedConsumer(ILogger<OrderCreatedConsumer> logger, LogiChainDbContext context, IMessageHandler<OrderCreatedMessage> messageHandler)
    {
        _logger = logger;
        _context = context;
        _messageHandler = messageHandler;
    }

    public async Task ConsumeAsync(OrderCreatedMessage message, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Processing order, id: {message.MessageId}, date: {message.EmissionDate}.");

        _messageHandler.Handle(message);

        Customers customer = null;
        if (message.Customer != null)
        {
            customer = await _context.Customers.FirstOrDefaultAsync(l => l.Email == message.Customer.Email);
            if (customer == null)
            {
                customer = new Customers
                {
                    Name = message.Customer.Name,
                    Email = message.Customer.Email,
                    Address = message.Customer.Address
                };
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
            }
        }

        Suppliers supplier = null;
        if (message.Supplier != null)
        {
            supplier = await _context.Suppliers.FirstOrDefaultAsync(l => l.Email == message.Supplier.Email);
            if (supplier == null)
            {
                supplier = new Suppliers
                {
                    Name = message.Supplier.Name,
                    Email = message.Supplier.Email,
                    Phone = message.Supplier.Phone
                };
                await _context.Suppliers.AddAsync(supplier);
                await _context.SaveChangesAsync();
            }
        }

        Orders order = new Orders
        {
            EmissionDate = message.EmissionDate,
            Price = Math.Round(message.Price, 2),
            CustomersId = customer?.Id ?? message.CustomerId,
            SuppliersId = supplier?.Id ?? message.SupplierId,
            
        };
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();        
        
        foreach (var messageOrderItem in message.OrderItems)
        {
            Products product = null;
            if (messageOrderItem.Product != null)
            {
                product = await _context.Products.FirstOrDefaultAsync(l => l.Description == messageOrderItem.Product.Description);
                if (product == null)
                {
                    product = new Products
                    {
                        Description = messageOrderItem.Product.Description,
                        Price = messageOrderItem.Product.Price
                    };
                    await _context.Products.AddAsync(product);
                    await _context.SaveChangesAsync();
                }
            }

            var orderItem = new OrdersItems
            {
                OrdersId = order.Id,
                ProductsId = (int)(product?.Id ?? messageOrderItem.ProductId),
                Quantity = Math.Round(messageOrderItem.Quantity, 2)
            };
            await _context.OrdersItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        };
                
        Shipments shipment = null;
        if (message.Shipment != null)
        {
            shipment = new Shipments
            {
                OrdersId = order.Id,
                ShipmentDate = message.Shipment.ShipmentDate
            };
            await _context.Shipments.AddAsync(shipment);
            await _context.SaveChangesAsync();
        }

        Deliveries delivery = null;
        if (message.Delivery != null)
        {
            Transporters transporter = null;
            if (message.Delivery.Transporter != null)
            {
                transporter = await _context.Transporters.FirstOrDefaultAsync(l => l.Email == message.Delivery.Transporter.Email);
                if (transporter == null)
                {
                    transporter = new Transporters
                    {
                        Name = message.Delivery.Transporter.Name,
                        Email = message.Delivery.Transporter.Email,
                        Phone = message.Delivery.Transporter.Phone
                    };
                    await _context.Transporters.AddAsync(transporter);
                    await _context.SaveChangesAsync();
                }
            }
            
            delivery = new Deliveries
            {
                OrdersId = order.Id,
                TransportersId = (int)(transporter?.Id ?? message.Delivery.TransporterId),
            };
            await _context.Deliveries.AddAsync(delivery);
            await _context.SaveChangesAsync();
        }
    }
}
