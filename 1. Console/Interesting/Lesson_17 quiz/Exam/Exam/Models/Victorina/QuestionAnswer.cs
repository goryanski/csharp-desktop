using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    [Serializable]
    class QuestionAnswer
    {
        public int QuestionNumber{ get; set; }
        public List<int> QuestionAnswers { get; set; }

        public QuestionAnswer()
        {
            QuestionAnswers = new List<int>();
        }

        public void ShowAnswers()
        {
            Console.Write("\tRight answers: ");
            foreach (var item in QuestionAnswers)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
