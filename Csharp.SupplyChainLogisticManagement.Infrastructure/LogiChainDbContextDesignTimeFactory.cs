using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure;

public class LogiChainDbContextDesignTimeFactory : IDesignTimeDbContextFactory<LogiChainDbContext>
{
    public LogiChainDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LogiChainDbContext>();
        optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["LogiChainDatabase"].ConnectionString);

        return new LogiChainDbContext(optionsBuilder.Options);
    }
}
