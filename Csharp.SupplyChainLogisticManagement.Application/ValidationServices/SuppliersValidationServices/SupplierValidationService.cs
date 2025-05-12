using Csharp.SupplyChainLogisticManagement.Application.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.ValidationServices.SuppliersValidationServices;
public class SupplierValidationService : ISuppliersValidationService
{
    public async Task ValidateSupplierCreatedMessageAsync(SupplierCreatedMessage message)
    {
        if (message.Name.Length > 200)
        {
            throw new Exception("The field Name has a limit of 200 characters");
        }

        if (message.Email.Length > 250)
        {
            throw new Exception("The field address has a limit of 250 characters");
        }

        if (message.Phone.Length > 25)
        {
            throw new Exception("The field address has a limit of 200 characters");
        }
    }
}
