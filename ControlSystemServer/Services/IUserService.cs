using ControlSystem.Model;
using System;
using System.Collections.Generic;

namespace ControlSystemServer.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUser(Guid id);
        void PutUser(User user);
        bool Check(string userName, string passwordSalt);
    }
}
