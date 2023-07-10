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
    [Route("api/users")]
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
                User user = new User {UserName = name, Password = password, Id = id };
                repo.AddUser(user);
                return Ok(id);
        }

        [HttpGet]
        [Route("/getusers")]
        public IEnumerable<User> GetUsers(){
            var items = repo.GetUsers();
            return items;
        }

        [HttpGet]
        [Route("/user/{id}")]
        public ActionResult<User> GetUser(Guid id){
            User user = repo.GetUserById(id);
            if (user == default) return NotFound();
            else return  user;
        }
    }
}