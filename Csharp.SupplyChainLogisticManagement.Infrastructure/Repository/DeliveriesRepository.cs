using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;
using Csharp.SupplyChainLogisticManagement.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Repository;
public class DeliveriesRepository : IDeliveriesRepository
{
    private readonly LogiChainDbContext _context;
    public DeliveriesRepository(LogiChainDbContext context)
    {
        _context = context;
    }
    public async Task<Deliveries?> InsertDeliveryAsync(Deliveries delivery)
    {
        await _context.Deliveries.AddAsync(delivery);
        return delivery;
    }
}
