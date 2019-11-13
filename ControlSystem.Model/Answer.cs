using System;

namespace ControlSystem.Model
{
    public class Answer: IEntity
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public int Point { get; set; }
        public StoreMode StoreMode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
