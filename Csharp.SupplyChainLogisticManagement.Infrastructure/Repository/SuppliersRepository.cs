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
public class SuppliersRepository : ISuppliersRepository
{
    private readonly LogiChainDbContext _context;
    public SuppliersRepository(LogiChainDbContext context)
    {
        _context = context;
    }
    public async Task<Suppliers?> GetSupplierFirstOrDefaultAsync(Expression<Func<Suppliers, bool>> predicate)
    {
        return _context.Suppliers.FirstOrDefault(predicate);
    }

    public async Task<Suppliers?> InsertSupplierAsync(Suppliers supplier)
    {
        _context.Suppliers.Add(supplier);
        return supplier;
    }
}
