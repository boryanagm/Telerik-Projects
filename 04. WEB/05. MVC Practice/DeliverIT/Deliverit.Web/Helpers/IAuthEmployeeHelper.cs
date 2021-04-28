using DeliverIT.Models;

namespace Deliverit.Web.Helpers
{
    public interface IAuthEmployeeHelper
    {
        Employee TryGetEmployee(string authorizationHeader);
        Employee TryGetAdmin(string authorizationHeader);

    }
}
