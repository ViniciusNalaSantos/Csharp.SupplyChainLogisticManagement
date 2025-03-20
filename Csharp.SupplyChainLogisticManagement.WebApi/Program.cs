using Csharp.SupplyChainLogisticManagement.Application.Interfaces;
using Csharp.SupplyChainLogisticManagement.Application.Services;
using Csharp.SupplyChainLogisticManagement.Domain.Interfaces;
using Csharp.SupplyChainLogisticManagement.Infrastructure.Data;
using Csharp.SupplyChainLogisticManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register dependencies And Use InMemory Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("Csharp.SupplyChainLogisticManagementDb"));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

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