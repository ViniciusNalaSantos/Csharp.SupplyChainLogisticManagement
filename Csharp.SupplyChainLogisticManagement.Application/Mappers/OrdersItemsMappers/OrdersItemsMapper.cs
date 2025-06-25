using Csharp.SupplyChainLogisticManagement.Application.DTOs.InputDTOs;
using Csharp.SupplyChainLogisticManagement.Application.DTOs.ReturnDTOs;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.ProductsMappers;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Mappers.OrdersItemsMappers;
public class OrdersItemsMapper : IOrdersItemsMapper
{
    private readonly IProductsMapper _productsMapper;
    public OrdersItemsMapper(IProductsMapper productsMapper)
    {
        _productsMapper = productsMapper;
    }
    public async Task<ICollection<ReturnOrderItemsDto>> MapEntityToRetunDtoAsync(ICollection<OrdersItems> listOrderItems)
    {
        if (listOrderItems == null) { return new List<ReturnOrderItemsDto>(); }
        var returnListOrderItems = new List<ReturnOrderItemsDto>();
        foreach (var orderItem in listOrderItems)
        {
            returnListOrderItems.Add(
                new ReturnOrderItemsDto
                {
                    Product = await _productsMapper.MapEntityToRetunDtoAsync(orderItem.Products),
                    Quantity = orderItem.Quantity
                }
            );
        }
        return returnListOrderItems;
    }

    public async Task<ICollection<OrderItemsCreatedMessage>> MapInputToCreatedMessageAsync(ICollection<InputOrderItemsDto> inputOrderItems)
    {
        if (inputOrderItems == null) { return new List<OrderItemsCreatedMessage>(); }
        var returnListOrderItems = new List<OrderItemsCreatedMessage>();
        foreach (var orderItem in inputOrderItems)
        {
            returnListOrderItems.Add(
                new OrderItemsCreatedMessage
                {
                    ProductId = orderItem.ProductId,
                    Product = await _productsMapper.MapInputToCreatedMessageAsync(orderItem.Product),
                    Quantity = orderItem.Quantity
                }
            );
        }
        return returnListOrderItems;
    }
}
