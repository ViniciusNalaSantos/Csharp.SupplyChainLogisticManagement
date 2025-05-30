using Csharp.SupplyChainLogisticManagement.Application.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.ValidationServices.ProductsValidationServices;
public class ProductsValidationService : IProductsValidationService
{
    public async Task ValidateProducCreatedMessageAsync(ProductCreatedMessage message)
    {
        if (message == null) { return; }

        if (message.Description.Length > 200)
        {
            throw new Exception("The field Description has a limit of 200 characters.");
        }
        if (message.Price < 0)
        {
            throw new Exception("A product cannot have a negative price.");
        }
    }
}
