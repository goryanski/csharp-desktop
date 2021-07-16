using StoreApp.BLL.DTO;
using StoreApp.BLL.Services;
using StoreApp.DAL.Interfaces;
using StoreApp.DAL.Repositories;
using StoreApp.UI.Console;
using System;
using System.Collections.Generic;

namespace StoreApp
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
