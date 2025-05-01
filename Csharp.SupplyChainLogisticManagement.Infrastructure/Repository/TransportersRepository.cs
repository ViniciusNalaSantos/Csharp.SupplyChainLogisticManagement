using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;
using Csharp.SupplyChainLogisticManagement.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Repository;

public class TransportersRepository : ITransportersRepository
{
    private readonly LogiChainDbContext _context;
    public TransportersRepository(LogiChainDbContext context)
    {
        _context = context;
    }
    public async Task<Transporters?> GetTransporterFirstOrDefaultAsync(Expression<Func<Transporters, bool>> predicate)
    {
        return await _context.Transporters.FirstOrDefaultAsync(predicate);
    }
    public async Task<Transporters?> InsertTransporterAsync(Transporters transporter)
    {
        await _context.Transporters.AddAsync(transporter);
        await _context.SaveChangesAsync();
        return transporter;
    }
}
