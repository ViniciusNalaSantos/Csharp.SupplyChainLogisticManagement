using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.DTOs.ReturnDTOs;
public record ReturnPagedOrdersDto<Orders>
{
    public int ActualPage { get; set; }
    public int TotalPages { get; set; }
    public int PageLimit { get; set; }
    public int OrdersListCount { get; set; }
    public ICollection<ReturnOrdersDto> OrdersList {  get; set; }    
}
