using System;

namespace ControlSystem.Model
{
    public interface IEntity
    {
        Guid ID { get; set; }
        StoreMode StoreMode { get; set; }
    }
}
