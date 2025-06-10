using Csharp.SupplyChainLogisticManagement.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.ValidationServices;
public class ValidationErrorCollector : IValidationErrorCollector
{
    private readonly List<ValidationErrorDto> _errors = new List<ValidationErrorDto>();
    public void Add(ValidationErrorDto validationError)
    {
        _errors.Add(validationError);
    }
    public List<ValidationErrorDto> GetErrors() => _errors;
}
