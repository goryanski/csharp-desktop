using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Entities
{
    [Table(Name = "People")]
    public class Person
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public string FirstName { get; set; }
        [Column]
        public string LastName { get; set; }
        [Column]
        public DateTime Birth { get; set; }
        [Column()]
        public int? AccountId { get; set; }
    }
}
