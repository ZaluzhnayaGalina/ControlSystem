using System;

namespace ControlSystem.Model
{
    public interface IEntity
    {
        Guid Id { get; set; }
        StoreMode StoreMode { get; set; }
    }
}
