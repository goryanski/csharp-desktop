using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Practice.Models.Database;
using Practice.Models.Database.Entities;
using Practice.Models.Database.Repository;

namespace Practice.App.Helpers
{
    public abstract class BaseJournalManager 
    {              
        protected DatabaseContext context;

        public BaseJournalManager()
        {
            context = new DatabaseContext();      
        }
        
        public List<T> ShowEntitiesList<T>(List<T> entity)
        {
            if (entity.Count > 0)
            {
                Console.WriteLine("\nFull list:");
                int count = 0;
                entity.ForEach((e) =>
                {
                    Console.WriteLine($"[{++count}] {e}");
                });
            }
            else
            {
                Console.WriteLine("There are nothing");
            }

            return entity;
        }

        public T GetSelectedEntity<T> (List<T> entity) where T : BaseEntity
        {
            List<T> entities = ShowEntitiesList(entity);
            if (entities.Count > 0)
            {
                Console.Write("\nChoose number: ");
                int select;
                int.TryParse(Console.ReadLine(), out select);

                while (select < 1 || select > entities.Count)
                {
                    Console.Write("Wrong number, try again: ");
                    int.TryParse(Console.ReadLine(), out select);
                }
                return entities[select - 1];
            }
            return null;
        }
    }
}

