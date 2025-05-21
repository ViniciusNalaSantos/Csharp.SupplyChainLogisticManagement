using Csharp.SupplyChainLogisticManagement.Application.DTOs;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Mappers.ProductsMappers;
public class ProductsMapper : IProductsMapper
{
    public async Task<ProductsReturnDto> MapEntityToRetunDtoAsync(Products product)
    {
        return new ProductsReturnDto
        {
            Id = product.Id,
            Description = product.Description,
            Price = product.Price
        };
    }
}
