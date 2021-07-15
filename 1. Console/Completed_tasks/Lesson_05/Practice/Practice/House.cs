using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class House
    {
        int count;
        public IPart[] Parts { get; set; }

        public House(int size)
        {
            Parts = new IPart[size];
        }

        public void StartBuild()
        {
            // создадим команду
            Team team = new Team();
            team.CreateTeam(8);

            // создадим проект дома, в котором будем описывать текущее состояние постройки 
            HouseProject project = new HouseProject();

            Console.WriteLine("The team started build");

            // рабочие построили фундамент. добавим его в массив частей дома и вычеркнем из списка задач в проекте
            Basement basement = new Basement();
            AddPart(basement);
            --project.Basement;

            Console.WriteLine("The basement was built");

            TeamLeader teamLeader = new TeamLeader();

            //тим лид проверяет, все ли построенно. либо стройка окончена и можно писать отчет, либо  он говорит рабочим продолжать стройку и говорит что именно нужно строить дальше 
            teamLeader.CheckBuild();
            if (project.IsHouseBuilt())
            {
                teamLeader.MakeReport();
            } 
            else
            {
                foreach (var worker in team.Workers)
                {
                    worker.RunBuild("Walls");
                }
            }

            // рабочие строят стены, пока не построят все, с каждым разом добавляем в массив каждую стену и вычеркиваем ее  из задач в проекте
            while (project.Walls != 0)
            {
                Wall wall = new Wall();
                AddPart(wall);
                --project.Walls;
            }

            // Тим лид снова проверяет и говорит что строить дальше 
            teamLeader.CheckBuild();
            if (project.IsHouseBuilt())
            {
                teamLeader.MakeReport();
            }
            else
            {
                foreach (var worker in team.Workers)
                {
                    worker.RunBuild("Windows");
                }
            }


            // так продалжается, пока не будет построенно все (пока не вычеркнем из проекта все поставленные задачи)  и в конце концов сработает метод teamLeader.MakeReport()  - это и будет окончанием стройки
            Console.WriteLine("To be continued...");
        }

        public void AddPart(IPart part)
        {
            if (count == Parts.Length)
            {
                IPart[] parts = new IPart[Parts.Length + 5];

                Array.Copy(Parts, 0, parts, 0, Parts.Length);
                Parts = parts;
            }
            Parts[count++] = part;
        }
    }
}
