using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Practice.App;
using Practice.Models.Database;
using Practice.Models.Database.Entities;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Init by default
            //using (DatabaseContext ctx = new DatabaseContext())
            //{

            //    Journal journal1 = new Journal { Name = "11 - B" };
            //    Journal journal2 = new Journal { Name = "11 - A" };

            //    Student student1 = new Student
            //    {
            //        FirstName = "Vasya",
            //        LastName = "Vasyliev",
            //        Journal = journal1
            //    };
            //    Student student2 = new Student
            //    {
            //        FirstName = "Katya",
            //        LastName = "Ivanova",
            //        Journal = journal1
            //    };
            //    Student student3 = new Student
            //    {
            //        FirstName = "Masha",
            //        LastName = "Grigorieva",
            //        Journal = journal2
            //    };
            //    Student student4 = new Student
            //    {
            //        FirstName = "Tomara",
            //        LastName = "Mironova",
            //        Journal = journal2
            //    };

            //    ctx.Students.AddRange(new Student[] { student1, student2, student3, student4 });


            //    Lesson lesson1 = new Lesson { Name = "Math" };
            //    Lesson lesson2 = new Lesson { Name = "English" };
            //    Lesson lesson3 = new Lesson { Name = "Philosophy" };


            //    lesson1.Students.AddRange(new Student[] { student1, student2 });
            //    lesson2.Students.AddRange(new Student[] { student3, student4 });
            //    lesson3.Students.AddRange(new Student[] { student1, student2, student3, student4 });


            //    Mark mark1 = new Mark { Value = 10, Lesson = lesson1, Student = student2 };
            //    Mark mark2 = new Mark { Value = 11, Lesson = lesson1, Student = student1 };
            //    Mark mark3 = new Mark { Value = 12, Lesson = lesson2, Student = student3 };
            //    Mark mark4 = new Mark { Value = 9, Lesson = lesson2, Student = student4 };
            //    Mark mark5 = new Mark { Value = 7, Lesson = lesson3, Student = student1 };
            //    Mark mark6 = new Mark { Value = 8, Lesson = lesson3, Student = student2 };
            //    Mark mark7 = new Mark { Value = 6, Lesson = lesson3, Student = student3 };
            //    Mark mark8 = new Mark { Value = 5, Lesson = lesson3, Student = student4 };

            //    ctx.Marks.AddRange(new Mark[] { mark1, mark2, mark3, mark4, mark5, mark6, mark7, mark8 });


            //    ctx.SaveChanges();
            //    var jornal = ctx.Journals.Include(j => j.Students).First();

            //}
            #endregion

            new Application().Start();          
        }
    }
}
