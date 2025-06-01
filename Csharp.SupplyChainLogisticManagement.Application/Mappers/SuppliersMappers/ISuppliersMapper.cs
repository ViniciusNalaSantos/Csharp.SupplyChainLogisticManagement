using Csharp.SupplyChainLogisticManagement.Application.DTOs.InputDTOs;
using Csharp.SupplyChainLogisticManagement.Application.DTOs.ReturnDTOs;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Mappers.SuppliersMappers;
public interface ISuppliersMapper
{
    public Task<ReturnSuppliersDto> MapEntityToRetunDtoAsync(Suppliers supplier);
    public Task<SupplierCreatedMessage> MapInputToCreatedMessageAsync(InputSupplierDto inputSupplier);
}
