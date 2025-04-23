using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Messages;
public record OrderCreatedMessage
{
    public Guid MessageId { get; init; } = Guid.NewGuid();
    public int OrdersItemsId { get; set; }
    public DateTime EmissionDate { get; set; }
    public int? CustomersId { get; set; }
    public int? SuppliersId { get; set; }
    public decimal Price { get; set; }
}
