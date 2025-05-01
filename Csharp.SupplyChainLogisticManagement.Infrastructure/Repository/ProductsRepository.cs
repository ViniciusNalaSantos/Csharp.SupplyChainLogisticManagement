using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Repository;
public class ProductsRepository : IProductsRepository
{
    private readonly LogiChainDbContext _context;
    public ProductsRepository(LogiChainDbContext context)
    {
        _context = context;
    }

    public async Task<Products?> GetProductFirstOrDefaultAsync(Expression<Func<Products, bool>> predicate)
    {
        return await _context.Products.FirstOrDefaultAsync(predicate);
    }

    public async Task<Products?> InsertProductAsync(Products product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    } 
}
