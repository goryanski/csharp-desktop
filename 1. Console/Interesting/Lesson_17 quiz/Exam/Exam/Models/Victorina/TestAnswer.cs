using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    [Serializable]
    class TestAnswer
    {
        public string TestName { get; set; }

        // по условию задания в каждом вопросе может быть несколько правильных ответов - создадим отдельный класс для каждого ответа QuestionAnswer. и здесь будут ответы на весь тест
        public List<QuestionAnswer> TestAnswers;

        public TestAnswer()
        {
            TestAnswers = new List<QuestionAnswer>();
        }
    }
}
