using Deliverit.Models;
using DeliverIT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deliverit.Services.Contracts
{
    public interface IAddressService
    {
        Address Create(Address address);
    }
}
