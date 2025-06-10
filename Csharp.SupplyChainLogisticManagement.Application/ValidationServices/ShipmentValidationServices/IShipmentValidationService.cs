using Csharp.SupplyChainLogisticManagement.Application.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.ValidationServices.ShipmentValidationServices;
public interface IShipmentValidationService
{
    public Task ValidateShipmentCreatedMessageAsync(ShipmentCreatedMessage message, string orderNumber);
}
