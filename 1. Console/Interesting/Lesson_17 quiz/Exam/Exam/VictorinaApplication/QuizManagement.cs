using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Comparers;
using Exam.Models;
using Exam.Storages;
using Exam.Storages.VictorinaStorage;
using Exam.TestManagementUtility;

namespace Exam.VictorinaApplication
{
    class QuizManagement
    {
        TestsStorage testsStorage;
        AnswersStorage answersStorage;
        ResultsStorage resultsStorage;
        TestsManagement testsManagement;
        public string UserLogin { get; set; }

        public QuizManagement()
        {
            testsStorage = TestsStorage.Instance;
            answersStorage = AnswersStorage.Instance;
            resultsStorage = ResultsStorage.Instance;
            testsManagement = new TestsManagement();
            UserLogin = QuizApp.userLogin;           
        }

        public void StartNew()
        {
            int selectTest = testsManagement.SelectTest() - 1;
            if (selectTest < 0) return; // если тестов нет

            // загрузим нужный тест из хранилища
            Test test = testsStorage.Tests[selectTest];
            int countRightAnswers = 0;
            
            for (int i = 0; i < test.Questions.Count; i++)
            {
                RunQuestion(test, selectTest, i, ref countRightAnswers);
            }

            ShowResult(countRightAnswers, test.TestName);
            resultsStorage.AddResult(UserLogin, countRightAnswers, test.TestName);
        }

        public void MixedQuiz()
        {
            int testsCount = testsStorage.Tests.Count;
            if (testsCount < 2)
            {
                Console.WriteLine("Not enought tests for Mixed Quiz");
                return;
            }

            int testNumber = 0;
            int countRightAnswers = 0;
            Random random = new Random();
            for (int i = 0; i < Test.QUESTIONS_COUNT; i++)
            {
                // загрузим нужный тест из хранилища
                Test test = testsStorage.Tests[testNumber];
                int questionNumber = random.Next(0, 20);

                RunQuestion(test, testNumber, questionNumber, ref countRightAnswers);

                // что бы номер теста не выбирать рандомом (если мало тестов, то будет часто повторяться одна из категорий, а значит смешивание тестов будет непропорциональным), мы лучше будем по очереди выбирать каждый тест по кругу
                // когда номер теста увеличивается до количества тестов - сбрасываем номер на 0 и увеличиваем обратно, пока не пройдет 20 вопросов
                if (testNumber < testsCount - 1) testNumber++;
                else testNumber = 0;
            }

            ShowResult(countRightAnswers, "Mixed Quiz");
            resultsStorage.AddResult(UserLogin, countRightAnswers, "Mixed Quiz");
        }

        public void ShowUserResults()
        {
            var userResults = resultsStorage.Results.Where(r => r.Name.Equals(UserLogin)).ToList();
            if(userResults.Count == 0)
            {
                Console.WriteLine("There're no any your tests yet");
                return;
            }

            int count = 0;
            userResults.ForEach(r => Console.WriteLine($"[{++count}] {r}"));
        }

        public void ShowTop()
        {
            // поскольку тест может быть удален, или тест есть, а результатов нет, то названия тестов для выбора будем брать из результатов (результаты всех тестов сохраняются, даже удаленных). Что бы выбрать список неповторяющихся названий тестов воспользуемся Distinct()
            var testsList = resultsStorage.Results.Distinct(new ResultComparer()).ToList();

            if (testsList.Count == 0)
            {
                Console.WriteLine("There're no any results yet");
                return;
            }
            Console.WriteLine();

            // выведем названия тестов на экран и предложим выбрать, по какому тесту показывать топ
            int count = 0;
            testsList.ForEach(t => Console.WriteLine($"[{++count}] {t.TestName}"));

            Console.Write("\nChoose test number: ");
            int select;
            int.TryParse(Console.ReadLine(), out select);

            while (select < 1 || select > testsList.Count)
            {
                Console.Write("Wrong number, try again: ");
                int.TryParse(Console.ReadLine(), out select);
            }
            

            // получим результаты по выбранному тесту
            var resultsByTestName = resultsStorage.Results.Where(r => r.TestName.Equals(testsList[select - 1].TestName)).ToList();

            // получим 20 или меньше отсортированных по убыванию результатов
            var bestResults = resultsStorage.GetBestResults(resultsByTestName);

            // выведем их на экран
            count = 0;
            bestResults.ForEach(r => Console.WriteLine($"<<{++count}>> {r}"));
        }


        #region Вспомогательные методы
        void RunQuestion(Test test, int testNumber, int questionNumber, ref int countRightAnswers)
        {
            // в этом методе мы будем показывать вопрос и получать на него ответ
            Console.Clear();
            Console.WriteLine("There may be several answers, but it isn't exactly");
            test.Questions[questionNumber].ShowQuestion();


            int variantsCount = test.Questions[questionNumber].AnswerVariants.Count;
            Console.Write("How many answers you want to give? ");
            int answersCount;
            int.TryParse(Console.ReadLine(), out answersCount);
            while (answersCount < 1 || answersCount > variantsCount)
            {
                Console.Write("Wrong number, try again: ");
                int.TryParse(Console.ReadLine(), out answersCount);
            }


            List<int> userAnswers = new List<int>();
            for (int k = 0; k < answersCount; k++)
            {
                Console.Write("Your answer number: ");
                int answer;
                int.TryParse(Console.ReadLine(), out answer);
                while (answer < 1 || answer > variantsCount)
                {
                    Console.Write("Wrong number, try again: ");
                    int.TryParse(Console.ReadLine(), out answer);
                }
                userAnswers.Add(answer);
            }

            // получим правильные ответы из хранилища с ответами
            List<int> rightAnswers = answersStorage.AllAnswers[testNumber].TestAnswers[questionNumber].QuestionAnswers;

            // сравним ответы
            if (IsAnswerRight(userAnswers, rightAnswers)) countRightAnswers++;
        }
        void ShowResult(int result, string testName)
        {
            Console.WriteLine($"\nYour right answers count is {result}");
            int place = resultsStorage.GetNewcomerPlace(result, testName);
            if(place != -1)
            {
                Console.WriteLine($"Your place in the table of best participants (by test '{testName}') is {place}");
            }
            else
            {
                Console.WriteLine($"You didn't get a place in the top-{ResultsStorage.BEST_RESULTS_MAX_COUNT} participants (by test '{testName}')");
            }
        }
        bool IsAnswerRight(List<int> userAnswers, List<int> rightAnswers)
        {
            if (userAnswers.Count != rightAnswers.Count) return false;

            for (int i = 0; i < userAnswers.Count; i++)
            {
                if (userAnswers[i] != rightAnswers[i]) return false;
            }
            return true;
        }
        #endregion
    }
}
