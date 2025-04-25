using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Messages;
public record SupplierCreatedMessage
{
    public Guid MessageId { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Phone { get; set; }
}
