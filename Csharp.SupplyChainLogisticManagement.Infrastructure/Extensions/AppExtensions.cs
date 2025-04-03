using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Csharp.SupplyChainLogisticManagement.WebApi")]

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Extensions;

internal static class AppExtensions
{
    public static void AddRabbitMQService(this IServiceCollection services)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(new Uri("amqp://localhost:15672"), host =>
                {
                    host.Username("rabbitmq");
                    host.Password("rabbitmq");
                });
            });
        });
    }

}
