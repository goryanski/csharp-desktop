using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Models
{
    class Account
    {
        [Required]
        [MaxLength(16, ErrorMessage = "Максимальная длина логина 16 символов")]
        [MinLength(4, ErrorMessage = "Минимальная длина логина 4 символа")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9_]{3,16}$", ErrorMessage = "Проверьте правильность ввода логина")]
        public string Login { get; set; }


        [Required]
        [MaxLength(16, ErrorMessage = "Максимальная длина пароля 16 символов")]
        [MinLength(4, ErrorMessage = "Минимальная длина пароля 4 символа")]
        [RegularExpression(@"^[a-zA-Z0-9_]{4,16}$", ErrorMessage = "Проверьте правильность ввода пароля")]
        public string Password { get; set; }
    }
}
