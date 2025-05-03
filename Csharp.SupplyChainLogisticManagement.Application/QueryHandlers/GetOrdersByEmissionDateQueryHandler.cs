using Csharp.SupplyChainLogisticManagement.Application.Queries;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.QueryHandlers;
public class GetOrdersByEmissionDateQueryHandler : IQueryHandler<GetOrderByEmissionDateQuery, List<Orders>>
{
    public async Task<List<Orders?>> Handle(GetOrderByEmissionDateQuery query)
    {
        throw new NotImplementedException();
    }
}
