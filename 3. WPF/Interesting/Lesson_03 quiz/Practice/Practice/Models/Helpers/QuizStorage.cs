using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Models.Helpers
{
    class QuizStorage
    {
        // Поскольку нет смысла для каждого вопроса создавать отдельный список вариантов ответа (они одинаковые для всех вопросов), то и нет смысла создавать отдельный класс Question и QuestionStorage - достаточно одного общего хранилища для викторины
        public List<string> Questions { get; set; } = new List<string>
        {
            "1. В мире 6 океанов?",
            "2. Капитана Немо придумал Жюль Верн?",
            "3. Мандолина – это фрукт?",
            "4. В геноме человека 46 хромосом?",
            "5. У мухи два глаза?",
            "6. Склифосовский – это поэт?",
            "7. Существует Слоновья гора?",
            "8. Керамическая кружка сделана из глины?",
            "9. На земном шаре 24 часовых пояса?",
            "10. Розовые фламинго не умеют летать"
        };
        public List<string> AnswersVariants { get; set; } = new List<string>
        {
            "Да",
            "Нет",
            "Не знаю"
        };
        public List<string> RightAnswers { get; set; } = new List<string>
        {
             "Нет",
             "Да",
             "Нет",
             "Да",
             "Да",
             "Нет",
             "Да",
             "Да",
             "Да",
             "Нет"
        };
    }
}
