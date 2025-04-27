using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Messages;
public record OrderItemCreatedMessage
{
    public Guid MessageId { get; set; } = Guid.NewGuid();
    public int? Id { get; set; }
    public ProductCreatedMessage Product { get; set; }
    public int Quantity { get; set; }
}
