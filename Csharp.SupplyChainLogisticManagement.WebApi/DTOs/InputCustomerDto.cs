namespace Csharp.SupplyChainLogisticManagement.WebApi.DTOs;

public record InputCustomerDto
{
    public string Name { get; init; }
    public string Email { get; init; }
    public string Address { get; init; }
}