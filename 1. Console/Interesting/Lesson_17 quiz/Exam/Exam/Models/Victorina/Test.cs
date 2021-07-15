using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    [Serializable]
    class Test
    {
        public const int QUESTIONS_COUNT = 20;
        public string TestName { get; set; }

        public List<Question> Questions;

        public Test()
        {
            Questions = new List<Question>(QUESTIONS_COUNT);
        }
    }
}
