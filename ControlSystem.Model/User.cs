using System;
using System.Collections.Generic;
using System.Text;

namespace ControlSystem.Model
{
    public class User
    {
        public Guid ID { get; set; }
        public string Login { get; set; }
        public string Name { get; set;}
        public Role Role { get; set; }
        public string Password { get; set; }
    }
}
