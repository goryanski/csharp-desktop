using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Attributes
{
    class CheckYearAttribute : ValidationAttribute
    {
        int from;
        int to;
        public CheckYearAttribute()
        {
            from = 1;
            to = DateTime.Now.Year;
        }
        public override bool IsValid(object value)
        {
            int year = (int)value;
            return year >= from && year <= to;
        }
    }
}
