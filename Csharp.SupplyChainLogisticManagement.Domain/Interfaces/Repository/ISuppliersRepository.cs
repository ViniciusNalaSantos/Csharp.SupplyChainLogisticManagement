using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;
public interface ISuppliersRepository
{
    Task<Suppliers?> GetSupplierFirstOrDefaultAsync(Expression<Func<Suppliers, bool>> predicate); 
    Task<Suppliers?> InsertSupplierAsync(Suppliers supplier);
}
