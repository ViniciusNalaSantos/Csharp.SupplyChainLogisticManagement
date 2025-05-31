using Csharp.SupplyChainLogisticManagement.Application.MessageHandlers;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Application.Queries;
using Csharp.SupplyChainLogisticManagement.Application.QueryHandlers;
using Csharp.SupplyChainLogisticManagement.Domain.Dto;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Handlers;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;
using Csharp.SupplyChainLogisticManagement.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Configuration.Extensions;
internal static class HandlersExtension
{
    public static void AddHandlersService(this IServiceCollection services)
    {
        services.AddScoped<IMessageHandlerw<OrderCreatedMessage>, CreateOrderMessageHandler>();
        services.AddScoped<IQueryHandlerw<GetOrderByIdQuery, ICollection<Orders>>, GetOrderByIdQueryHandler>();
        services.AddScoped<IQueryHandlerw<GetOrdersByEmissionDateQuery, PagedResultDto<Orders>>, GetOrdersByEmissionDateQueryHandler>();
    }
}
