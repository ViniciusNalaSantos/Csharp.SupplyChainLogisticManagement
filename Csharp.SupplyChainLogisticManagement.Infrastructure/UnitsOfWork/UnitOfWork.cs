using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;
using Csharp.SupplyChainLogisticManagement.Infrastructure.DatabaseContext;
using Csharp.SupplyChainLogisticManagement.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.UnitsOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly LogiChainDbContext _context;
    private readonly IServiceProvider _serviceProvider;
    public IOrdersRepository OrdersRepository => _serviceProvider.GetRequiredService<IOrdersRepository>();
    public IOrdersItemsRepository OrdersItemsRepository => _serviceProvider.GetRequiredService<IOrdersItemsRepository>();
    public ICustomersRepository CustomersRepository => _serviceProvider.GetRequiredService<ICustomersRepository>();
    public ISuppliersRepository SuppliersRepository => _serviceProvider.GetRequiredService<ISuppliersRepository>();
    public IDeliveriesRepository DeliveriesRepository => _serviceProvider.GetRequiredService<IDeliveriesRepository>();
    public IProductsRepository ProductsRepository => _serviceProvider.GetRequiredService<IProductsRepository>();
    public IShipmentsRepository ShipmentsRepository => _serviceProvider.GetRequiredService<IShipmentsRepository>();
    public ITransportersRepository TransportersRepository => _serviceProvider.GetRequiredService<ITransportersRepository>();
    
    public UnitOfWork(LogiChainDbContext context, IServiceProvider serviceProvider)
    {
        _context = context;
        _serviceProvider = serviceProvider;
    }
    public async Task<int> CommitAsync() => _context.SaveChanges();
    public void Dispose() => _context.Dispose();
}
