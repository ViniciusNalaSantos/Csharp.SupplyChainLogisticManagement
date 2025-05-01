using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Domain.Interfaces;
public interface ITransportersRepository
{
    Task<Transporters?> GetTransporterFirstOrDefaultAsync(Expression<Func<Transporters, bool>> predicate); 
    Task<Transporters?> InsertTransporterAsync(Transporters transporter);    
}
