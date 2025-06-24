using Csharp.SupplyChainLogisticManagement.Application.Interfaces;
using Csharp.SupplyChainLogisticManagement.Application.MessageHandlers;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Infrastructure.UnitsOfWork;
using Csharp.SupplyChainLogisticManagement.UnitTests.TestUtils.Builders;
using Microsoft.EntityFrameworkCore.Storage;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.UnitTests.Application.MessageHandlers;
public class CreateOrderMessageHandlerTests
{
    private readonly IUnitOfWork _mockUnitOfWork;
    private readonly IDbContextTransaction _mockContext;
    public CreateOrderMessageHandlerTests()
    {
        _mockUnitOfWork = Substitute.For<IUnitOfWork>();
        _mockContext = Substitute.For<IDbContextTransaction>();
        _mockUnitOfWork.BeginTransactionAsync().Returns(Task.FromResult(_mockContext));

    }

    // TODO: finish developing this test
    //[Fact]
    public async Task Handle_ShouldCommitTransaction_WhenOrderIsCreatedSuccessfully()
    {
        // Arrange
        var expectedCustomer = new Customers { Id = 1, Name = "CustomerX" };
        var message = new OrderCreatedMessageBuilder()
            .WithOrderNumber("ORD-999")
            .WithEmissionDate(DateTime.Today)
            .WithCustomer()            
            .AddOrderItem("Widget B", 200, 3)            
            .WithDelivery()
            .Build();

        // Setup repos to return expected results
        _mockUnitOfWork.CustomersRepository
            .GetCustomerFirstOrDefaultAsync(Arg.Any<Expression<Func<Customers, bool>>>())
            .Returns((Customers?)null);

        _mockUnitOfWork.CustomersRepository
            .InsertCustomerAsync(Arg.Any<Customers>())
            .Returns(Task.FromResult(new Customers { Id = 1 }));

        _mockUnitOfWork.OrdersRepository
            .InsertOrderAsync(Arg.Any<Orders>())
            .Returns(Task.FromResult(new Orders { Id = 123 }));

        _mockUnitOfWork.ProductsRepository
            .GetProductFirstOrDefaultAsync(Arg.Any<Expression<Func<Products, bool>>>())
            .Returns((Products?)null);

        _mockUnitOfWork.ProductsRepository
            .InsertProductAsync(Arg.Any<Products>())
            .Returns(Task.FromResult(new Products { Id = 456 }));

        _mockUnitOfWork.OrdersItemsRepository
            .InsertOrderItemAsync(Arg.Any<OrdersItems>())
            .Returns(Task.FromResult(new OrdersItems { OrdersId = 123, ProductsId = 456 }));

        var handler = new CreateOrderMessageHandler(_mockUnitOfWork);

        // Act
        await handler.Handle(message);

        // Assert
        await _mockContext.Received(1).CommitAsync();
        await _mockContext.DidNotReceive().RollbackAsync();
    }
}
