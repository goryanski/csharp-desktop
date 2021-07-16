using System;
using System.Collections.Generic;
using System.Text;
using Practice.Models.Database.Entities;

namespace Practice.Models.Database.Repository
{
    public class MarksRepository : BaseRepository<Mark>
    {
        public MarksRepository(DatabaseContext ctx) : base(ctx)
        {
        }

        public override void Update(Mark entity)
        {
            var mark = Get(entity.Id);
            mark.Value = entity.Value;
            mark.StudentId = entity.StudentId;
            mark.Student = entity.Student;
            mark.LessonId = entity.LessonId;
            mark.Lesson = entity.Lesson;
            context.SaveChanges();
        }
    }
}
