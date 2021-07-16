using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Tasks;
using PracticeApp.DAL.Entities;
using PracticeApp.DAL.Repositories;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {

            TasksExecutor exec = new TasksExecutor();

            exec.Task_1_CreateDefaultUser();
            //exec.Task_2_FindUsersByName();
            //exec.Task_3_BlockSelectedUser();
            //exec.Task_4_MakeOrderForUser();
            //exec.Task_5_ShowOrdersSelectedUser();
            //exec.Task_6_ShowOrdersByRange();        

            Console.Read();
        }
    }
}
