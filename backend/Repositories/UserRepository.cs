using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        List<User> users = new List<User>( new User[] {
            new User{Id = new Guid(), UserName = "Egor", Password = "123"},
            new User{Id = new Guid(), UserName = "Kirill", Password = "234"}}
        );

        public List<User> Users { get => users; set => users = value; }

        public User GetUser(Guid id)
        {
            return Users.Where(user => user.Id == id).SingleOrDefault();
        }

        public List<User> GetUsers()
        {
            return Users;
        }

        public async Task Registration(string name, string password)
        {

        }
    }
}