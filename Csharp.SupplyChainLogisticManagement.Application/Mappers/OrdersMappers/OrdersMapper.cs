using Csharp.SupplyChainLogisticManagement.Application.DTOs;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.CustomersMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.DeliveriesMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.OrdersItemsMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.ShipmentsMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.SuppliersMappers;
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
    public async Task<ICollection<OrdersReturnDto>> MapEntityToRetunDtoAsync(ICollection<Orders> listOrders)
    {
        var returnListOrders = new List<OrdersReturnDto>();
        foreach (var order in listOrders)
        {
            returnListOrders.Add(
                new OrdersReturnDto
                {
                    Customer = await _customersMapper.MapEntityToRetunDtoAsync(order.Customers),
                    Supplier = await _suppliersMapper.MapEntityToRetunDtoAsync(order.Suppliers),
                    EmissionDate = order.EmissionDate,
                    Price = order.Price,
                    OrderItems = await _ordersItemsMapper.MapEntityToRetunDtoAsync(order.OrdersItems),
                    Shipments = await _shipmentsMapper.MapEntityToRetunDtoAsync(order.Shipments.FirstOrDefault()),
                    Deliveries = await _deliveriesMapper.MapEntityToRetunDtoAsync(order.Deliveries.FirstOrDefault()),
                }
            );
        };
        return returnListOrders;
    }
}
