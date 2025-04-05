using Csharp.SupplyChainLogisticManagement.Application.MessageConsumer;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Consumers;
public sealed class OrderSubmittedConsumer : IMessageConsumer<OrderSubmittedMessage>
{
    private readonly ILogger<OrderSubmittedConsumer> _logger;

    public OrderSubmittedConsumer(ILogger<OrderSubmittedConsumer> logger)
    {
        _logger = logger;
    }

    public Task ConsumeAsync(OrderSubmittedMessage message, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Processing order, id: {message.OrderId}, date: {message.OrderDate}.");        
        return Task.CompletedTask;
    }
}
