using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Domain.Entities.Base.Interfaces
{
    public interface IEntity<T>
    {
        public T Id { get; set; }
    }
}
