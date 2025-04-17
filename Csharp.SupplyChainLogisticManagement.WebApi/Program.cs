using Csharp.SupplyChainLogisticManagement.Infrastructure.Consumers;
using Csharp.SupplyChainLogisticManagement.Infrastructure.EventBus;
using Csharp.SupplyChainLogisticManagement.Infrastructure.MessageConsumer;
using Csharp.SupplyChainLogisticManagement.Application.Messages;
using Csharp.SupplyChainLogisticManagement.Infrastructure.DatabaseContext;
using Csharp.SupplyChainLogisticManagement.Infrastructure.Messaging.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<LogiChainDbContext>(
    options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("LogiChainDatabase"),
            x => x.MigrationsAssembly("Csharp.SupplyChainLogisticManagement.Infrastructure.Migrations")
        )
);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRabbitMQService();

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