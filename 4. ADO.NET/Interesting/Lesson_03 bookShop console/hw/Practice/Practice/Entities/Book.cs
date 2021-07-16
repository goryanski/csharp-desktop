using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Entities
{
    [Table(Name = "Books")]
    public class Book
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public int Pages { get; set; }
        [Column]
        public decimal Price { get; set; }
        [Column]
        public DateTime PublishDate { get; set; }
        [Column]
        public int? AuthorId { get; set; }
        [Column]
        public int? ThemeId { get; set; }
        [Column]
        public bool IsDeleted { get; set; }


        public override string ToString()
        {
            return $"Id - {Id}, " +
               $"Name - {Name}, " +
               $"Price - {Price}, " +
               $"Pages - {Pages}";
        }

        public string GetFullInfo()
        {
            return $"Id - {Id}, " +
                   $"Name - {Name}, " +
                   $"Price - {Price}, " +
                   $"Pages - {Pages}, " +
                   $"PublishDate - {PublishDate.ToShortDateString()}, " +
                   $"AuthorId - {AuthorId}, " +
                   $"ThemeId - {ThemeId}, ";
        }
    }
}
