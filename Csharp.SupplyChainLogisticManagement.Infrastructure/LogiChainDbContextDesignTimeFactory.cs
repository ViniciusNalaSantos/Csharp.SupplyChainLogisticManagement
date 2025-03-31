using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure;
public class LogiChainDbContextDesignTimeFactory : IDesignTimeDbContextFactory<LogiChainDbContext>
{
    public LogiChainDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LogiChainDbContext>();
        optionsBuilder.UseSqlServer("Data Source=localhost;Persist Security Info=True;User ID=sa;Password=sa@2025*;Encrypt=True;Trust Server Certificate=True");

        return new LogiChainDbContext(optionsBuilder.Options);
    }
}
