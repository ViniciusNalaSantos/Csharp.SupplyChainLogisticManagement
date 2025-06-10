using Csharp.SupplyChainLogisticManagement.Application.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.ValidationServices.ShipmentValidationServices;
public class ShipmentValidationService : IShipmentValidationService
{
    private readonly IValidationErrorCollector _validationErrorCollector;
    public ShipmentValidationService(IValidationErrorCollector validationErrorCollector)
    {
        _validationErrorCollector = validationErrorCollector;
    }
    public async Task ValidateShipmentCreatedMessageAsync(ShipmentCreatedMessage message, string orderNumber    )
    {
        return;
    }
}
