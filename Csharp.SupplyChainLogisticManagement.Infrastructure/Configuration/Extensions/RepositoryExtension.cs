using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;
using Csharp.SupplyChainLogisticManagement.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Configuration.Extensions;
internal static class RepositoryExtension
{
    public static void AddRepositoryService(this IServiceCollection services)
    {
        services.AddScoped<ICustomersRepository, CustomersRepository>();
        services.AddScoped<ISuppliersRepository, SuppliersRepository>();
        services.AddScoped<IOrdersRepository, OrdersRepository>();
        services.AddScoped<IProductsRepository, ProductsRepository>();
        services.AddScoped<IOrdersItemsRepository, OrdersItemsRepository>();
        services.AddScoped<IShipmentsRepository, ShipmentsRepository>();
        services.AddScoped<IDeliveriesRepository, DeliveriesRepository>();
        services.AddScoped<ITransportersRepository, TransportersRepository>();
    }
}
