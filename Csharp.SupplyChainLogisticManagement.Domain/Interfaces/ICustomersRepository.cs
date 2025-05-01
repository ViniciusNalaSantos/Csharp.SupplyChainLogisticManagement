using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Domain.Interfaces;
public interface ICustomersRepository
{
    Task<Customers?> GetCustomerFirstOrDefaultAsync(Expression<Func<Customers, bool>> predicate); 
    Task<Customers?> InsertCustomerAsync(Customers customer);
}
