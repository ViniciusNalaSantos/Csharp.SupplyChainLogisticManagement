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
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Consumers;
public sealed class OrderCreatedConsumer : IMessageConsumer<OrderCreatedMessage>
{
    private readonly ILogger<OrderCreatedConsumer> _logger;
    private readonly LogiChainDbContext _context;
    private readonly ICreateOrderService _createOrderService;

    public OrderCreatedConsumer(ILogger<OrderCreatedConsumer> logger, LogiChainDbContext context, ICreateOrderService createOrderService)
    {
        _logger = logger;
        _context = context;
        _createOrderService = createOrderService;
    }

    public async Task ConsumeAsync(OrderCreatedMessage message, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Processing order, id: {message.MessageId}, date: {message.EmissionDate}.");

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
                _context.Customers.Add(customer);
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
                _context.Suppliers.Add(supplier);
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
        _context.Orders.Add(order);
        _context.SaveChangesAsync();        
        
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
                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();
                }
            }

            var orderItem = new OrdersItems
            {
                OrdersId = order.Id,
                ProductsId = product?.Id ?? messageOrderItem.ProductId,
                Quantity = Math.Round(messageOrderItem.Quantity, 2)
            };

            Shipments shipment = null;
            if (message.Shipment != null)
            {               
                shipment = new Shipments
                {
                    OrdersId = order.Id,
                    ShipmentDate = message.Shipment.ShipmentDate
                };
                _context.Shipments.Add(shipment);
                await _context.SaveChangesAsync();
            }
        };        
    }
}
