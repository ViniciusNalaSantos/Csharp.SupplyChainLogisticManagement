using Csharp.SupplyChainLogisticManagement.Application.DTOs;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.TransportersMappers;
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
    public async Task<DeliveriesReturnDto> MapEntityToRetunDtoAsync(Deliveries delivery)
    {
        return new DeliveriesReturnDto
        {
            Id = delivery.Id,
            Transporters = await _transportersMapper.MapEntityToRetunDtoAsync(delivery.Transporters),
            DeliveryDate = delivery.DeliveryDate
        };
    }
}
