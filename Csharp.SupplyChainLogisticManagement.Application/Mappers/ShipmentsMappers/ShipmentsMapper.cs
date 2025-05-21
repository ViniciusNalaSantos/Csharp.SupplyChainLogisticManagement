using Csharp.SupplyChainLogisticManagement.Application.DTOs;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Mappers.ShipmentsMappers;
public class ShipmentsMapper : IShipmentsMapper
{
    public async Task<ShipmentsReturnDto> MapEntityToRetunDtoAsync(Shipments shipment)
    {
        return new ShipmentsReturnDto
        {
            Id = shipment.Id,
            ShipmentDate = shipment.ShipmentDate
        };
    }
}
