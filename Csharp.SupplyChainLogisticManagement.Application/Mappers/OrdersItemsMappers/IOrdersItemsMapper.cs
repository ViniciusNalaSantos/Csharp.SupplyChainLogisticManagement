using Csharp.SupplyChainLogisticManagement.Application.DTOs;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Mappers.OrdersItemsMappers;
public interface IOrdersItemsMapper
{
    public Task<ICollection<OrdersItemsReturnDto>> MapEntityToRetunDtoAsync(ICollection<OrdersItems> listOrderItems);
}
