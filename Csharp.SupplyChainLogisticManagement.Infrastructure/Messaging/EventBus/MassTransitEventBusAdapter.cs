using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.EventBus;
public class MassTransitEventBusAdapter : IEventBus
{
    private readonly IPublishEndpoint _publishEndpoint;

    public MassTransitEventBusAdapter(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }
    public Task PublishAsync<T>(T message, CancellationToken cancellationToken = default) where T : class
    {
        return _publishEndpoint.Publish(message, cancellationToken);
    }

    public Task SendAsync<T>(T command, CancellationToken cancellationToken = default) where T : class
    {
        throw new NotImplementedException();
    }
}
