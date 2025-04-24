using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Infrastructure.DatabaseContext;
using Csharp.SupplyChainLogisticManagement.Infrastructure.MessageConsumer;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Consumers;
public sealed class OrderCreatedMessageConsumer : IMessageConsumer<OrderCreatedMessage>
{
    private readonly ILogger<OrderCreatedMessageConsumer> _logger;
    private readonly LogiChainDbContext _context;

    public OrderCreatedMessageConsumer(ILogger<OrderCreatedMessageConsumer> logger, LogiChainDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public Task ConsumeAsync(OrderCreatedMessage message, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Processing order, id: {message.MessageId}, date: {message.EmissionDate}.");
        var order = new Orders
        {
            EmissionDate = message.EmissionDate,
            CustomersId = message.CustomersId,
            SuppliersId = message.SuppliersId,
            Price = message.Price
        };
        _context.Orders.Add(order);
        _context.SaveChangesAsync();
        return Task.CompletedTask;
    }
}
