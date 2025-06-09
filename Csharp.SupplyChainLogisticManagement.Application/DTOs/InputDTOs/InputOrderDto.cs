namespace Csharp.SupplyChainLogisticManagement.Application.DTOs.InputDTOs;

public record InputOrderDto
{
    public string OrderNumber { get; init; }
    public DateTime EmissionDate { get; init; }    
    public int? CustomerId { get; init; }
    public InputCustomerDto? Customer { get; init; }
    public int? SupplierId { get; init; }
    public InputSupplierDto? Supplier { get; init; }
    public decimal Price { get; init; }
    public ICollection<InputOrderItemsDto> OrderItems { get; init; } = new List<InputOrderItemsDto>();
    public InputDeliveryDto? Delivery { get; init; }
    public InputShipmentDto? Shipment { get; init; }
}
