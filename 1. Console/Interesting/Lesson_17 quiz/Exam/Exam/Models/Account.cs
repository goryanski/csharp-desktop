using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Attributes;

namespace Exam.Models
{
    [Serializable]
    class Account
    {
        [Required]
        [MaxLength(16, ErrorMessage = "Max length for login must be 16 symbols")]
        [MinLength(4, ErrorMessage = "Min length for login must be 4 symbols")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9_]{3,16}$", ErrorMessage = "Login was writed incorrectly")]
        public string Login { get; set; }


        [Required]
        [MaxLength(16, ErrorMessage = "Max length for password must be 16 symbols")]
        [MinLength(4, ErrorMessage = "Min length for password must be 4 symbols")]
        [RegularExpression(@"^[a-zA-Z0-9_]{4,16}$", ErrorMessage = "Password was writed incorrectly")]
        public string Password { get; set; }

        public string Id { get; set; }

        public Account() => Id = Guid.NewGuid().ToString();
    }
}
