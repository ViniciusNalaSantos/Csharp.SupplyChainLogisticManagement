using Csharp.SupplyChainLogisticManagement.Application.Common.Constants;
using Csharp.SupplyChainLogisticManagement.Domain.Dto;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;
using Csharp.SupplyChainLogisticManagement.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Repository;
public class OrdersRepository : IOrdersRepository
{
    private readonly LogiChainDbContext _context;
    public OrdersRepository(LogiChainDbContext context)
    {
        _context = context;
    }
    public async Task<Orders?> GetOrderFirstOrDefaultAsync(Expression<Func<Orders, bool>> predicate)
    {
        return _context.Orders.FirstOrDefault(predicate);
    }
    public async Task<PagedResultDto<Orders?>> GetOrdersPagedByEmissionDate(DateTime emissionDateStart, DateTime emissionDateEnd, int pageNumber, int pageSize)
    {
        var orders = _context.Orders
            .Where(l => l.EmissionDate >= emissionDateStart && l.EmissionDate <= emissionDateEnd)
            .OrderBy(l => l.Id);
        var totalOrders = await orders.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalOrders / PagedResult.PageSizeLimit);
        
        var ordersPaged = orders
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);
        var totalOrdersPaged = await ordersPaged.CountAsync();

        return new PagedResultDto<Orders>()
        {
            ListResults = await ordersPaged.ToListAsync(),
            ListResultsCount = totalOrdersPaged,
            TotalPages = totalPages
        };            
    }
    public async Task<Orders?> InsertOrderAsync(Orders order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
        return order;
    }
}
