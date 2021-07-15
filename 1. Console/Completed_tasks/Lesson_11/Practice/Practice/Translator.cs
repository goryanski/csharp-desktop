using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Translator
    {
        public Dictionary<string, string> EngRuDictionary()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("Great Britain", "Великобритания");
            dictionary.Add("USA", "США");
            dictionary.Add("Ukraine", "Украина");
            dictionary.Add("France", "Франция");
            dictionary.Add("China", "Китай");
            dictionary.Add("Russia", "Россия");

            return dictionary;
        }
        public Dictionary<string, string> RuEngDictionary()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("Великобритания", "Great Britain");
            dictionary.Add("США", "USA");
            dictionary.Add("Украина", "Ukraine");
            dictionary.Add("Франция", "France");
            dictionary.Add("Китай", "China");
            dictionary.Add("Россия", "Russia");

            return dictionary;
        }
    }
}
