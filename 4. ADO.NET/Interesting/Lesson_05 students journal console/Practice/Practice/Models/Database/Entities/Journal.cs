using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Models.Database.Entities
{
    public class Journal : BaseEntity
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        public override string ToString() => $"{Name}";
    }
}
