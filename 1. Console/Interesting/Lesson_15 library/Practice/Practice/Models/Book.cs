using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Attributes;

namespace Practice.Models
{
    class Book
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Максимальная длина названия книги 50 символов")]
        [MinLength(2, ErrorMessage = "Минимальная длина  названия книги 2 символа")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9,.\-!?: ]{1,50}$", ErrorMessage = "Проверьте правильность ввода названия книги")]
        public string BookName { get; set; }


        [Required]
        [MaxLength(32, ErrorMessage = "Максимальная длина имени автора 32 символов")]
        [MinLength(4, ErrorMessage = "Минимальная длина имени автора 4 символа")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z. ]{3,32}$", ErrorMessage = "Проверьте правильность ввода имени автора")]
        public string Author { get; set; }

        
        [Required]
        [CheckYear(ErrorMessage = "Недопустимый год написания книги")]
        public int WritingYear { get; set; }


        [Required]
        [Range(1, 5_000, ErrorMessage = "Недопустимая цена")]
        public decimal Price { get; set; }


        public override string ToString()
        {
            return $"Book name - {BookName}, " +
                $"Author - {Author}, " +
                $"Writing date - {WritingYear}, " +
                $"Price - {Price}";
        }
    }
}
