using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.DTOs.ReturnDTOs;
public record ProductsReturnDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
