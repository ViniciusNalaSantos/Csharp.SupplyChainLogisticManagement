using Csharp.SupplyChainLogisticManagement.Application.DTOs;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Mappers.SuppliersMappers;
public class SuppliersMapper : ISuppliersMapper
{
    public async Task<SuppliersReturnDto> MapEntityToRetunDtoAsync(Suppliers supplier)
    {
        return new SuppliersReturnDto
        {
            Id = supplier.Id,
            Name = supplier.Name,
            Email = supplier.Email,
            Phone = supplier.Phone
        };
    }
}
