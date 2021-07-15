using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Victorina
{
    [Serializable]
    public class TestResult
    {
        public string Name { get; set; }
        public int CountRightAnswers { get; set; }
        public string TestName { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\nTestName: {TestName}\nCountRightAnswers: {CountRightAnswers}\n";
        }
    }
}
