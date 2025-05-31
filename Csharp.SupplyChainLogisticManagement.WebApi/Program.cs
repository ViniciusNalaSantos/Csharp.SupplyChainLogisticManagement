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
builder.Services.AddRepositoryService();
builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddValidationService();
builder.Services.AddMapperService();

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