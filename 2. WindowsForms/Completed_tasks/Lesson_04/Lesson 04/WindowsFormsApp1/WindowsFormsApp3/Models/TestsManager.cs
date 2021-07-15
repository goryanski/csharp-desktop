using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.Models
{
    public class TestsManager
    {
        const string PATH = "tests.xml";
        const int TESTS_COUNT = 8;
        const int QUESTIONS_COUNT = 12;
        const int ANSWERS_COUNT = 4;
        public List<Test> Tests { get; private set; } = new List<Test>();


        private void InitTests()
        {
            List<Test> tests = new List<Test>();
            for (int i = 1; i <= TESTS_COUNT; i++)
            {

                List<Question> questions = new List<Question>();
                for (int j = 1; j <= QUESTIONS_COUNT; j++)
                {

                    List<Answer> answers = new List<Answer>();
                    for (int k = 1; k <= ANSWERS_COUNT; k++)
                    {
                        answers.Add(new Answer
                        {
                            Text = $"Answer {k}",
                            IsCorrect = false
                        });
                    }

                    questions.Add(new Question
                    {
                        Text = $"Question {j}",
                        Answers = answers
                    });
                }

                tests.Add(new Test 
                {
                    Name = $"Some test {i}",
                    Minutes = 60,
                    Questions = questions
                });
            }


            Tests = tests;
            SaveToFile();
        }

        public void Load()
        {
            if (File.Exists(PATH))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (var fs = new FileStream(PATH, FileMode.Open, FileAccess.Read))
                {
                    Tests = formatter.Deserialize(fs) as List<Test>;
                }
            }
            else
            {
                InitTests();
            }
        }

        public void SaveToFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using(var fs = new FileStream(PATH, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fs, Tests);
            }
        }
    }
}
