using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Exam.Models;

namespace Exam.Storages
{
    class AnswersStorage
    {
        private static AnswersStorage instance;
        public static AnswersStorage Instance { get => instance ?? (instance = new AnswersStorage()); }
        public List<TestAnswer> AllAnswers { get; set; }
        BinaryFormatter formatter;
        PathsStorage pathsStorage;

        private AnswersStorage()
        {
            AllAnswers = new List<TestAnswer>();
            formatter = new BinaryFormatter();
            pathsStorage = PathsStorage.Instance;
            LoadData();
            
        }

        void LoadData()
        {
            if (File.Exists(pathsStorage.ANSWERS_PATH))
            {
                AllAnswers.Clear();
                using (FileStream fs = new FileStream(pathsStorage.ANSWERS_PATH, FileMode.Open, FileAccess.Read))
                {
                    AllAnswers = formatter.Deserialize(fs) as List<TestAnswer>;
                }
            }
        }
        void SaveData()
        {
            using (FileStream fs = new FileStream(pathsStorage.ANSWERS_PATH, FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(fs, AllAnswers);
            }
        }
        public void AddAnswers(TestAnswer answer)
        {
            AllAnswers.Add(answer);
            SaveData();
        }
        public void DeleteAnswers(int idx)
        {
            AllAnswers.RemoveAt(idx);
            SaveData();
        }
        public void EditAllTestAnswers(int idx, TestAnswer answer)
        {
            AllAnswers[idx] = answer;
            SaveData();
        }
        public void ChangeAnswer(int idx, int answerNumber, QuestionAnswer answer)
        {
            AllAnswers[idx].TestAnswers[answerNumber] = answer;
            SaveData();
        }
    }
}
