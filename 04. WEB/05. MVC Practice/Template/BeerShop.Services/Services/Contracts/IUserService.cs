using BeerShop.Data.Models;
using System.Collections.Generic;

namespace BeerShop.Services.Contracts
{
    public interface IUserService
    {
        public User Get(string email);
        List<User> GetAll();
    }
}
