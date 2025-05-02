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

public class CustomersRepository : ICustomersRepository
{
    private readonly LogiChainDbContext _context;
    public CustomersRepository(LogiChainDbContext context)
    {
        _context = context;
    }
    public async Task<Customers?> GetCustomerFirstOrDefaultAsync(Expression<Func<Customers, bool>> predicate)
    {
        return _context.Customers.FirstOrDefault(predicate);
    }
    public async Task<Customers?> InsertCustomerAsync(Customers customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return customer;
    }
}
