using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.TokenGenerators;
public interface ITokenGenerator
{
    string GenerateToken(string username);
}
