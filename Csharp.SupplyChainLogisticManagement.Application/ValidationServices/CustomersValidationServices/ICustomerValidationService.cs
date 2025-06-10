using Csharp.SupplyChainLogisticManagement.Application.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.ValidationServices.CustomersValidationServices;
public interface ICustomerValidationService
{
    public Task ValidateCustomerCreatedMessageAsync(CustomerCreatedMessage message, string orderNumber);
}
