using System;
using System.Collections.Generic;
using System.Text;
using GameStore.Domain.Entities.Base.Interfaces;

namespace GameStore.Domain.Entities.Base
{
    public class BaseEntity<T> : IEntity<T>
    {
        public T Id { get; set; }
    }
}
