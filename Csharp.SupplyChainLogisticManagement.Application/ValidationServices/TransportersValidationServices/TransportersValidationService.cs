using Csharp.SupplyChainLogisticManagement.Application.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.ValidationServices.TransportersValidationServices;
public class TransportersValidationService : ITransportersValidationService
{
    public async Task ValidateTransporterCreatedMessageAsync(TransporterCreatedMessage message)
    {
        if (message.Name.Length > 200)
        {
            throw new Exception("The field Name has a limit of 200 characters");
        }

        if (message.Email.Length > 250)
        {
            throw new Exception("The field email has a limit of 25 characters");
        }

        if (message.Phone.Length > 25)
        {
            throw new Exception("The field phone has a limit of 200 characters");
        }
    }
}
