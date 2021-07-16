using System;
using System.Collections.Generic;
using System.Text;
using Practice.Models.Database.Entities;

namespace Practice.Models.Database.Repository
{
    public class LessonsRepository : BaseRepository<Lesson>
    {
        public LessonsRepository(DatabaseContext ctx) : base(ctx)
        {
        }

        public override void Update(Lesson entity)
        {

        }
    }
}
