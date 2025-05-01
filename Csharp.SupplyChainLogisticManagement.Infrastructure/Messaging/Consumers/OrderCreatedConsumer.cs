using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Application.Services.CreateCustomerService;
using Csharp.SupplyChainLogisticManagement.Application.Services.CreateOrderService;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Handlers;
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
    private readonly IMessageHandler<OrderCreatedMessage> _messageHandler;

    public OrderCreatedConsumer(ILogger<OrderCreatedConsumer> logger, IMessageHandler<OrderCreatedMessage> messageHandler)
    {
        _logger = logger;
        _messageHandler = messageHandler;
    }
    public async Task ConsumeAsync(OrderCreatedMessage message, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Processing order, id: {message.MessageId}, date: {message.EmissionDate}.");
        _messageHandler.Handle(message);     
    }
}
