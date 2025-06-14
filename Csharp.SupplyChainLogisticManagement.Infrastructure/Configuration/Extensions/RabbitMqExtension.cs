using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Csharp.SupplyChainLogisticManagement.Infrastructure.Consumers;
using Csharp.SupplyChainLogisticManagement.Infrastructure.MessageConsumer;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using static MassTransit.Logging.OperationName;
using System.Reflection;
using Csharp.SupplyChainLogisticManagement.Infrastructure.EventBus;
using Csharp.SupplyChainLogisticManagement.Application.Interfaces;

[assembly: InternalsVisibleTo("Csharp.SupplyChainLogisticManagement.WebApi")]

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Configuration.Extensions;

internal static class RabbitMqExtension
{
    public static void AddRabbitMQService(this IServiceCollection services)
    {

        services.AddScoped<IMessageConsumer<OrderCreatedMessage>, OrderCreatedConsumer>();       
        services.AddScoped<IEventBus, MassTransitEventBusAdapter>();

        services.AddHandlersService();

        services.AddMassTransit(busConfigurator =>
        {            
            busConfigurator.AddConsumer<MassTransitConsumerAdapter<OrderCreatedMessage>>();         

            busConfigurator.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(new Uri("amqp://localhost:5672"), host =>
                {
                    host.Username("rabbitmq");
                    host.Password("rabbitmq");
                });

                cfg.ReceiveEndpoint("order-submitted-queue", e =>
                {                   
                    e.ConfigureConsumer<MassTransitConsumerAdapter<OrderCreatedMessage>>(ctx);
                    e.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
                });                
            });
        });
    }

}
