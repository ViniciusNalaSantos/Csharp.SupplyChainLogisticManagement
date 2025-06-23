using Csharp.SupplyChainLogisticManagement.Application.Queries;
using Csharp.SupplyChainLogisticManagement.Application.QueryHandlers;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;
using Csharp.SupplyChainLogisticManagement.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    public async Task Handle_ShouldReturnCorrectOrder_WhenOrderExists()
    {
        // Arrange
        var expectedOrder = AnOrder();     
        _mockOrdersRepository
            .GetOrderFirstOrDefaultAsync(Arg.Any<Expression<Func<Orders, bool>>>())
            .Returns(Task.FromResult(expectedOrder));
        var handler = new GetOrderByIdQueryHandler(_mockOrdersRepository);

        // Act
        var result = await handler.Handle(new GetOrderByIdQuery { Id = 123 });

        // Assert
        Assert.Single(result);
        Assert.Equal("ORD-001", result.First()?.OrderNumber);
    }

    [Fact]
    public async Task Handle_ShouldReturnEmptyList_WhenOrderDoesNotExist()
    {
        // Arrange
        _mockOrdersRepository
            .GetOrderFirstOrDefaultAsync(Arg.Any<Expression<Func<Orders, bool>>>())
            .Returns((Orders?)null);
        var query = new GetOrderByIdQuery { Id = 999 };

        // Act
        var result = await _handler.Handle(query);

        // Assert
        Assert.Empty(result);
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
        };
    }
}
