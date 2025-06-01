using Csharp.SupplyChainLogisticManagement.Application.DTOs.InputDTOs;
using Csharp.SupplyChainLogisticManagement.Application.DTOs.ReturnDTOs;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.CustomersMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.DeliveriesMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.OrdersItemsMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.ShipmentsMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.SuppliersMappers;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Mappers.OrdersMappers;
public class OrdersMapper : IOrdersMapper
{
    private readonly ICustomersMapper _customersMapper;
    private readonly ISuppliersMapper _suppliersMapper;
    private readonly IOrdersItemsMapper _ordersItemsMapper;
    private readonly IShipmentsMapper _shipmentsMapper;
    private readonly IDeliveriesMapper _deliveriesMapper;
    public OrdersMapper(ICustomersMapper customersMapper, ISuppliersMapper suppliersMapper, IOrdersItemsMapper ordersItemsMapper,
        IShipmentsMapper shipmentsMapper, IDeliveriesMapper deliveriesMapper)
    {
        _customersMapper = customersMapper;
        _suppliersMapper = suppliersMapper;
        _ordersItemsMapper = ordersItemsMapper;
        _shipmentsMapper = shipmentsMapper;
        _deliveriesMapper = deliveriesMapper;
    }
    public async Task<ICollection<ReturnOrdersDto>> MapEntityToRetunDtoAsync(ICollection<Orders> listOrders)
    {
        var returnListOrders = new List<ReturnOrdersDto>();
        foreach (var order in listOrders)
        {
            var customerMapped = await _customersMapper.MapEntityToRetunDtoAsync(order.Customers);
            var supplierMapped = await _suppliersMapper.MapEntityToRetunDtoAsync(order.Suppliers);
            var orderitemsMapped = await _ordersItemsMapper.MapEntityToRetunDtoAsync(order.OrdersItems);
            var shipmentsMapped = await _shipmentsMapper.MapEntityToRetunDtoAsync(order.Shipments?.FirstOrDefault());
            var deliveriesMapped = await _deliveriesMapper.MapEntityToRetunDtoAsync(order.Deliveries?.FirstOrDefault());

            returnListOrders.Add(
                new ReturnOrdersDto
                {
                    Customer = customerMapped,
                    Supplier = supplierMapped,
                    EmissionDate = order.EmissionDate,
                    Price = order.Price,
                    OrderItems = orderitemsMapped,
                    Shipments = shipmentsMapped,
                    Deliveries = deliveriesMapped
                }
            );
        };
        return returnListOrders;
    }

    public async Task<ICollection<OrderCreatedMessage>> MapInputToCreatedMessageAsync(ICollection<InputOrderDto> listInputOrder)
    {
        var returnListOrders = new List<OrderCreatedMessage>();
        foreach (var order in listInputOrder)
        {
            returnListOrders.Add(
                new OrderCreatedMessage
                {
                    CustomerId = order.CustomerId,
                    Customer = await _customersMapper.MapInputToCreatedMessageAsync(order.Customer),
                    SupplierId = order.SupplierId,
                    Supplier = await _suppliersMapper.MapInputToCreatedMessageAsync(order.Supplier),
                    EmissionDate = order.EmissionDate,
                    Price = order.Price,
                    OrderItems = await _ordersItemsMapper.MapInputToCreatedMessageAsync(order.OrderItems),
                    Shipment = await _shipmentsMapper.MapInputToCreatedMessageAsync(order.Shipment),
                    Delivery = await _deliveriesMapper.MapInputToCreatedMessageAsync(order.Delivery),
                }
            );
        };
        return returnListOrders;
    }
}
