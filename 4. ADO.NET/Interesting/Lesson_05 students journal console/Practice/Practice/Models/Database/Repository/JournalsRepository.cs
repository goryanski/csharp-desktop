using System;
using System.Collections.Generic;
using System.Text;
using Practice.Models.Database.Entities;

namespace Practice.Models.Database.Repository
{
    public class JournalsRepository : BaseRepository<Journal>
    {
        public JournalsRepository(DatabaseContext ctx) : base(ctx)
        {
        }

        public override void Update(Journal entity)
        {
        }
    }
}
