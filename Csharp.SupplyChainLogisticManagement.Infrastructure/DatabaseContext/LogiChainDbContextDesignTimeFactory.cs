using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.DatabaseContext;

public class LogiChainDbContextDesignTimeFactory : IDesignTimeDbContextFactory<LogiChainDbContext>
{
    public LogiChainDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        var builder = new DbContextOptionsBuilder<LogiChainDbContext>();
        var connectionString = configuration.GetConnectionString("LogiChainDatabase");
        builder.UseSqlServer(connectionString);

        return new LogiChainDbContext(builder.Options);
    }
}
