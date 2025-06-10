using Csharp.SupplyChainLogisticManagement.Application.Exceptions;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.ValidationServices.TransportersValidationServices;
public class TransportersValidationService : ITransportersValidationService
{
    private readonly IValidationErrorCollector _validationErrorCollector;
    public TransportersValidationService(IValidationErrorCollector validationErrorCollector)
    {
        _validationErrorCollector = validationErrorCollector;
    }
    public async Task ValidateTransporterCreatedMessageAsync(TransporterCreatedMessage message, string orderNumber)
    {
        if (message == null) { return; }

        if (message.Name.Length > 200)
        {
            _validationErrorCollector.Add(new ValidationErrorDto(orderNumber, "The field Name has a limit of 200 characters"));
        }

        if (message.Email.Length > 250)
        {
            _validationErrorCollector.Add(new ValidationErrorDto(orderNumber, "The field email has a limit of 25 characters"));
        }

        if (message.Phone.Length > 25)
        {
            _validationErrorCollector.Add(new ValidationErrorDto(orderNumber, "The field phone has a limit of 200 characters"));
        }
    }
}
