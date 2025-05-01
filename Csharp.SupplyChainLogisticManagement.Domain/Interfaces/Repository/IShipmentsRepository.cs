using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp.SupplyChainLogisticManagement.Domain.Interfaces.Repository;
    public interface IShipmentsRepository
    {
        Task<Shipments?> InsertShipmentAsync(Shipments shipment);        
    }
