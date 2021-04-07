using Data;
using LayeredArchitecture.Data.Models;
using LayeredArchitecture.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LayeredArchitecture.Services
{
    public class UserService : IUserService
    {
        public User Get(int id)
        {
            var user = Database.Users
                .FirstOrDefault(u => u.Id == id)
                ?? throw new ArgumentNullException();

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            var users = Database.Users;

            return users;
        }

        public User Create(User user)
        {
            Database.Users.Add(user);

            return user;
        }

        public User Update(int id, User model)
        {
            var user = Database.Users
                .FirstOrDefault(u => u.Id == id)
                ?? throw new ArgumentNullException();

            user.Name = model.Name;

            return user;
        }

        public bool Delete(int id)
        {
            var user = Database.Users
                .FirstOrDefault(u => u.Id == id);

            return Database.Users.Remove(user);
        }
    }
}
