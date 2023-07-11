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

        public User GetUser(Guid id);

        public User GetUserByName(string name);

        public void AddUser(User user);

        User GetUserById(Guid id);

        Dialog GetDialog(Guid userId,string companionName);

        bool SendMessage(Guid fromId, string toName, string message);
    }
}