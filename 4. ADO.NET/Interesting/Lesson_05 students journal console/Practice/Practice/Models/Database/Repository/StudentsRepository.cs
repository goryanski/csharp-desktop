using System;
using System.Collections.Generic;
using System.Text;
using Practice.Models.Database.Entities;

namespace Practice.Models.Database.Repository
{
    public class StudentsRepository : BaseRepository<Student>
    {
        public StudentsRepository(DatabaseContext ctx) : base(ctx)
        {
        }

        public override void Update(Student entity)
        {

        }
    }
}
