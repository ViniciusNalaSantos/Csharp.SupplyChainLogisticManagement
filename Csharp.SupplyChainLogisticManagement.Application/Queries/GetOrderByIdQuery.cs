using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Queries;
public record GetOrderByIdQuery
{
    public int Id { get; set; }
}
