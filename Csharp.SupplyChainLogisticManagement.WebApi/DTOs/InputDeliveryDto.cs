
namespace Csharp.SupplyChainLogisticManagement.WebApi.DTOs;

public record InputDeliveryDto
{
    public int? TransporterId { get; set; }
    public DateTime DeliveryDate { get; set; }
    public InputTransporterDto? Transporter { get; set; }
}