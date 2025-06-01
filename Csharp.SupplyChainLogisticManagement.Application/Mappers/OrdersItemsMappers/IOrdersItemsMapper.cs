using Csharp.SupplyChainLogisticManagement.Application.DTOs.InputDTOs;
using Csharp.SupplyChainLogisticManagement.Application.DTOs.ReturnDTOs;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Mappers.OrdersItemsMappers;
public interface IOrdersItemsMapper
{
    public Task<ICollection<ReturnOrdersItemsDto>> MapEntityToRetunDtoAsync(ICollection<OrdersItems> listOrderItems);
    public Task<ICollection<OrderItemsCreatedMessage>> MapInputToCreatedMessageAsync(ICollection<InputOrderItemsDto> inputOrderItems);
}
