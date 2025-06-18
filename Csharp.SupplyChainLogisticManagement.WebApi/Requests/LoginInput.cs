namespace Csharp.SupplyChainLogisticManagement.WebApi.Requests;

public record LoginInput
{
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}
