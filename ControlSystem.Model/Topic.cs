using System;
using System.Collections.Generic;

namespace ControlSystem.Model
{
    public class Topic: IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public int Count { get; set; }
        public List<Question> Questions{get;set;}
        public StoreMode StoreMode { get; set; }
    }
}
