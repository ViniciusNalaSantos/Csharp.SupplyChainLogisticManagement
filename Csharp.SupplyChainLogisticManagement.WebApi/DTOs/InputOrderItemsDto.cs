using Csharp.SupplyChainLogisticManagement.Application.Messages;

namespace Csharp.SupplyChainLogisticManagement.WebApi.DTOs;

public record InputOrderItemsDto
{
    public int? ProductId { get; init; }
    public InputProductDto Product { get; init; }
    public decimal Quantity { get; init; }
}