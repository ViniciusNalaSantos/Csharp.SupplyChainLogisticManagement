using Csharp.SupplyChainLogisticManagement.Application.DTOs;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Mappers.TransportersMappers;
public class TransportersMapper : ITransportersMapper
{
    public async Task<TransportersReturnDto> MapEntityToRetunDtoAsync(Transporters transporter)
    {
        return new TransportersReturnDto
        {
            Id = transporter.Id,
            Name = transporter.Name,
            Email = transporter.Email,
            Phone = transporter.Phone
        };
    }
}
