using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.DTOs.ReturnDTOs;
public record ReturnOrdersDto
{
    public int Id { get; set; }
    public DateTime EmissionDate { get; set; }
    public ReturnCustomersDto Customer { get; set; }
    public ReturnSuppliersDto Supplier { get; set; }
    public decimal Price { get; set; }
    public ICollection<ReturnOrdersItemsDto> OrderItems { get; set; }
    public ReturnShipmentsDto Shipments { get; set; }
    public ReturnDeliveriesDto Deliveries { get; set; }
}
