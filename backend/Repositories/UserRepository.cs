using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;


namespace backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> users = new List<User>()
        {
            new User
            {
                Id = Guid.NewGuid(), UserName = "Egor", Password = "123", dialogs = new Dictionary<string, Dialog>()
                {
                    {
                        "Kirill",
                        new Dialog()
                        {
                            messages = new List<Message>()
                                { new() { senderName = "Egor", message = "привет лох" } }
                        }
                    }
                }
            },
            new User
            {
                Id = Guid.NewGuid(), UserName = "Kirill", Password = "234", dialogs = new()
                {
                    {
                        "Egor",
                        new Dialog()
                        {
                            messages = new List<Message>()
                                { new() { senderName = "Egor", message = "привет лох" } }
                        }
                    }
                }
            }
        };

        public User GetUser(Guid id)
        {
            return users.Where(user => user.Id == id).SingleOrDefault();
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public User GetUserByName(string name)
        {
            return users.Where(user => user.UserName.ToLower() == name.ToLower()).SingleOrDefault();
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public User GetUserById(Guid id)
        {
            return users.Where(user => user.Id == id).SingleOrDefault();
        }

        public Dialog GetDialog(Guid userId, string companionName)
        {
            User user = GetUserById(userId);
            return user.dialogs.Where(pair => pair.Key == companionName).Select(pair => pair.Value).SingleOrDefault();
        }

        public bool SendMessage(Guid fromId, string toName, string message)
        {
            User fromUser = GetUserById(fromId);
            if (fromUser == default) return false;
            User toUser = GetUserByName(toName);
            if (toUser == default) return false;
            Dialog dialog = fromUser.dialogs.Where(pair => pair.Key == toUser.UserName).Select(pair => pair.Value)
                .SingleOrDefault();
            if (dialog == default)
            {
                dialog = new Dialog() { messages = new List<Message>() };
                dialog.messages.Add(new Message() { message = message, senderName = fromUser.UserName });
                fromUser.dialogs.Add(toName, dialog);
                toUser.dialogs.Add(fromUser.UserName, dialog);
            }
            else
            {
                dialog.messages.Add(new Message() { message = message, senderName = fromUser.UserName });
            }

            return true;
        }
    }
}