using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;
using Csharp.SupplyChainLogisticManagement.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Repository;
public class OrdersItemsRepository : IOrdersItemsRepository
{
    private readonly LogiChainDbContext _context;
    public OrdersItemsRepository(LogiChainDbContext context)
    {
        _context = context;
    }
    public async Task<OrdersItems?> InsertOrderItemAsync(OrdersItems orderItem)
    {
        _context.OrdersItems.Add(orderItem);
        return orderItem;
    }
}
