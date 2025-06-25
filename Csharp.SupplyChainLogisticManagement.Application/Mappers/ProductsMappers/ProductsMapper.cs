using Csharp.SupplyChainLogisticManagement.Application.DTOs.InputDTOs;
using Csharp.SupplyChainLogisticManagement.Application.DTOs.ReturnDTOs;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Mappers.ProductsMappers;
public class ProductsMapper : IProductsMapper
{
    public async Task<ReturnProductsDto> MapEntityToRetunDtoAsync(Products product)
    {
        if (product == null) { return null; }
        return new ReturnProductsDto
        {
            Id = product.Id,
            Description = product.Description,
            Price = product.Price
        };
    }

    public async Task<ProductCreatedMessage> MapInputToCreatedMessageAsync(InputProductDto inputProduct)
    {
        if (inputProduct == null) { return null; }
        return new ProductCreatedMessage
        {
            Description = inputProduct.Description,
            Price = inputProduct.Price
        };
    }
}
