using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Attributes
{
    class BirthAttribute : ValidationAttribute
    {
        private DateTime from;
        public DateTime To { get; set; } = DateTime.Now;
        public BirthAttribute(int year, int month, int day)
        {
            from = new DateTime(year, month, day);
        }

        public override bool IsValid(object value)
        {
            var val = (DateTime)value;
            return val >= from && val <= To;
        }
    }
}
