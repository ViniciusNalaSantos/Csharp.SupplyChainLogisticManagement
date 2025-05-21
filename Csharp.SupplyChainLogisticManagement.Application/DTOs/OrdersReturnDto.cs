using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.DTOs;
public record OrdersReturnDto
{
    public int Id { get; set; }
    public DateTime EmissionDate { get; set; }
    public CustomersReturnDto Customer { get; set; }
    public SuppliersReturnDto Supplier { get; set; }
    public decimal Price { get; set; }
    public ICollection<OrdersItemsReturnDto> OrderItems { get; set; }
    public ShipmentsReturnDto Shipments { get; set; }
    public DeliveriesReturnDto Deliveries { get; set; }
}
