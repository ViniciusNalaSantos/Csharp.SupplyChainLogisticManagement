using Csharp.SupplyChainLogisticManagement.Application.Commands.CreateProduct;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Commands.CreateOrderItem;
public record CreateOrderItemCommand
{
    public Guid MessageId { get; set; }
    public int? ProductId { get; set; }
    public CreateProductCommand Product { get; set; }
    public decimal Quantity { get; set; }
}
