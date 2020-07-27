using System;
using System.Collections.Generic;
using System.Text;
using GameStore.Domain.Entities.Base;

namespace GameStore.Domain.Entities
{
    public class Game : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
