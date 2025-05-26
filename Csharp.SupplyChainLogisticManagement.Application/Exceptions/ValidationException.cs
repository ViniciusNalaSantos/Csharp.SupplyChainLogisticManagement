using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Exceptions;
public class ValidationException : Exception
{
    public List<string> Errors { get; } = new List<string>();
    public ValidationException(IEnumerable<string> errors) : base() 
    {
        Errors = errors.ToList();
    }
}
