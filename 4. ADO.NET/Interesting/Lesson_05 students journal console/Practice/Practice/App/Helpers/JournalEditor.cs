using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Practice.Models.Database.Entities;
using Practice.Models.Database.Repository;

namespace Practice.App.Helpers
{
    class JournalEditor : BaseJournalManager
    {
        internal void AddStudent()
        {
            Journal selectedJournal = GetSelectedEntity(new JournalsRepository(context).GetAll());

            Console.Write("Enter firstname: ");
            string firstname = Console.ReadLine();
            Console.Write("Enter lastname: ");
            string lastname = Console.ReadLine();

            Student student = new Student
            {
                FirstName = firstname,
                LastName = lastname,
                Journal = selectedJournal
            };

            var lessons = new LessonsRepository(context).GetAll();
            foreach (var lesson in lessons)
            {
                lesson.Students.Add(student);
            }

            Console.WriteLine("Success");
            context.SaveChanges();
        }
    }
}
