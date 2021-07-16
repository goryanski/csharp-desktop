using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DAL.Entities.PeopleInfo
{
    public class Seller : BaseEntity<int>
    {
        // для продавца этих данных достаточно
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
