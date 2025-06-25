using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.DTOs.ReturnDTOs;
public record ReturnOrderItemsDto
{
    public ReturnProductsDto Product { get; set; }
    public decimal Quantity { get; set; }
}
