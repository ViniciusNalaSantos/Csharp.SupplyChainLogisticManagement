using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.DTOs;
public record OrdersItemsReturnDto
{
    public ProductsReturnDto Product { get; set; }
    public decimal Quantity { get; set; }
}
