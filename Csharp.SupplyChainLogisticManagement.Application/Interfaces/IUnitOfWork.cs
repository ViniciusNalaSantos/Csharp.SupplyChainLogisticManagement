using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Interfaces;
public interface IUnitOfWork
{
    public IOrdersRepository OrdersRepository { get; }
    public IOrdersItemsRepository OrdersItemsRepository { get; }
    public ICustomersRepository CustomersRepository { get; }
    public ISuppliersRepository SuppliersRepository { get; }
    public IDeliveriesRepository DeliveriesRepository { get; }
    public IProductsRepository ProductsRepository { get; }
    public IShipmentsRepository ShipmentsRepository { get; }
    public ITransportersRepository TransportersRepository { get; }
    public Task<int> CommitAsync();
    public void Dispose();
}
