using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.ValidationServices;
public class ValidationErrorCollector : IValidationErrorCollector
{
    private readonly List<string> _errors = new();
    public void Add(string message)
    {
        _errors.Add(message);
    }
    public List<string> GetErrors() => _errors;
}
