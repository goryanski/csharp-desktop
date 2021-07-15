using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Models;

namespace Practice
{
    class ObjectValidator
    {
        public static (List<string> errors, bool validated) Validate(object obj)
        {
            var results = new List<ValidationResult>();
            var ctx = new ValidationContext(obj);

            bool validated = Validator.TryValidateObject(obj, ctx, results, true);
            var errors = results.Select(err => err.ErrorMessage).ToList();

            return (errors, validated);
        }
    }
}
