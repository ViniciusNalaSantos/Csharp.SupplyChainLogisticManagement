using Csharp.SupplyChainLogisticManagement.Domain.Dto;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;
public interface IOrdersRepository
{
    Task<Orders?> GetOrderFirstOrDefaultAsync(Expression<Func<Orders, bool>> predicate);
    Task<Orders?> InsertOrderAsync(Orders order);
    Task<PagedResultDto<Orders>> GetOrdersPagedByEmissionDate(DateTime emissionDateStart, DateTime emissionDateEnd, int pageNumber, int pageSize);
}
