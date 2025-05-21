using Csharp.SupplyChainLogisticManagement.Application.DTOs;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Mappers.CustomersMappers;
public interface ICustomersMapper
{
    public Task<CustomersReturnDto> MapEntityToRetunDtoAsync(Customers customer);
}
