using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Application
    {
        enum Act
        {
            CREATE = 1,
            WRITE,
            READ,
            PARSE
        }

        FileHelper fileHelper = new FileHelper();
        FileParts FileParts = new FileParts();
        public string FileName { get; set; }

        public Application() => FileName = "Day17.txt";

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
        void Menu()
        {
            Console.WriteLine("\n\n[1] Just create file");
            Console.WriteLine("[2] Write info to file");
            Console.WriteLine("[3] Open file and read info");
            Console.WriteLine("[4] Parse file"); 
            Console.WriteLine("[0] Exit");
            Console.Write("Your choose: ");
        }
        void Action(int select)
        {          
            switch (select)
            {
                case (int)Act.CREATE:                   
                    fileHelper.JustCreateFile(FileName);
                    break;
                case (int)Act.WRITE:
                    fileHelper.WriteInfo(FileName);
                    break;
                case (int)Act.READ:
                    fileHelper.ReadInfo(FileName);
                    break;
                case (int)Act.PARSE:
                    FileParts.Parsing(FileName);
                    FileParts.ShowParsedFile();
                    break;
            }
        }
    }
}
