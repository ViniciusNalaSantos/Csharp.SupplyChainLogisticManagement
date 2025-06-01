using Csharp.SupplyChainLogisticManagement.Application.DTOs.InputDTOs;
using Csharp.SupplyChainLogisticManagement.Application.DTOs.ReturnDTOs;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Mappers.OrdersMappers;
public interface IOrdersMapper
{
    public Task<ICollection<ReturnOrdersDto>> MapEntityToRetunDtoAsync(ICollection<Orders> listOrders);
    public Task<ICollection<OrderCreatedMessage>> MapInputToCreatedMessageAsync(ICollection<InputOrderDto> listInputOrder);
}
