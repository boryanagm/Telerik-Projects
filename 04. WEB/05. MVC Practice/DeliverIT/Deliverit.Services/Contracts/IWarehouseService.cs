using Deliverit.Services.Models;
using DeliverIT.Models;
using System;
using System.Collections.Generic;

namespace Deliverit.Services.Contracts
{
    public interface IWarehouseService
    {
        WarehouseDTO Get(Guid id);
        IEnumerable<WarehouseDTO> GetAll();
        WarehouseDTO Create(Warehouse warehouse);
        WarehouseDTO Update(Guid id, Guid addressId);
        bool Delete(Guid id);
    }
}
