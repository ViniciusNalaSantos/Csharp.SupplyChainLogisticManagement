using Csharp.SupplyChainLogisticManagement.Application.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.ValidationServices.ProductsValidationServices;
public interface IProductsValidationService
{
    public Task ValidateProducCreatedMessageAsync(ProductCreatedMessage message);
}
