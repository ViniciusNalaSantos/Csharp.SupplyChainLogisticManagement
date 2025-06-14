using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp.SupplyChainLogisticManagement.Infrastructure.EventBus;
using MassTransit;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.EventBus;
public class MassTransitEventBusAdapter : IEventBus
{
    private readonly IPublishEndpoint _publishEndpoint;

    public MassTransitEventBusAdapter(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }
    public async Task PublishAsync<T>(T message, CancellationToken cancellationToken = default) where T : class
    {
        await _publishEndpoint.Publish(message, cancellationToken);
    }

    public async Task SendAsync<T>(T command, CancellationToken cancellationToken = default) where T : class
    {
        throw new NotImplementedException();
    }
}
