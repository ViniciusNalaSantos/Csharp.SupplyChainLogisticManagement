using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Messages;
public record OrderItemCreatedMessage
{
    public Guid MessageId { get; set; } = Guid.NewGuid();
    public int? ProductId { get; set; }
    public ProductCreatedMessage Product { get; set; }
    public decimal Quantity { get; set; }
}
