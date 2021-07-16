using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Entities
{
    [Table(Name = "Accounts")]
    public class Account
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public string Login { get; set; }
        [Column]
        public string Password { get; set; }
        [Column(Name = "regDate")]
        public DateTime RegistrationDate { get; set; }
    }
}
