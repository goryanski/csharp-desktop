using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Application
    {
        enum Act { ENG_RU = 1, RU_ENG }
        const int TO_TRANSLATE = 1;

        Translator translator;

        public Application() => translator = new Translator();

        public void Start()
        {
            int select = -1; ;
            while (select != 0)
            {
                Menu();
                int.TryParse(Console.ReadLine(), out select);
                Action(select);
            }
        }
        public void Menu()
        {
            Console.WriteLine("[1] Eng-Ru dictionary");
            Console.WriteLine("[2] Ru-Eng dictionary");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("Your choose: ");
        }
        public void Action(int select)
        {
            Dictionary<string, string> wordsList;

            switch (select)
            {
                case (int)Act.ENG_RU:
                    wordsList = translator.EngRuDictionary();
                    RunTranslator(wordsList);
                    break;
                case (int)Act.RU_ENG:
                    wordsList = translator.RuEngDictionary();
                    RunTranslator(wordsList);
                    break;
            }
        }

        public void RunTranslator(Dictionary<string, string> wordsList)
        {
            foreach (var word in wordsList)
            {
                Console.WriteLine(word.Key);

                if (GetSelect() == TO_TRANSLATE)
                {
                    Console.WriteLine($"Translate: {word.Value}");
                }
                Console.WriteLine();
            }
        }

        int GetSelect()
        {
            Console.WriteLine("[1] - Translate this word, [2] Skip");
            int select;
            int.TryParse(Console.ReadLine(), out select);

            while (select < 1 || select > 2)
            {
                Console.Write("Wrong number, try again: ");
                int.TryParse(Console.ReadLine(), out select);
            }

            return select;
        }
    }
}
