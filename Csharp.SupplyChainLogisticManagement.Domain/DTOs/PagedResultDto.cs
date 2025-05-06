using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Domain.Dto;
public class PagedResultDto<T>
{
    public IList<T> ListResults { get; set; }
    public int ListResultsCount { get; set; }
    public int TotalPages { get; set; }
}
