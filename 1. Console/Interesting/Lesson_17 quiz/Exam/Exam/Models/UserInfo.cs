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
    class UserInfo
    {
        [MaxLength(16, ErrorMessage = "Max length for name must be 16 symbols")]
        [MinLength(4, ErrorMessage = "Min length for name must be 4 symbols")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9_]{3,16}$", ErrorMessage = "Name was writed incorrectly")]
        public string Name { get; set; }


        [Required]
        [Birth(1900, 1, 1, ErrorMessage = "Date of birth out of range of possible dates of birth")]
        public DateTime Birth { get; set; }


        public string AccountId { get; set; }
    }
}
