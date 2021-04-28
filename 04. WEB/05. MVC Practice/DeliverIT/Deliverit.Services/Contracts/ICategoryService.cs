using Deliverit.Models;
using DeliverIT.Models;
using System;
using System.Collections.Generic;

namespace Deliverit.Services.Contracts
{
    public interface ICategoryService
    {
        Category Get(Guid id);
        IEnumerable<Category> GetAll();
        ICollection<Parcel> GetAllParcels(Guid id);
    }
}
