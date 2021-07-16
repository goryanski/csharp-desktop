using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DAL.Entities
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
