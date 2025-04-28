using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Services.CreateCustomerService;
public interface ICreateCustomerService
{
    public Task<Customers> ReturnCustomerMappedFromMessage(CustomerCreatedMessage message);
}
