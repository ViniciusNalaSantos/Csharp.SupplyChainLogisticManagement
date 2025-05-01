using Csharp.SupplyChainLogisticManagement.Application.CommandHandlers;
using Csharp.SupplyChainLogisticManagement.Application.Commands.CreateOrder;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Messaging.Extensions;
internal static class HandlersExtension
{
    public static void AddHandlersService(this IServiceCollection services)
    {
        services.AddScoped<IMessageHandler<OrderCreatedMessage>, CreateOrderMessageHandler>();
    }
}
