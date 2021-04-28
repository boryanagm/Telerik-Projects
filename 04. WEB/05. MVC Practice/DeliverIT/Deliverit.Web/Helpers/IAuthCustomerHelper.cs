using DeliverIT.Models;

namespace Deliverit.Web.Helpers
{
    public interface IAuthCustomerHelper
    {
        Customer TryGetCustomer(string authorizationHeader);
    }
}
