using Csharp.SupplyChainLogisticManagement.Application.ValidationServices.OrdersValidationServices;
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
    }
}
