using Csharp.SupplyChainLogisticManagement.Application.DTOs.InputDTOs;
using Csharp.SupplyChainLogisticManagement.Application.DTOs.ReturnDTOs;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.TransportersMappers;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Mappers.DeliveriesMappers;
public class DeliveriesMapper : IDeliveriesMapper
{
    private readonly ITransportersMapper _transportersMapper;
    public DeliveriesMapper(ITransportersMapper transportersMapper)
    {
        _transportersMapper = transportersMapper;
    }
    public async Task<ReturnDeliveriesDto> MapEntityToRetunDtoAsync(Deliveries delivery)
    {
        return new ReturnDeliveriesDto
        {
            Id = delivery.Id,
            Transporters = await _transportersMapper.MapEntityToRetunDtoAsync(delivery.Transporters),
            DeliveryDate = delivery.DeliveryDate
        };
    }

    public async Task<DeliveryCreatedMessage> MapInputToCreatedMessageAsync(InputDeliveryDto inputDelivery)
    {
        return new DeliveryCreatedMessage
        {
            TransporterId = inputDelivery.TransporterId,
            Transporter = await _transportersMapper.MapInputToCreatedMessageAsync(inputDelivery.Transporter),
            DeliveryDate = inputDelivery.DeliveryDate,
        };
    }
}
