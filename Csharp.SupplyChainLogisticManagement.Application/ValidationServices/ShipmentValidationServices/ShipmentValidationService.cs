using Csharp.SupplyChainLogisticManagement.Application.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.ValidationServices.ShipmentValidationServices;
internal class ShipmentValidationService : IShipmentValidationService
{
    public async Task ValidateShipmentCreatedMessageAsync(ShipmentCreatedMessage message)
    {
        throw new NotImplementedException();
    }
}
