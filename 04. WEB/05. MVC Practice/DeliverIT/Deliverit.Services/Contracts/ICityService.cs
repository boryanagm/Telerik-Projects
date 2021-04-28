using Deliverit.Models;
using Deliverit.Services.Models;
using System;
using System.Collections.Generic;

namespace Deliverit.Services.Contracts
{
    public interface ICityService
    {
        CityDTO Get(Guid id);
        IEnumerable<CityDTO> GetAll();
    }
}
