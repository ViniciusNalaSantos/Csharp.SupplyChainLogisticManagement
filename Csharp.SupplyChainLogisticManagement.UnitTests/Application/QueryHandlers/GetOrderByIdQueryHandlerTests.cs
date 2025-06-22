using Csharp.SupplyChainLogisticManagement.Application.QueryHandlers;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.UnitTests.Application.QueryHandlers;
public sealed class GetOrderByIdQueryHandlerTests
{
    private readonly GetOrderByIdQueryHandler _handler;
    private readonly IOrdersRepository _mockOrdersRepository;
    public GetOrderByIdQueryHandlerTests()
    {        
        _mockOrdersRepository = Substitute.For<IOrdersRepository>();
        _handler = new GetOrderByIdQueryHandler(_mockOrdersRepository);
    }

    [Fact]
    public Task GivenQuery_ThenReturnCorrectOrder()
    {
        // Arrange
        var anyOrder = AnOrder();
        // Act
        // Assert
    }
    private Orders AnOrder()
    {
        return new Orders
        {
            Id = 123,
            OrderNumber = "ORD-001",
            EmissionDate = new DateTime(2024, 6, 1),
            CustomersId = 10,
            Customers = new Customers { Id = 10, Name = "ACME Corp" },
            //SuppliersId = 20,
            //Suppliers = new Suppliers { Id = 20, Name = "Global Supplies" },
            Price = 1500.00m,
            OrdersItems = new List<OrdersItems>
            {
                new OrdersItems 
                { 
                    OrdersId = 123,
                    ProductsId = 456,
                    Quantity = 5,
                    Products = new Products
                    {
                        Id = 456,
                        Description = "Widget A",
                        Price = 100m
                    }
                }
            },
            Shipments = new List<Shipments>
            {
                new Shipments
                {
                    Id = 1,
                    ShipmentDate = DateTime.Today
                }
            },
            Deliveries = new List<Deliveries>
            {
                new Deliveries 
                {
                    Id = 1,
                    OrdersId = 123,
                    TransportersId = 99,
                    Transporters = new Transporters { Id = 99, Name = "Fast Transport Inc." },
                    DeliveryDate = DateTime.Today.AddDays(3)
                }
            }
        }
    }
}
