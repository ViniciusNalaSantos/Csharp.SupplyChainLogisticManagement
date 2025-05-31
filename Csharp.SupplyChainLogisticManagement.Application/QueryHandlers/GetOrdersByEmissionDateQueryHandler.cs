using Csharp.SupplyChainLogisticManagement.Application.Queries;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Application.Interfaces.Handlers;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;
using Csharp.SupplyChainLogisticManagement.Application.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using Csharp.SupplyChainLogisticManagement.Domain.Dto;

namespace Csharp.SupplyChainLogisticManagement.Application.QueryHandlers;
public class GetOrdersByEmissionDateQueryHandler : IQueryHandler<GetOrdersByEmissionDateQuery, PagedResultDto<Orders>>
{
    private readonly IOrdersRepository _ordersRepository;
    public GetOrdersByEmissionDateQueryHandler(IOrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }
    public async Task<PagedResultDto<Orders>> Handle(GetOrdersByEmissionDateQuery query)
    {
        var pageSize = PagedResult.PageSizeLimit;
        var pagedOrders = await _ordersRepository.GetOrdersPagedByEmissionDate(query.EmissionDateStart, query.EmissionDateEnd, query.Page, pageSize);
        return pagedOrders;        
    }
}
