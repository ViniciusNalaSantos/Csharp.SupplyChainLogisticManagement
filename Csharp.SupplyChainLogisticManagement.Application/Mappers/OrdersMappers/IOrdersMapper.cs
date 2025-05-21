using Csharp.SupplyChainLogisticManagement.Application.DTOs;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Mappers.OrdersMappers;
public interface IOrdersMapper
{
    public Task<ICollection<OrdersReturnDto>> MapEntityToRetunDtoAsync(ICollection<Orders> listOrders);
}
