using Csharp.SupplyChainLogisticManagement.Application.Interfaces;
using Csharp.SupplyChainLogisticManagement.Infrastructure.UnitsOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Configuration.Extensions;
internal static class UnitOfWorkExtension
{
    public static void AddUnitOfWorkService(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
