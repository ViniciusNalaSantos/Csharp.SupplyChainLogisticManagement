namespace Csharp.SupplyChainLogisticManagement.Application.DTOs.InputDTOs;

public record InputProductDto
{
    public string Description { get; init; }
    public decimal Price { get; init; }
}