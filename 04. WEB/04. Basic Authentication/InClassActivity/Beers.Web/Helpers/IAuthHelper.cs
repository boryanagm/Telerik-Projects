using Beers.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beers.Web.Helpers
{
    public interface IAuthHelper
    {
        User TryDeleteBeer(string authorizationHeader);
        User TryUpdateBeer(string authorizationHeader);

    }
}
