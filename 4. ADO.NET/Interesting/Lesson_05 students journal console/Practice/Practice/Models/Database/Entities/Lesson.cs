using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Models.Database.Entities
{
    public class Lesson : BaseEntity
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Mark> Marks { get; set; } = new List<Mark>();

        public override string ToString() => $"{Name}";        
    }
}
