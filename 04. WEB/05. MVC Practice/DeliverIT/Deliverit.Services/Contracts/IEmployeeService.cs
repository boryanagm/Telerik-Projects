using Deliverit.Services.Models;
using DeliverIT.Models;
using System;
using System.Collections.Generic;

namespace Deliverit.Services.Contracts
{
    public interface IEmployeeService
    {
        Employee GetByEmployeeEmail(string employeeEmail);
        Employee GetByAdminEmail(string adminEmail);
        EmployeeDTO Get(Guid id);
        IEnumerable<EmployeeDTO> GetAll();
        EmployeeDTO Create(Employee employee);
        EmployeeDTO Update(Guid id, Guid addressId);
        bool Delete(Guid id);
        EmployeeDTO Restore(Guid id);
    }
}
