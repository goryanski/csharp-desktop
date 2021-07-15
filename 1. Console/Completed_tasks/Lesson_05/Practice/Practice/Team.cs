using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Team
    {
        public IWorker TeamLead { get; set; }
        public Worker[] Workers { get; set; }


        
        public void CreateTeam(int countWorkers)
        {
            TeamLead = new TeamLeader();
            Workers = new Worker[countWorkers];

            for (int i = 0; i < Workers.Length; i++)
            {
                Workers[i] = new Worker();
            }
        }
    }
}
