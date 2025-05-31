using Csharp.SupplyChainLogisticManagement.Application.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.ValidationServices.DeliveriesValidationServices;
public class DeliveriesValidationService : IDeliveriesValidationService
{
    private readonly IValidationErrorCollector _validationErrorCollector;
    public DeliveriesValidationService(IValidationErrorCollector validationErrorCollector)
    {
        _validationErrorCollector = validationErrorCollector;
    }
    public async Task ValidateDeliveryCreatedMessageAsync(DeliveryCreatedMessage message)
    {
        return;
    }
}
