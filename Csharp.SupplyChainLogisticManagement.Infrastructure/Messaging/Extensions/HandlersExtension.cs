using Csharp.SupplyChainLogisticManagement.Application.MessageHandlers;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Handlers;
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
