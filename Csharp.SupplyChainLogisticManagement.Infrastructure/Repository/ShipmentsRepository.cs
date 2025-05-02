using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;
using Csharp.SupplyChainLogisticManagement.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Repository;
public class ShipmentsRepository : IShipmentsRepository
{
    private readonly LogiChainDbContext _context;
    public ShipmentsRepository(LogiChainDbContext context)
    {
        _context = context;
    }
    public async Task<Shipments?> InsertShipmentAsync(Shipments shipment)
    {
        _context.Shipments.Add(shipment);
        _context.SaveChanges();
        return shipment;
    }
}
