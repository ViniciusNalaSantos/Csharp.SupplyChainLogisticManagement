using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;
using Csharp.SupplyChainLogisticManagement.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
        return _context.Transporters.FirstOrDefault(predicate);
    }
    public async Task<Transporters?> InsertTransporterAsync(Transporters transporter)
    {
        _context.Transporters.Add(transporter);
        _context.SaveChanges();
        return transporter;
    }
}
