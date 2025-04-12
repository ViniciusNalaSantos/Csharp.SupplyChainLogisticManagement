using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Csharp.SupplyChainLogisticManagement.Application.Consumers;
using Csharp.SupplyChainLogisticManagement.Application.MessageConsumer;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Csharp.SupplyChainLogisticManagement.Application.MessageConsumer;
using static MassTransit.Logging.OperationName;
using System.Reflection;
using Csharp.SupplyChainLogisticManagement.Application.EventBus;

[assembly: InternalsVisibleTo("Csharp.SupplyChainLogisticManagement.WebApi")]

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Extensions;

internal static class AppExtensions
{
    public static void AddRabbitMQService(this IServiceCollection services)
    {

        services.AddScoped<IMessageConsumer<OrderSubmittedMessage>, OrderSubmittedConsumer>();
        services.AddScoped<IEventBus, MassTransitEventBusAdapter>();

        services.AddMassTransit(busConfigurator =>
        {            
            busConfigurator.AddConsumer<MassTransitConsumerAdapter<OrderSubmittedMessage>>();

            busConfigurator.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(new Uri("amqp://localhost:5672"), host =>
                {
                    host.Username("rabbitmq");
                    host.Password("rabbitmq");
                });

                cfg.ReceiveEndpoint("order-submitted-queue", e =>
                {
                    e.ConfigureConsumer<MassTransitConsumerAdapter<OrderSubmittedMessage>>(ctx);
                });
            });
        });
    }

}
