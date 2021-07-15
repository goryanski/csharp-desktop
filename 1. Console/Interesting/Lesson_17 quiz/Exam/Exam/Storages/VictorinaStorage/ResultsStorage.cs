using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Exam.Models.Victorina;

namespace Exam.Storages.VictorinaStorage
{
    class ResultsStorage
    {
        private static ResultsStorage instance;
        public static ResultsStorage Instance { get => instance ?? (instance = new ResultsStorage()); }

        public const int BEST_RESULTS_MAX_COUNT = 20;
        public List<TestResult> Results { get; set; }
        BinaryFormatter formatter;
        PathsStorage pathsStorage;

        private ResultsStorage()
        {
            Results = new List<TestResult>();
            formatter = new BinaryFormatter();
            pathsStorage = PathsStorage.Instance;
            LoadData();           
        }

        void LoadData()
        {
            if (File.Exists(pathsStorage.RESULTS_PATH))
            {
                Results.Clear();
                using (FileStream fs = new FileStream(pathsStorage.RESULTS_PATH, FileMode.Open, FileAccess.Read))
                {
                    Results = formatter.Deserialize(fs) as List<TestResult>;
                }
            }
        }
        void SaveData()
        {
            using (FileStream fs = new FileStream(pathsStorage.RESULTS_PATH, FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(fs, Results);
            }
        }

        public List<TestResult> GetBestResults(List<TestResult> results)
        {
            var sortedResults = results.OrderByDescending(r => r.CountRightAnswers).ToList();
            
            if (sortedResults.Count > BEST_RESULTS_MAX_COUNT)
            {
                // оставим только 20 (по условию задания нужно топ-20)
                return sortedResults.Take(BEST_RESULTS_MAX_COUNT).ToList();
            }
            return sortedResults;
        }

        public int GetNewcomerPlace(int newcomerResult, string testName)
        {
            var resultsByTestName = Results.Where(r => r.TestName.Equals(testName)).ToList();
            // если результатов нет - это первый и он получит 1-е место 
            if (resultsByTestName.Count == 0) return 1;

            var bestResults = GetBestResults(resultsByTestName);
            for (int i = 0; i < bestResults.Count; i++)
            {
                // если новый результат будет больше, чем какой либо из результатов в отсортированном списке, то он получит его место в рейтинге (i + 1) - фактическое место
                if (newcomerResult > bestResults[i].CountRightAnswers) return i + 1;
            }

            // если он не получил место в рейтинге, и в рейтинге уже есть 20 лучших результатов - этот участник не попадает в таблицу лидеров
            if (bestResults.Count == BEST_RESULTS_MAX_COUNT) return -1;
            // иначе, если участников меньше 20 - получает последнее место 
            else return bestResults.Count + 1;
        }

        public void AddResult(string userLogin, int countRightAnswers, string testName)
        {
            // если пользователь уже сдавал этот тест - просто отредактируем результат
            if (Results.Any(r => r.Name.Equals(userLogin) && r.TestName.Equals(testName))) 
            {
                int idx = Results.FindIndex(r => r.Name.Equals(userLogin) && r.TestName.Equals(testName));
                Results[idx].CountRightAnswers = countRightAnswers;
            }
            // иначе - создадим новый
            else
            {
                Results.Add(new TestResult { Name = userLogin, CountRightAnswers = countRightAnswers, TestName = testName});
            }   

            SaveData();
        }
    }
}
