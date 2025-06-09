using Csharp.SupplyChainLogisticManagement.Application.DTOs.InputDTOs;
using Csharp.SupplyChainLogisticManagement.Application.DTOs.ReturnDTOs;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Mappers.ShipmentsMappers;
public class ShipmentsMapper : IShipmentsMapper
{
    public async Task<ReturnShipmentsDto> MapEntityToRetunDtoAsync(Shipments shipment)
    {
        if (shipment == null) { return null; }
        return new ReturnShipmentsDto
        {
            Id = shipment.Id,
            ShipmentDate = shipment.ShipmentDate
        };
    }

    public async Task<ShipmentCreatedMessage> MapInputToCreatedMessageAsync(InputShipmentDto inputShipment)
    {
        if (inputShipment == null) { return null; }
        return new ShipmentCreatedMessage
        {
            ShipmentDate = inputShipment.ShipmentDate
        };
    }
}
