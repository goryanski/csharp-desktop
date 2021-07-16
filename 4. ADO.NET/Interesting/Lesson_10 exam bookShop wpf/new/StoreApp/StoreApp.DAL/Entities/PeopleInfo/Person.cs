using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DAL.Entities.PeopleInfo
{
    public abstract class Person : BaseEntity<int>
    {
        public string FullName { get; set; }
    }
}
