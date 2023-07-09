using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Repositories
{
    public interface IUserRepository
    {
        public List<User> GetUsers();

        public Task Registration(string name, string password );

        public User GetUser(Guid id);



    }
}