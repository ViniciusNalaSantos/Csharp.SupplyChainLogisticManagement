using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.DTOs.ReturnDTOs;
public record ReturnDeliveriesDto
{
    public int Id { get; set; }
    public ReturnTransportersDto Transporters { get; set; }
    public DateTime DeliveryDate { get; set; }
}
