namespace Csharp.SupplyChainLogisticManagement.WebApi.DTOs;

public record InputProductDto
{
    public string Description { get; init; }
    public decimal Price { get; init; }
}