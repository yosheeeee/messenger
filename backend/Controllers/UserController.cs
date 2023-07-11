using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/messenger")]
    public class UserController : ControllerBase
    {
  
        private IUserRepository repo;

        public UserController(IUserRepository repo){
            this.repo = repo;
        }
        

        [HttpPost]
        [Route("/register/{name}/{password}")]
        public async Task<IActionResult> AddUser(string name , string password){
            if (repo.GetUserByName(name) != default) return BadRequest("user with this name already exist");
                Guid id = Guid.NewGuid();
                User user = new User {UserName = name, Password = password, Id = id , dialogs = new()};
                repo.AddUser(user);
                return Ok(id);
        }

        [HttpGet]
        [Route("/users")]
        public IEnumerable<UserAsDto> GetUsers(){
            var items = repo.GetUsers();
            return items.Select(user => user.AsDto());
        }

        [HttpGet]
        [Route("/user/{id}")]
        public ActionResult<UserAsDto> GetUser(Guid id){
            User user = repo.GetUserById(id);
            if (user == default) return NotFound();
            else return  user.AsDto();
        }

        [HttpGet]
        [Route("/dialog/{userId}/{companionName}")]
        public ActionResult<Dialog> GetDialogByCompanion(Guid userId, string companionName )
        {
            Dialog dialog = repo.GetDialog(userId,companionName);
            if (dialog == default) return BadRequest("диалог не найден");
            else return dialog;
        }

        [HttpPost]
        [Route("/sendmessage/{userId}/{companionName}/{message}")]
        public ActionResult SendMessage(Guid userId, string companionName, string message){
            bool isSended = repo.SendMessage(userId, companionName,message);
            if (!isSended) return BadRequest("сообщение не было отправленно");
            else return Ok();
        }
    }
}