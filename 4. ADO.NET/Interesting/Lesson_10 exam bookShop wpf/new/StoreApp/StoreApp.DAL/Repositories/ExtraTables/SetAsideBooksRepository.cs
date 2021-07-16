using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.DAL.EF;
using StoreApp.DAL.Entities.ExtraTables;

namespace StoreApp.DAL.Repositories.ExtraTables
{
    public class SetAsideBooksRepository : BaseRepository<SetAsideBook, int>
    {
        public SetAsideBooksRepository(StoreContext context) : base(context)
        {
        }

        public override void Update(SetAsideBook entity)
        {
        }

    }
}
