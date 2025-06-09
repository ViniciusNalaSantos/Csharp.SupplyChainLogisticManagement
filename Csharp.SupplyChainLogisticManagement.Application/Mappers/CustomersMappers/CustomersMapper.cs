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
public class CustomersMapper : ICustomersMapper
{
    public async Task<ReturnCustomersDto> MapEntityToRetunDtoAsync(Customers customer)
    {
        if (customer == null) {  return null; }
        return new ReturnCustomersDto
        {
            Id = customer.Id,
            Name = customer.Name,
            Address = customer.Address,
            Email = customer.Email
        };
    }

    public async Task<CustomerCreatedMessage> MapInputToCreatedMessageAsync(InputCustomerDto inputCustomer)
    {
        if (inputCustomer == null) { return null; }
        return new CustomerCreatedMessage
        {
            Name = inputCustomer.Name,
            Address = inputCustomer.Address,
            Email = inputCustomer.Email
        };
    }
}
