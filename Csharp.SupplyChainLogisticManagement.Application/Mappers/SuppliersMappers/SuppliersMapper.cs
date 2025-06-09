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
public class SuppliersMapper : ISuppliersMapper
{
    public async Task<ReturnSuppliersDto> MapEntityToRetunDtoAsync(Suppliers supplier)
    {
        if (supplier == null) {  return null; }
        return new ReturnSuppliersDto
        {
            Id = supplier.Id,
            Name = supplier.Name,
            Email = supplier.Email,
            Phone = supplier.Phone
        };
    }

    public async Task<SupplierCreatedMessage> MapInputToCreatedMessageAsync(InputSupplierDto inputSupplier)
    {
        if (inputSupplier == null) { return null; }
        return new SupplierCreatedMessage
        {
            Name = inputSupplier.Name,
            Email = inputSupplier.Email,
            Phone = inputSupplier.Phone
        };
    }
}
