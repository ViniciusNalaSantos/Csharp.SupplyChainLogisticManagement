using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Services.CreateCustomerService;
public class CreateCustomerService : ICreateCustomerService
{
    public async Task<Customers> ReturnCustomerMappedFromMessage(CustomerCreatedMessage message)
    {
        var customer = new Customers
        {
            Name = message.Name,
            Email = message.Email,
            Address = message.Address
        };
        return customer;
    }
}
