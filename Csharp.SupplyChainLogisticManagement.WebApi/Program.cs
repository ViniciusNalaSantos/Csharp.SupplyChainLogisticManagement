using Csharp.SupplyChainLogisticManagement.Application.Mappers.CustomersMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.DeliveriesMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.OrdersItemsMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.OrdersMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.ProductsMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.ShipmentsMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.SuppliersMappers;
using Csharp.SupplyChainLogisticManagement.Application.Mappers.TransportersMappers;
using Csharp.SupplyChainLogisticManagement.Application.ValidationServices.OrdersValidationServices;
using Csharp.SupplyChainLogisticManagement.Infrastructure.Configuration.Extensions;
using Csharp.SupplyChainLogisticManagement.Infrastructure.DatabaseContext;
using Csharp.SupplyChainLogisticManagement.WebApi.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<LogiChainDbContext>(
    options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("LogiChainDatabase"),
            x => x.MigrationsAssembly("Csharp.SupplyChainLogisticManagement.Infrastructure.Migrations")
        ),
    ServiceLifetime.Transient
);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRabbitMQService();

builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddScoped<IOrdersValidationService, OrdersValidationService>();
builder.Services.AddScoped<IOrdersMapper, OrdersMapper>();
builder.Services.AddScoped<IOrdersItemsMapper, OrdersItemsMapper>();
builder.Services.AddScoped<IDeliveriesMapper, DeliveriesMapper>();
builder.Services.AddScoped<ICustomersMapper, CustomersMapper>();
builder.Services.AddScoped<IProductsMapper, ProductsMapper>();
builder.Services.AddScoped<IShipmentsMapper, ShipmentsMapper>();
builder.Services.AddScoped<ISuppliersMapper, SuppliersMapper>();
builder.Services.AddScoped<ITransportersMapper, TransportersMapper>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();