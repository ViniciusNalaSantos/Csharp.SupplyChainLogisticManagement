using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.MessageConsumer;
public class MassTransitConsumerAdapter<TMessage> : IConsumer<TMessage> where TMessage : class
{
    private readonly IMessageConsumer<TMessage> _inner;

    public MassTransitConsumerAdapter(IMessageConsumer<TMessage> inner)
    {
        _inner = inner;
    }

    public async Task Consume(ConsumeContext<TMessage> context)
    {
        await _inner.ConsumeAsync(context.Message);
    }
}
