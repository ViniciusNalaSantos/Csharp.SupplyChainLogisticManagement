using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Interfaces.Handlers;
public interface IQueryHandler<TQuery, TResult>
{
    Task<TResult> Handle(TQuery query);
}
