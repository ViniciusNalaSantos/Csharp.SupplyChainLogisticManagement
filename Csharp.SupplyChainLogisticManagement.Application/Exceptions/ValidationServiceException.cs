using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Exceptions;
public class ValidationServiceException : Exception
{
    public string Title { get; } = "One or more validation errors occurred.";
    public List<ValidationErrorDto> Errors { get; } = new List<ValidationErrorDto>();
    public ValidationServiceException(IEnumerable<ValidationErrorDto> errors) : base() 
    {
        Errors = errors.ToList();
    }
}
