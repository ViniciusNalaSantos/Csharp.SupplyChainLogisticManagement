using Csharp.SupplyChainLogisticManagement.Application.Mappers.CustomersMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.DeliveriesMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.OrdersItemsMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.OrdersMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.ProductsMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.ShipmentsMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.SuppliersMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.TransportersMappers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Csharp.SupplyChainLogisticManagement.WebApi")]

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Configuration.Extensions;
internal static class MapperExtension
{
    public static void AddMapperService(this IServiceCollection services)
    {
        services.AddScoped<IOrdersMapper, OrdersMapper>();
        services.AddScoped<IOrdersItemsMapper, OrdersItemsMapper>();
        services.AddScoped<IDeliveriesMapper, DeliveriesMapper>();
        services.AddScoped<ICustomersMapper, CustomersMapper>();
        services.AddScoped<IProductsMapper, ProductsMapper>();
        services.AddScoped<IShipmentsMapper, ShipmentsMapper>();
        services.AddScoped<ISuppliersMapper, SuppliersMapper>();
        services.AddScoped<ITransportersMapper, TransportersMapper>();
    }
}
