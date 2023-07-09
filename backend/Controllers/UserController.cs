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
  
        private readonly IUserRepository repo;

        public UserController(){
            repo = new UserRepository();
        }
        
        [Route("/register")]
        [HttpPost]
        public async Task<IActionResult> AddUser(){
            
        }

        [HttpGet]
        [Route("/getusers")]
        public IEnumerable<User> GetUsers(){
            return repo.GetUsers();
        }
    }
}