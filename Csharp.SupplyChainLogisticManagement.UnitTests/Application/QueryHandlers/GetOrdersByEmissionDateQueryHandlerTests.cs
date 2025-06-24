using Csharp.SupplyChainLogisticManagement.Application.Queries;
using Csharp.SupplyChainLogisticManagement.Application.QueryHandlers;
using Csharp.SupplyChainLogisticManagement.Domain.Dto;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;
using Csharp.SupplyChainLogisticManagement.UnitTests.TestUtils.Builders;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.UnitTests.Application.QueryHandlers;
public sealed class GetOrdersByEmissionDateQueryHandlerTests
{
    private readonly GetOrdersByEmissionDateQueryHandler _handler;
    private readonly IOrdersRepository _mockOrdersRepository;
    public GetOrdersByEmissionDateQueryHandlerTests()
    {
        _mockOrdersRepository = Substitute.For<IOrdersRepository>();
        _handler = new GetOrdersByEmissionDateQueryHandler(_mockOrdersRepository);
    }

    [Fact]
    public async Task Handle_ShouldReturnPagedOrders_WhenOrdersExists()
    {
        // Arrange
        var expectedPagedOrders = APagedOrders();
        _mockOrdersRepository
            .GetOrdersPagedByEmissionDate(Arg.Any<DateTime>(), Arg.Any<DateTime>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(Task.FromResult(expectedPagedOrders));
        var expectedEmissionDateStart = DateTime.Now.AddMonths(-3);
        var expectedEmissionDateEnd = DateTime.Now.AddMonths(3);
        var query = new GetOrdersByEmissionDateQuery
        {
            EmissionDateStart = expectedEmissionDateStart,
            EmissionDateEnd = expectedEmissionDateEnd
        };

        // Act
        var result = await _handler.Handle(query);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.ListResultsCount);        
    }    

    private PagedResultDto<Orders> APagedOrders()
    {
        var emissionDate = DateTime.Now;
        
        var listOrders = new List<Orders>();        
        listOrders.Add(new OrdersBuilder().WithEmissionDate(emissionDate.AddMonths(-2)).Build());
        listOrders.Add(new OrdersBuilder().WithEmissionDate(emissionDate.AddMonths(2)).Build());       

        return new PagedResultDto<Orders>
        {
            ListResults = listOrders,
            ListResultsCount = listOrders.Count,
            TotalPages = 1
        };
    }
}
