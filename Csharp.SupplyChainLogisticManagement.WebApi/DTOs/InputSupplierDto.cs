namespace Csharp.SupplyChainLogisticManagement.WebApi.DTOs;

public record InputSupplierDto
{
    public string Name { get; init; }
    public string Email { get; init; }
    public string Phone { get; init; }
}