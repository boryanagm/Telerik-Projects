using Deliverit.Services.Contracts;
using DeliverIT.Models;
using System;

namespace Deliverit.Web.Helpers
{
    public class AuthEmployeeHelper : IAuthEmployeeHelper
    {
        private readonly IEmployeeService employeeService;
        public AuthEmployeeHelper(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public Employee TryGetEmployee(string authorizationHeader)
        {
            try
            {
                return this.employeeService.GetByEmployeeEmail(authorizationHeader);
            }
            catch (Exception)
            {
                throw new UnauthorizedAccessException("Invalid authorization.");
            }
        }

        public Employee TryGetAdmin(string authorizationHeader)
        {
            try
            {
                return this.employeeService.GetByAdminEmail(authorizationHeader);
            }
            catch (Exception)
            {
                throw new UnauthorizedAccessException("Invalid authorization.");
            }
        }
    }
}
