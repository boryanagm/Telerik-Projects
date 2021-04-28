using Deliverit.Services.Contracts;
using DeliverIT.Models;
using System;

namespace Deliverit.Web.Helpers
{
    public class AuthCustomerHelper : IAuthCustomerHelper
    {
        private readonly ICustomerService customerService;
        public AuthCustomerHelper(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        public Customer TryGetCustomer(string authorizationHeader)
        {
            try
            {
                return this.customerService.GetByCustomerEmail(authorizationHeader);
            }
            catch (Exception)
            {
                throw new UnauthorizedAccessException("Invalid authorization.");
            }
        }
    }
}
