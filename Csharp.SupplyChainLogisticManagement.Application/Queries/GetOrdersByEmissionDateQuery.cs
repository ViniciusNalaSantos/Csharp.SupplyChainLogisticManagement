using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Queries;
public record GetOrdersByEmissionDateQuery
{
    public DateTime EmissionDateStart { get; set; }
    public DateTime EmissionDateEnd { get; set; }
    public int Page {  get; set; }
}
