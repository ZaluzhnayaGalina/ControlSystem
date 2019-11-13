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
        [HttpGet("auth")]
        public User CheckUser(string login, string passwordSalt)
        {
            if (_userService.Check(login, passwordSalt))
                return _userService.GetUser(login);
            else return null;
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
            _userService.CreateUser(user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] User user)
        {
            if (id != user.ID)
                return;
            _userService.ChangeUser(user);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _userService.DeleteUser(id);
        }
    }
}
