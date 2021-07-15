using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.AuthenticationHelper;
using Exam.Models;
using Exam.Storages;
using NLog;

namespace Exam.TestManagementUtility
{
    class EditMenu
    {
        enum Act
        {
            EDIT_ALL = 1,
            EDIT_QUESTION,
            EDIT_ANSWER,
            EDIT_QUESTION_TEXT
        }

        TestsManagement testManagement = new TestsManagement();

        public void Start()
        {
            int select = -1; ;
            while (select != 0)
            {
                Console.Clear();

                Menu();
                int.TryParse(Console.ReadLine(), out select);
                Action(select);

                if (select != 0)
                {
                    Console.WriteLine("\nPress enter to continue...");
                    Console.ReadKey();
                }
            }
        }
        void Menu()
        {
            Console.WriteLine("[1] Edit all test");
            Console.WriteLine("[2] Edit question (with answer)");
            Console.WriteLine("[3] Edit answer");
            Console.WriteLine("[4] Edit only question text");
            // радактировать отдельно варианты ответов нет смысла, поскольку если изменятся варинты ответа, то изменятся и ответы и скрее всего формулировка вопроса тоже, в таком случае проще воспользоваться полным редактированием вопроса, чем редактировать несколько раз по отдельности - это не удобно
            Console.WriteLine("[0] To main menu");
            Console.Write("Your choose: ");
        }
        void Action(int select)
        {
            switch (select)
            {
                case (int)Act.EDIT_ALL:
                    testManagement.EditAllTest();
                    break;
                case (int)Act.EDIT_QUESTION:
                    testManagement.EditQuestion();
                    break;
                case (int)Act.EDIT_ANSWER:
                    testManagement.EditAnswer();
                    break;
                case (int)Act.EDIT_QUESTION_TEXT:
                    testManagement.EditQuestionText();
                    break;
            }
        }
    }
}
