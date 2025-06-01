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
public interface ITransportersMapper
{
    public Task<ReturnTransportersDto> MapEntityToRetunDtoAsync(Transporters transporter);
    public Task<TransporterCreatedMessage> MapInputToCreatedMessageAsync(InputTransporterDto inputTransporter);
}
