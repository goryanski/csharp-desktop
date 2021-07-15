using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    [Serializable]
    class Question
    {
        public string QuestionText { get; set; }
        public List<string> AnswerVariants { get; set; }

        public Question()
        {
            AnswerVariants = new List<string>();
        }

        public void ShowQuestion()
        {
            Console.WriteLine($"{QuestionText}");
            int count = 0;
            foreach (var variant in AnswerVariants)
            {
                Console.WriteLine($"\t{++count}) {variant}");
            } 
        }
    }
}
