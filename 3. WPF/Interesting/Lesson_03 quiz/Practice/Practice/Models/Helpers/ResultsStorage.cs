using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Practice.Models.Helpers
{
    class ResultsStorage
    {
        private static ResultsStorage instance;
        public static ResultsStorage Instance { get => instance ?? (instance = new ResultsStorage()); }

        const string PATH = "results.xml";
        public BindingList<Result> Results { get; set; }

        private ResultsStorage()
        {
            Results = new BindingList<Result>();
            LoadUsers();
        }

        private void LoadUsers()
        {
            if (File.Exists(PATH))
            {
                var formatter = new XmlSerializer(typeof(BindingList<Result>));

                using (var fs = new FileStream(PATH, FileMode.Open, FileAccess.Read))
                {
                    Results = formatter.Deserialize(fs) as BindingList<Result>;
                }
            }
        }

        public void SaveToFile()
        {
            var formatter = new XmlSerializer(typeof(BindingList<Result>));

            using (var fs = new FileStream(PATH, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fs, Results);
            }
        }

        internal bool ResultExist(Result result)
        {
            if (Results.Any(r => r.UserName.Equals(result.UserName)))
            {
                return true;
            }
            return false;
        }

        public void ChangeResult(Result result)
        {
            // чтобы воспользоваться FindIndex
            List<Result> tmp = Results.ToList();
            // поскольку перед этим была проверка на существование результата - можем смело пользоваться FindIndex без проверок
            var idx = tmp.FindIndex(r => r.UserName.Equals(result.UserName));
            Results[idx].Score = result.Score;
        }
    }
}
