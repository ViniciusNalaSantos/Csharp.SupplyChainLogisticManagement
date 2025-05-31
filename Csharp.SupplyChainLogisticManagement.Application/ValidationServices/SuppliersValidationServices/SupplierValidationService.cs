using Csharp.SupplyChainLogisticManagement.Application.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.ValidationServices.SuppliersValidationServices;
public class SupplierValidationService : ISuppliersValidationService
{
    private readonly IValidationErrorCollector _validationErrorCollector;
    public SupplierValidationService(IValidationErrorCollector validationErrorCollector)
    {
        _validationErrorCollector = validationErrorCollector;
    }
    public async Task ValidateSupplierCreatedMessageAsync(SupplierCreatedMessage message)
    {
        if (message == null) { return; }

        if (message.Name.Length > 200)
        {
            _validationErrorCollector.Add("The field Name has a limit of 200 characters");
        }

        if (message.Email.Length > 250)
        {
            _validationErrorCollector.Add("The field address has a limit of 250 characters");
        }

        if (message.Phone.Length > 25)
        {
            _validationErrorCollector.Add("The field address has a limit of 200 characters");
        }
    }
}
