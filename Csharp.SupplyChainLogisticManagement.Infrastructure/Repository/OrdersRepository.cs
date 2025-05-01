using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;
using Csharp.SupplyChainLogisticManagement.Infrastructure.DatabaseContext;
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
    public async Task<Orders?> InsertOrderAsync(Orders order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return order;
    }
}
