﻿using Csharp.SupplyChainLogisticManagement.Application.Interfaces;
using Csharp.SupplyChainLogisticManagement.Application.Interfaces.Handlers;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System.Text.Json;

using Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.MessageHandlers;
public class CreateOrderMessageHandler : IMessageHandler<OrderCreatedMessage>
{
    private readonly IUnitOfWork _unitOfWork;    
    public CreateOrderMessageHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(OrderCreatedMessage message)
    {
        using var transaction = await _unitOfWork.BeginTransactionAsync();
        try
        {
            Customers customer = null;
            if (message.CustomerId != null)
            {
                customer = await _unitOfWork.CustomersRepository.GetCustomerFirstOrDefaultAsync(l => l.Id == message.CustomerId);
            }            
            if (message.Customer != null && customer == null)
            {
                customer = await _unitOfWork.CustomersRepository.GetCustomerFirstOrDefaultAsync(l => l.Email == message.Customer.Email);
                if (customer == null)
                {
                    customer = new Customers
                    {
                        Name = message.Customer.Name,
                        Email = message.Customer.Email,
                        Address = message.Customer.Address
                    };
                    customer = await _unitOfWork.CustomersRepository.InsertCustomerAsync(customer);
                    await _unitOfWork.CommitAsync();
                }
            }
            if (message.CustomerId != null && customer == null)
            {
                throw new Exception("There is no customer with Id '" + message.CustomerId + "' as passed.");
            }

            Suppliers supplier = null;
            if (message.Supplier != null)
            {
                supplier = await _unitOfWork.SuppliersRepository.GetSupplierFirstOrDefaultAsync(l => l.Email == message.Supplier.Email);
                if (supplier == null)
                {
                    supplier = new Suppliers
                    {
                        Name = message.Supplier.Name,
                        Email = message.Supplier.Email,
                        Phone = message.Supplier.Phone
                    };
                    supplier = await _unitOfWork.SuppliersRepository.InsertSupplierAsync(supplier);
                    await _unitOfWork.CommitAsync();
                }
            }
            if (message.SupplierId != null && supplier == null)
            {
                throw new Exception("There is no supplier with Id '" + message.SupplierId + "' as passed.");
            }

            Orders order = new Orders
            {
                OrderNumber = message.OrderNumber,
                EmissionDate = message.EmissionDate,
                Price = Math.Round(message.Price, 2),
                CustomersId = customer?.Id ?? message.CustomerId,
                SuppliersId = supplier?.Id ?? message.SupplierId,

            };
            order = await _unitOfWork.OrdersRepository.InsertOrderAsync(order);
            await _unitOfWork.CommitAsync();

            foreach (var messageOrderItem in message.OrderItems)
            {
                Products product = null;
                if (messageOrderItem.Product != null)
                {
                    product = await _unitOfWork.ProductsRepository.GetProductFirstOrDefaultAsync(l => l.Description == messageOrderItem.Product.Description);
                    if (product == null)
                    {
                        product = new Products
                        {
                            Description = messageOrderItem.Product.Description,
                            Price = messageOrderItem.Product.Price
                        };
                        product = await _unitOfWork.ProductsRepository.InsertProductAsync(product);
                        await _unitOfWork.CommitAsync();
                    }
                }
                if (messageOrderItem.ProductId != null && product == null)
                {
                    throw new Exception("There is no product with Id '" + messageOrderItem.ProductId + "' as passed.");
                }

                var orderItem = new OrdersItems
                {
                    OrdersId = order.Id,
                    ProductsId = (int)(product?.Id ?? messageOrderItem.ProductId),
                    Quantity = Math.Round(messageOrderItem.Quantity, 2)
                };
                orderItem = await _unitOfWork.OrdersItemsRepository.InsertOrderItemAsync(orderItem);
                await _unitOfWork.CommitAsync();
            }

            Shipments shipment = null;
            if (message.Shipment != null)
            {
                shipment = new Shipments
                {
                    OrdersId = order.Id,
                    ShipmentDate = message.Shipment.ShipmentDate
                };
                shipment = await _unitOfWork.ShipmentsRepository.InsertShipmentAsync(shipment);
                await _unitOfWork.CommitAsync();
            }

            Deliveries delivery = null;
            if (message.Delivery != null)
            {
                Transporters transporter = null;
                if (message.Delivery.Transporter != null)
                {
                    transporter = await _unitOfWork.TransportersRepository.GetTransporterFirstOrDefaultAsync(l => l.Email == message.Delivery.Transporter.Email);
                    if (transporter == null)
                    {
                        transporter = new Transporters
                        {
                            Name = message.Delivery.Transporter.Name,
                            Email = message.Delivery.Transporter.Email,
                            Phone = message.Delivery.Transporter.Phone
                        };
                        transporter = await _unitOfWork.TransportersRepository.InsertTransporterAsync(transporter);
                        await _unitOfWork.CommitAsync();
                    }
                }
                if (message.Delivery.TransporterId != null && transporter == null)
                {
                    throw new Exception("There is no Transporter with Id '" + message.Delivery.TransporterId + "' as passed.");
                }

                delivery = new Deliveries
                {
                    OrdersId = order.Id,
                    TransportersId = (int)(transporter?.Id ?? message.Delivery.TransporterId),
                };
                delivery = await _unitOfWork.DeliveriesRepository.InsertDeliveryAsync(delivery);
                await _unitOfWork.CommitAsync();
            }
            
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw; // throw again the exception to the message go to the dead queue letter
        }
    }
}
