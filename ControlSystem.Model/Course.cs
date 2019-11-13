using System;
using System.Collections.Generic;

namespace ControlSystem.Model
{
    public class Course: IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Topic> Topics {get;set;}
        public StoreMode StoreMode { get; set; }
        public User CreatedBy { get; set; }
    }
}
