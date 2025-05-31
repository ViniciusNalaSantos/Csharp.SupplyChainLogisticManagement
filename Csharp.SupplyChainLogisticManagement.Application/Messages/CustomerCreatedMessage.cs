using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Application.Messages;
public record CustomerCreatedMessage
{
    public Guid MessageId { get; init; } = Guid.NewGuid();
    public int? Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
    public string Address { get; init; }
}
