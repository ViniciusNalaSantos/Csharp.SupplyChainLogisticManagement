using Csharp.SupplyChainLogisticManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<LogiChainDbContext>(
    //options => options.UseSqlServer(builder.Configuration.GetConnectionString("SapiensProdConnection"))
    options => options.UseSqlServer(
            "Data Source=localhost;Persist Security Info=True;User ID=sa;Password=sa@2025*;Encrypt=True;Trust Server Certificate=True",
            x => x.MigrationsAssembly("Csharp.SupplyChainLogisticManagement.Infrastructure.Migrations")
        )
);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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