namespace Csharp.SupplyChainLogisticManagement.Application.DTOs.InputDTOs;

public record InputCustomerDto
{
    public string Name { get; init; }
    public string Email { get; init; }
    public string Address { get; init; }
}