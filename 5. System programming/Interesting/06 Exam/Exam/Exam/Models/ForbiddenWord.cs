using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class ForbiddenWord
    {
        public string Word { get; set; }
        public int Count { get; set; }

        public override string ToString() => $"Word: {Word} - Count: {Count}";
    }
}
