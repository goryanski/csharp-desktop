using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.VictorinaApplication;

namespace Exam
{
    class QuizApp
    {
        enum Act { START = 1, MIXED_QUIZ, RESULTS, SHOW_TOP_20, CHANGE_SETTINGS}

        // будем здесь хранить статическую переменную с логином что бы не пробрасывать его во все последующие классы
        public static string userLogin;

        QuizManagement quiz;

        public void Start(string login)
        {
            userLogin = login;
            // выделяем память после инициализации статической переменно, иначе она не будет доступна в QuizManagement
            quiz = new QuizManagement();        

            int select = -1; ;
            while (select != 0)
            {
                Console.Clear();

                Menu();
                int.TryParse(Console.ReadLine(), out select);
                Action(select);

                if (select != 0)
                {
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadKey();
                }
            }
        }
        void Menu()
        {
            Console.WriteLine("[1] Start new Quiz");
            Console.WriteLine("[2] Start mixed Quiz");
            Console.WriteLine("[3] Show your results");
            Console.WriteLine("[4] Show top-20 participants");
            Console.WriteLine("[5] Change settings");
            Console.WriteLine("[0] Log out");
            Console.Write("Your choose: ");
        }

        void Action(int select)
        {
            switch (select)
            {
                case (int)Act.START:
                   quiz.StartNew();
                    break;
                case (int)Act.MIXED_QUIZ:
                   quiz.MixedQuiz();
                    break;
                case (int)Act.RESULTS:
                   quiz.ShowUserResults();
                    break;
                case (int)Act.SHOW_TOP_20:
                    quiz.ShowTop();
                    break;
                case (int)Act.CHANGE_SETTINGS:
                    new EditMenu().Start();
                    break;
            }
        }
    }
}
