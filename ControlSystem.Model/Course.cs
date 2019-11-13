using System;
using System.Collections.Generic;

namespace ControlSystem.Model
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions {get;set;}
    }
}
