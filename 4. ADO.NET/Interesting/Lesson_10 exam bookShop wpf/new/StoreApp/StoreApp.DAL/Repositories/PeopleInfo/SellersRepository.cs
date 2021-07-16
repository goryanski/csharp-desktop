using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.DAL.EF;
using StoreApp.DAL.Entities.PeopleInfo;

namespace StoreApp.DAL.Repositories.PeopleInfo
{
    public class SellersRepository : BaseRepository<Seller, int>
    {
        public SellersRepository(StoreContext context) : base(context)
        {
        }

        public override void Update(Seller entity)
        {
        }
    }
}
