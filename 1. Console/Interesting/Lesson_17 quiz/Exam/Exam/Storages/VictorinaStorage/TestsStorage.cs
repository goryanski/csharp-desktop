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
    class TestsStorage
    {
        private static TestsStorage instance;
        public static TestsStorage Instance { get => instance ?? (instance = new TestsStorage()); }
        public List<Test> Tests { get; set; }
        BinaryFormatter formatter;
        PathsStorage pathsStorage;

        private TestsStorage()
        {
            Tests = new List<Test>();
            formatter = new BinaryFormatter();
            pathsStorage = PathsStorage.Instance;
            LoadData();          
        }

        void LoadData()
        {
            if (File.Exists(pathsStorage.TESTS_PATH))
            {
                Tests.Clear();
                using (FileStream fs = new FileStream(pathsStorage.TESTS_PATH, FileMode.Open, FileAccess.Read))
                {
                    Tests = formatter.Deserialize(fs) as List<Test>;
                }
            }
        }
        void SaveData()
        {
            using (FileStream fs = new FileStream(pathsStorage.TESTS_PATH, FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(fs, Tests);
            }
        }

        // только в классах-хранилищах будем работать напрямую с файлом
        public void AddTest(Test test)
        {
            Tests.Add(test);
            SaveData();
        }
        public void DeleteTest(int idx)
        {
            Tests.RemoveAt(idx);
            SaveData();
        }
        public void EditAllTest(int idx, Test test)
        {
            Tests[idx] = test;
            SaveData();
        }

        public void ChangeQuestion(int idx, int questionNumber, Question question)
        {
            Tests[idx].Questions[questionNumber] = question;
            SaveData();
        }

        public void ChangeQuestionText(int idx, int questionNumber, string newQuestionText)
        {
            Tests[idx].Questions[questionNumber].QuestionText = newQuestionText;
            SaveData();
        }
    }
}
