using Csharp.SupplyChainLogisticManagement.Application.ValidationServices.CustomersValidationServices;
using Csharp.SupplyChainLogisticManagement.Application.ValidationServices.DeliveriesValidationServices;
using Csharp.SupplyChainLogisticManagement.Application.ValidationServices.OrdersItemsValidationServices;
using Csharp.SupplyChainLogisticManagement.Application.ValidationServices.OrdersValidationServices;
using Csharp.SupplyChainLogisticManagement.Application.ValidationServices.ProductsValidationServices;
using Csharp.SupplyChainLogisticManagement.Application.ValidationServices.ShipmentValidationServices;
using Csharp.SupplyChainLogisticManagement.Application.ValidationServices.SuppliersValidationServices;
using Csharp.SupplyChainLogisticManagement.Application.ValidationServices.TransportersValidationServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Csharp.SupplyChainLogisticManagement.WebApi")]

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Configuration.Extensions;
internal static class ValidationServiceExtension
{
    public static void AddValidationService(this IServiceCollection services)
    {
        services.AddScoped<IOrdersValidationService, OrdersValidationService>();
        services.AddScoped<IOrdersItemsValidationService, OrdersItemsValidationService>();
        services.AddScoped<ICustomerValidationService, CustomerValidationService>();
        services.AddScoped<ISuppliersValidationService, SupplierValidationService>();
        services.AddScoped<IDeliveriesValidationService, DeliveriesValidationService>();
        services.AddScoped<IProductsValidationService, ProductsValidationService>();
        services.AddScoped<IShipmentValidationService, ShipmentValidationService>();
        services.AddScoped<ITransportersValidationService, TransportersValidationService>();        
    }
}
