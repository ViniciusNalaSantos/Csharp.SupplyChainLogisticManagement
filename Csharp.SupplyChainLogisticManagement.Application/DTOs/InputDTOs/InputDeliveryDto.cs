namespace Csharp.SupplyChainLogisticManagement.Application.DTOs.InputDTOs;

public record InputDeliveryDto
{
    public int? TransporterId { get; set; }
    public DateTime DeliveryDate { get; set; }
    public InputTransporterDto? Transporter { get; set; }
}