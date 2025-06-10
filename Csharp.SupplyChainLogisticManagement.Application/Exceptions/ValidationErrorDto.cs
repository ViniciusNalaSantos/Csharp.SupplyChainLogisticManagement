using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Exceptions;
public record ValidationErrorDto
{
    public string OrderNumber { get; set; }
    public string Message { get; set; }
    public ValidationErrorDto(string orderNumber, string message)
    {
        this.OrderNumber = orderNumber;
        this.Message = message;
    }
}
