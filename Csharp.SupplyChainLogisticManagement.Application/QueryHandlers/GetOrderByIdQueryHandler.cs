using Csharp.SupplyChainLogisticManagement.Application.Queries;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Handlers;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.QueryHandlers;
public class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, List<Orders>>
{
    private readonly IOrdersRepository _ordersRepository;
    public GetOrderByIdQueryHandler(IOrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }
    public async Task<List<Orders?>> Handle(GetOrderByIdQuery query)
    {
        var order = await _ordersRepository.GetOrderFirstOrDefaultAsync(l => l.Id == query.Id);
        return order is not null ? new List<Orders?> { order } : new List<Orders?>();
    }
}
