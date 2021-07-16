using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Models.Database.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? JournalId { get; set; }
        public Journal Journal { get; set; }
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
        public List<Mark> Marks { get; set; } = new List<Mark>();

        public override string ToString() =>  $"{FirstName} {LastName}";
    }
}
