using Csharp.SupplyChainLogisticManagement.Application.Exceptions;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.ValidationServices.CustomersValidationServices;
public class CustomerValidationService : ICustomerValidationService
{
    private readonly IValidationErrorCollector _validationErrorCollector;
    public CustomerValidationService(IValidationErrorCollector validationErrorCollector)
    {
        _validationErrorCollector = validationErrorCollector;
    }
    public async Task ValidateCustomerCreatedMessageAsync(CustomerCreatedMessage message, string orderNumber)
    {
        if (message == null) { return; }

        if (message.Name.Length > 200)
        {
            _validationErrorCollector.Add(new ValidationErrorDto(orderNumber, "The field Name has a limit of 200 characters"));
        }

        if (message.Email.Length > 250)
        {
            _validationErrorCollector.Add(new ValidationErrorDto(orderNumber, "The field email has a limit of 250 characters"));
        }

        if (message.Address.Length > 200)
        {
            _validationErrorCollector.Add(new ValidationErrorDto(orderNumber, "The field address has a limit of 200 characters"));
        }
    }
}
