using Beers.Data.Models;
using Beers.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beers.Web.Helpers
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IUserService userService;

        public AuthHelper(IUserService userService)
        {
            this.userService = userService;
        }
        public User TryGetUser(string authorizationHeader)
        {
            try
            {
                return this.userService.GetByUsername(authorizationHeader);
            }
            catch (Exception)
            {
                throw new ArgumentException("Invalid username");
            }
        }
    }
}
