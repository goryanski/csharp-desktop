using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.DAL.EF;
using StoreApp.DAL.Entities;

namespace StoreApp.DAL.Repositories
{
    public class PublishingOfficesRepository : BaseRepository<PublishingOffice, int>
    {
        public PublishingOfficesRepository(StoreContext context) : base(context)
        {
        }

        public override void Update(PublishingOffice entity)
        {
        }
    }
}
