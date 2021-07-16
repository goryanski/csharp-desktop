using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.DAL.EF;
using StoreApp.DAL.Entities.PeopleInfo;

namespace StoreApp.DAL.Repositories.PeopleInfo
{
    public class CustomersRepository : BaseRepository<Customer, int>
    {
        public CustomersRepository(StoreContext context) : base(context)
        {
        }

        public override void Update(Customer entity)
        {
        }
    }
}
