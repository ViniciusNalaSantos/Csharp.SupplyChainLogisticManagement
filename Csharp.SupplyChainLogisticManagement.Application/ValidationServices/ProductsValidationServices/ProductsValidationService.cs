using Csharp.SupplyChainLogisticManagement.Application.Exceptions;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.ValidationServices.ProductsValidationServices;
public class ProductsValidationService : IProductsValidationService
{
    private readonly IValidationErrorCollector _validationErrorCollector;
    public ProductsValidationService(IValidationErrorCollector validationErrorCollector)
    {
        _validationErrorCollector = validationErrorCollector;
    }
    public async Task ValidateProducCreatedMessageAsync(ProductCreatedMessage message, string orderNumber)
    {
        if (message == null) { return; }

        if (message.Description.Length > 200)
        {
            _validationErrorCollector.Add(new ValidationErrorDto(orderNumber, "The field Description has a limit of 200 characters."));
        }
        if (message.Price < 0)
        {
            _validationErrorCollector.Add(new ValidationErrorDto(orderNumber, "A product cannot have a negative price."));
        }
    }
}
