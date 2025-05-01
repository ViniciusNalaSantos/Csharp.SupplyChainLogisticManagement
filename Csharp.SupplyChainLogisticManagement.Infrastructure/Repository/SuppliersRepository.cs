using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces;
using Csharp.SupplyChainLogisticManagement.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Repository;
public class SuppliersRepository : ISuppliersRepository
{
    private readonly LogiChainDbContext _context;
    public SuppliersRepository(LogiChainDbContext context)
    {
        _context = context;
    }
    public async Task<Suppliers?> GetSupplierFirstOrDefaultAsync(Expression<Func<Suppliers, bool>> predicate)
    {
        return await _context.Suppliers.FirstOrDefaultAsync(predicate);
    }

    public async Task<Suppliers?> InsertSupplierAsync(Suppliers supplier)
    {
        await _context.Suppliers.AddAsync(supplier);
        await _context.SaveChangesAsync();
        return supplier;
    }
}
