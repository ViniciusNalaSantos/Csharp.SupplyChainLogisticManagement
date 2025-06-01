using Csharp.SupplyChainLogisticManagement.Application.DTOs.InputDTOs;
using Csharp.SupplyChainLogisticManagement.Application.DTOs.ReturnDTOs;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Mappers.CustomersMappers;
public interface ICustomersMapper
{
    public Task<ReturnCustomersDto> MapEntityToRetunDtoAsync(Customers customer);
    public Task<CustomerCreatedMessage> MapInputToCreatedMessageAsync(InputCustomerDto inputCustomer);
}
