using System;
using System.Collections.Generic;
using ControlSystem.Model;
using ControlSystemServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControlSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.GetUsers();
        }
        [HttpGet("byName")]
        public bool CheckUser(string name, string passwordSalt)
        {
            return _userService.Check(name, passwordSalt);
        }
        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(Guid id)
        {
            return _userService.GetUser(id);
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _userService.PutUser(user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
