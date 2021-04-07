using LayeredArchitecture.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LayeredArchitecture.Services.Contracts
{
    public interface IUserService
    {
        User Get(int id);
        IEnumerable<User> GetAll();
        User Create(User user);
        User Update(int id, User user);
        bool Delete(int id);
    }
}
