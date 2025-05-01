using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Domain.Interfaces;
public interface IProductsRepository
{
    Task<Products?> GetProductFirstOrDefaultAsync(Expression<Func<Products, bool>> predicate); 
    Task<Products?> InsertProductAsync(Products product);
    
}
