using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Models;
using Exam.Storages;

namespace Exam.TestManagementUtility
{
    class TestsManagement
    {
        TestsStorage testsStorage;
        AnswersStorage answersStorage;

        public TestsManagement()
        {
            testsStorage = TestsStorage.Instance;
            answersStorage = AnswersStorage.Instance;
        }


        public void AddTest()
        {
            var info = FillTestInfo();

            // обойдемся без валидации теста и ответов, поскольку в этом нет смысла, тесты будет добавлять только админ, там ошибиться не получится, да и всегда можно отредактировать, если что

            testsStorage.AddTest(info.test);
            answersStorage.AddAnswers(info.testAnswer);
            Console.WriteLine("Test was added.");
        }
        public void DeleteTest()
        {
            int select = SelectTest() - 1;
            if (select < 0) return;

            testsStorage.DeleteTest(select);
            answersStorage.DeleteAnswers(select);
            Console.WriteLine("Test was deleted.");
        }
        public void EditAllTest()
        {
            int select = SelectTest() - 1;
            if (select < 0) return;

            var info = FillTestInfo();
            testsStorage.EditAllTest(select, info.test);
            answersStorage.EditAllTestAnswers(select, info.testAnswer);

            Console.WriteLine("Test was edited.");
        }
        public void EditQuestion()
        {
            int selectTest = SelectTest() - 1;
            if (selectTest < 0) return;

            int selectQuestion =  SelectQuestion(selectTest) - 1;           
            Question question = FillQuestion();

            QuestionAnswer answer = new QuestionAnswer();
            answer.QuestionNumber = selectQuestion + 1;
            FillQuestionAnswers(answer, question);

            testsStorage.ChangeQuestion(selectTest, selectQuestion, question);
            answersStorage.ChangeAnswer(selectTest, selectQuestion, answer);
            Console.WriteLine("Question was edited");
        }
        public void EditAnswer()
        {
            int selectTest = SelectTest() - 1;
            if (selectTest < 0) return;

            int selectQuestion = SelectQuestion(selectTest) - 1;
            Question question = testsStorage.Tests[selectTest].Questions[selectQuestion];

            QuestionAnswer answer = new QuestionAnswer();
            answer.QuestionNumber = selectQuestion + 1;
            FillQuestionAnswers(answer, question);

            answersStorage.ChangeAnswer(selectTest, selectQuestion, answer);
            Console.WriteLine("Answer was edited");
        }
        public void EditQuestionText()
        {
            int selectTest = SelectTest() - 1;
            if (selectTest < 0) return;

            int selectQuestion = SelectQuestion(selectTest) - 1;
            Console.WriteLine("Enter new question text: ");
            testsStorage.ChangeQuestionText(selectTest, selectQuestion, Console.ReadLine());
            Console.WriteLine("Question text was edited");
        }


        #region Вспомогательные методы
        (Test test, TestAnswer testAnswer) FillTestInfo()
        {
            Console.WriteLine("\nEnter info:");

            Test test = new Test();
            Console.Write("Enter test name: ");
            test.TestName = Console.ReadLine();

            TestAnswer testAnswer = new TestAnswer();
            testAnswer.TestName = test.TestName;

            for (int i = 1; i <= Test.QUESTIONS_COUNT; i++)
            {
                Question question = FillQuestion();
                test.Questions.Add(question);

                QuestionAnswer generalAnswer = new QuestionAnswer();
                generalAnswer.QuestionNumber = i;
                FillQuestionAnswers(generalAnswer, question);
                testAnswer.TestAnswers.Add(generalAnswer);
            }

            return (test, testAnswer);
        }
        Question FillQuestion()
        {
            Question question = new Question();

            Console.WriteLine("Enter Question: ");
            question.QuestionText = Console.ReadLine();

            Console.Write("How many answer variants you want to add? (1-6): ");
            int countVariants;
            int.TryParse(Console.ReadLine(), out countVariants);
            while (countVariants < 1 || countVariants > 6)
            {
                Console.Write("Wrong number, try again: ");
                int.TryParse(Console.ReadLine(), out countVariants);
            }
            for (int j = 1; j <= countVariants; j++)
            {
                Console.WriteLine($"Enter answer variant #{j}: ");
                question.AnswerVariants.Add(Console.ReadLine());
            }

            return question;
        }
        void FillQuestionAnswers(QuestionAnswer generalAnswer, Question question)
        {
            Console.Write("How many right answers for this question you want to add? ");
            int countRightAnswers;
            int.TryParse(Console.ReadLine(), out countRightAnswers);
            while (countRightAnswers < 1 || countRightAnswers > question.AnswerVariants.Count)
            {
                Console.Write("Wrong number, try again: ");
                int.TryParse(Console.ReadLine(), out countRightAnswers);
            }
            for (int j = 1; j <= countRightAnswers; j++)
            {
                Console.WriteLine("Enter number of right answer variant: ");
                int rightAnswer;
                int.TryParse(Console.ReadLine(), out rightAnswer);
                while (rightAnswer < 1 || rightAnswer > question.AnswerVariants.Count)
                {
                    Console.Write("Wrong number, try again: ");
                    int.TryParse(Console.ReadLine(), out rightAnswer);
                }

                generalAnswer.QuestionAnswers.Add(rightAnswer);
            }
        }
        bool ShowTestsName()
        {
            if (testsStorage.Tests.Count > 0)
            {
                Console.WriteLine("\nList of all tests:");
                int count = 0;
                testsStorage.Tests.ForEach((test) =>
                {
                    Console.WriteLine($"[{++count}] {test.TestName}");
                });
                return true;
            }
            else
            {
                Console.WriteLine("There're no any tests");
                return false;
            }
        }
        public void ShowTestQuestions(int testNumber)
        {
            Console.WriteLine("\nList of all questions:");
            int count = 0;
            int number = 0;
            testsStorage.Tests[testNumber].Questions.ForEach((question) =>
            {
                Console.Write($"[{++count}] ");
                question.ShowQuestion();
                answersStorage.AllAnswers[testNumber].TestAnswers[number++].ShowAnswers();
            });

        }
        public int SelectTest()
        {
            // если нечего показывать то и нечего выбирать
            if (!ShowTestsName()) return -1;

            Console.Write("\nChoose test number: ");
            int select;
            int.TryParse(Console.ReadLine(), out select);

            while (select < 1 || select > testsStorage.Tests.Count)
            {
                Console.Write("Wrong number, try again: ");
                int.TryParse(Console.ReadLine(), out select);
            }
            return select;
        }
        int SelectQuestion(int testNumber)
        {
            ShowTestQuestions(testNumber);

            Console.Write("\nChoose question number: ");
            int select;
            int.TryParse(Console.ReadLine(), out select);

            while (select < 1 || select > Test.QUESTIONS_COUNT)
            {
                Console.Write("Wrong number, try again: ");
                int.TryParse(Console.ReadLine(), out select);
            }
            return select;
        }
        #endregion
    }
}
