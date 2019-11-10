using System;

namespace ControlSystem.Model
{
    public class Topic
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public int Count { get; set; }
    }
}
