using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;


namespace backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> users = new List<User>( new User[] {
            new User{Id = Guid.NewGuid(), UserName = "Egor", Password = "123"},
            new User{Id = Guid.NewGuid(), UserName = "Kirill", Password = "234"}}
        );

        public User GetUser(Guid id)
        {
            return users.Where(user => user.Id == id).SingleOrDefault();
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public  User GetUserByName(string name){
            return  users.Where(user => user.UserName.ToLower() == name.ToLower()).SingleOrDefault();
        }

        public void AddUser(User user){
            users.Add(user);
        }

        public User GetUserById(Guid id)
        {
            return users.Where(user => user.Id == id).SingleOrDefault();
        }
    }
}