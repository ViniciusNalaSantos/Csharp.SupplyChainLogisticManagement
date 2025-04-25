using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Application.Services.CreateOrderService;
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

    public Task ConsumeAsync(OrderCreatedMessage message, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Processing order, id: {message.MessageId}, date: {message.EmissionDate}.");
        Orders order = _createOrderService.ReturnOrderMappedFromMessage(message);
        _context.Orders.Add(order);
        _context.SaveChangesAsync();
        return Task.CompletedTask;
    }
}
