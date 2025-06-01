using Csharp.SupplyChainLogisticManagement.Application.DTOs.InputDTOs;
using Csharp.SupplyChainLogisticManagement.Application.DTOs.ReturnDTOs;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Mappers.TransportersMappers;
public class TransportersMapper : ITransportersMapper
{
    public async Task<ReturnTransportersDto> MapEntityToRetunDtoAsync(Transporters transporter)
    {
        if (transporter == null) return null;
        return new ReturnTransportersDto
        {
            Id = transporter.Id,
            Name = transporter.Name,
            Email = transporter.Email,
            Phone = transporter.Phone
        };
    }

    public async Task<TransporterCreatedMessage> MapInputToCreatedMessageAsync(InputTransporterDto inputTransporter)
    {
        return new TransporterCreatedMessage
        {
            Name = inputTransporter.Name,
            Email = inputTransporter.Email,
            Phone = inputTransporter.Phone
        };
    }
}
