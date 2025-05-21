using Csharp.SupplyChainLogisticManagement.Application.DTOs;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Mappers.ShipmentsMappers;
public interface IShipmentsMapper
{
    public Task<ShipmentsReturnDto> MapEntityToRetunDtoAsync(Shipments shipment);
}
