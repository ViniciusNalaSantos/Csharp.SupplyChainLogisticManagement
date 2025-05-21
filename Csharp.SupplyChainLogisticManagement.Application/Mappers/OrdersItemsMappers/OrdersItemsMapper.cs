using Csharp.SupplyChainLogisticManagement.Application.DTOs;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.ProductsMappers;
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
    public async Task<ICollection<OrdersItemsReturnDto>> MapEntityToRetunDtoAsync(ICollection<OrdersItems> listOrderItems)
    {
        var returnListOrderItems = new List<OrdersItemsReturnDto>();
        foreach (var orderItem in listOrderItems)
        {
            returnListOrderItems.Add(
                new OrdersItemsReturnDto
                {
                    Product = await _productsMapper.MapEntityToRetunDtoAsync(orderItem.Products),
                    Quantity = orderItem.Quantity
                }
            );
        }
        return returnListOrderItems;
    }
}
