using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.DTOs;
public record DeliveriesReturnDto
{
    public int Id { get; set; }
    public TransportersReturnDto Transporters { get; set; }
    public DateTime DeliveryDate { get; set; }
}
