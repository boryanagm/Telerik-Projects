using Deliverit.Services.Models;
using DeliverIT.Models;
using System;
using System.Collections.Generic;

namespace Deliverit.Services.Contracts
{
    public interface ICustomerService
    {
        Customer GetByCustomerEmail(string customerEmail);
        CustomerDTO Get(Guid id);
        IEnumerable<CustomerDTO> GetAll();
        int GetCount();
        CustomerDTO Create(Customer customer);
        CustomerDTO Update(Guid id, Guid addressId); 
        bool Delete(Guid id);
        List<ParcelDTO> GetIncomingParcels(Guid id);
        List<ParcelDTO> GetPastParcels(Guid id);
        List<CustomerDTO> GetByMultipleCriteria(CustomerFilter customerFilter);  
        CustomerDTO GetByKeyWord(string key);
    }
}
