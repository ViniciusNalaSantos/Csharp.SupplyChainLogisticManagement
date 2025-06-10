using Csharp.SupplyChainLogisticManagement.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.ValidationServices;
public interface IValidationErrorCollector
{
    void Add(ValidationErrorDto validationError);
    List<ValidationErrorDto> GetErrors();
}
