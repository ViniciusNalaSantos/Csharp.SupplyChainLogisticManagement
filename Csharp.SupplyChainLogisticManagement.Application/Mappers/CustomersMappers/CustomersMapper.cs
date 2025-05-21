using Csharp.SupplyChainLogisticManagement.Application.DTOs;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Mappers.CustomersMappers;
public class CustomersMapper : ICustomersMapper
{
    public async Task<CustomersReturnDto> MapEntityToRetunDtoAsync(Customers customer)
    {
        return new CustomersReturnDto
        {
            Id = customer.Id,
            Name = customer.Name,
            Address = customer.Address,
            Email = customer.Email
        };
    }
}
