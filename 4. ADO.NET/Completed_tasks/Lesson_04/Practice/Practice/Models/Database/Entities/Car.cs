using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Models.Database.Entities
{
    public class Car :BaseEntity
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
    }
}
