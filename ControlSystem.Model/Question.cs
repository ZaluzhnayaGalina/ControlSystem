using System;
using System.Collections.Generic;
using System.Text;

namespace ControlSystem.Model
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public int Type { get; set; }
        public int Count { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
