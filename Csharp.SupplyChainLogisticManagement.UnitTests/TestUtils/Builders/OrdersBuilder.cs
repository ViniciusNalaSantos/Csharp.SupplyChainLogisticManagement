using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

//[assembly: InternalsVisibleTo("Csharp.SupplyChainLogisticManagement.UnitTests")]

namespace Csharp.SupplyChainLogisticManagement.UnitTests.TestUtils.Builders;
internal class OrdersBuilder
{
    private Orders _order = new Orders
    {
        Id = 123,
        OrderNumber = "ORD-001",
        EmissionDate = DateTime.Today,
        Price = 1500m,
        OrdersItems = new List<OrdersItems>(),
        Deliveries = new List<Deliveries>(),
        Shipments = new List<Shipments>()
    };

    public OrdersBuilder WithId(int id)
    {
        _order.Id = id;
        return this;
    }

    public OrdersBuilder WithCustomer(string name)
    {
        _order.Customers = new Customers { Id = 1, Name = name };
        return this;
    }

    public OrdersBuilder WithItem(string product, decimal quantity, decimal price)
    {
        _order.OrdersItems.Add(new OrdersItems
        {
            Quantity = quantity,
            Products = new Products { Description = product, Price = price }
        });
        return this;
    }

    public OrdersBuilder WithEmissionDate(DateTime emissionDate)
    {
        _order.EmissionDate = emissionDate;
        return this;
    }

    public Orders Build() => _order;
}
