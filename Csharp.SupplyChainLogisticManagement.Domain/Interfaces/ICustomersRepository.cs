using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Domain.Interfaces;
public interface ICustomersRepository
{
    Task<Customers> GetCustomerFirstOrDefaultAsync(); 
    Task InsertCustomerAsync(Customers customers);
}
