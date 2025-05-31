namespace Csharp.SupplyChainLogisticManagement.WebApi.Middlewares;

public class ReturnErrorDetails
{
    public string Title { get; set; } = "An unexpected error occurred.";
    public int Status { get; set; } = 500;
    public string Detail { get; set; }
    public string Instance { get; set; }
    public List<string> Errors { get; set; } = new List<string>();
}
