﻿using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Csharp.SupplyChainLogisticManagement.Infrastructure.EventBus;
using Microsoft.AspNetCore.Mvc;
using Xunit.Sdk;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Application.Queries;
using Csharp.SupplyChainLogisticManagement.Application.Common.Constants;
using System.Drawing.Printing;
using System.Threading.Tasks;
using Csharp.SupplyChainLogisticManagement.Domain.Dto;
using Csharp.SupplyChainLogisticManagement.Application.ValidationServices.OrdersValidationServices;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.OrdersMappers;
using Csharp.SupplyChainLogisticManagement.Application.Interfaces.Handlers;
using Csharp.SupplyChainLogisticManagement.Application.DTOs.ReturnDTOs;

namespace Csharp.SupplyChainLogisticManagement.WebApi.Controllers;

[ApiController]
[Route("/logichain")]
public class LogiChainController : ControllerBase
{
    private readonly IEventBus _eventBus;
    private readonly IQueryHandler<GetOrderByIdQuery, ICollection<Orders>> _getOrderByIdQueryHandler;
    private readonly IQueryHandler<GetOrdersByEmissionDateQuery, PagedResultDto<Orders>> _getOrdersByEmissionDateQueryHandler;
    private readonly IOrdersValidationService _ordersValidationService;
    private readonly IOrdersMapper _ordersMapper;

    public LogiChainController(IEventBus eventBus, IQueryHandler<GetOrderByIdQuery, ICollection<Orders>> getOrderByIdQueryHandler, 
        IQueryHandler<GetOrdersByEmissionDateQuery, PagedResultDto<Orders>> getOrdersByEmissionDateQueryHandler, IOrdersValidationService ordersValidationService,
        IOrdersMapper ordersMapper)
    {
        _eventBus = eventBus;
        _getOrderByIdQueryHandler = getOrderByIdQueryHandler;
        _getOrdersByEmissionDateQueryHandler = getOrdersByEmissionDateQueryHandler;
        _ordersValidationService = ordersValidationService;
        _ordersMapper = ordersMapper;
    }

    [HttpGet("orders/{id}")]
    public async Task<PagedOrdersReturnDto<Orders>> GetOrderByIdAsync(int id) 
    {
        var query = new GetOrderByIdQuery { Id = id };
        var listOrders = await _getOrderByIdQueryHandler.Handle(query);
        
        return new PagedOrdersReturnDto<Orders>
        {
            ActualPage = 1,
            TotalPages = 1,
            PageLimit = PagedResult.PageSizeLimit,
            OrdersListCount = listOrders.Count,
            OrdersList = await _ordersMapper.MapEntityToRetunDtoAsync(listOrders)
        };
    }
    
    [HttpGet("orders")]
    public async Task<PagedOrdersReturnDto<Orders>> GetOrdersByEmissionDate([FromQuery] DateTime emissionDateStart, DateTime emissionDateEnd, int page)
    {
        var query = new GetOrdersByEmissionDateQuery
        {
            EmissionDateStart = emissionDateStart,
            EmissionDateEnd = emissionDateEnd,
            Page = page
        };
        var pagedOrdersDto = await _getOrdersByEmissionDateQueryHandler.Handle(query);
        
        return new PagedOrdersReturnDto<Orders>
        {
            ActualPage = page,
            TotalPages = pagedOrdersDto.TotalPages,
            PageLimit = PagedResult.PageSizeLimit,
            OrdersListCount = pagedOrdersDto.ListResultsCount,
            OrdersList = await _ordersMapper.MapEntityToRetunDtoAsync(pagedOrdersDto.ListResults)
        };
    }

    [HttpPost("orders")]
    public async Task<IActionResult> PostOrders([FromBody] List<OrderCreatedMessage> listOrderCreatedMessage)
    {
        foreach (var orderCreatedMessage in listOrderCreatedMessage)
        {
            await _ordersValidationService.ValidateOrderCreatedMessageAsync(orderCreatedMessage);
            await _eventBus.PublishAsync(orderCreatedMessage);
        }
        return Ok();        
    }
}
