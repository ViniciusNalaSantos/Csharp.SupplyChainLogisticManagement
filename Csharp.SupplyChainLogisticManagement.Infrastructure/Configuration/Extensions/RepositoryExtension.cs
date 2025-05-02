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
        services.AddTransient<ICustomersRepository, CustomersRepository>();
        services.AddTransient<ISuppliersRepository, SuppliersRepository>();
        services.AddTransient<IOrdersRepository, OrdersRepository>();
        services.AddTransient<IProductsRepository, ProductsRepository>();
        services.AddTransient<IOrdersItemsRepository, OrdersItemsRepository>();
        services.AddTransient<IShipmentsRepository, ShipmentsRepository>();
        services.AddTransient<IDeliveriesRepository, DeliveriesRepository>();
        services.AddTransient<ITransportersRepository, TransportersRepository>();
    }
}
