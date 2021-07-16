using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Models.Database.Entities
{
    public class Mark : BaseEntity
    {
        public int Value { get; set; }
        public int? LessonId { get; set; }
        public int? StudentId { get; set; }
        public Lesson Lesson { get; set; }
        public Student Student { get; set; }

        public override string ToString() => $"{Value}";
    }
}
