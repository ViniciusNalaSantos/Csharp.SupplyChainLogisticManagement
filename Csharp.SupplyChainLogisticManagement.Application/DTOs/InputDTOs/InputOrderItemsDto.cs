
namespace Csharp.SupplyChainLogisticManagement.Application.DTOs.InputDTOs;

public record InputOrderItemsDto
{
    public int? ProductId { get; init; }
    public InputProductDto Product { get; init; }
    public decimal Quantity { get; init; }
}