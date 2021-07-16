using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Practice.Models.Database.Entities;
using Practice.Models.Database.Repository;

namespace Practice.App.Helpers
{
    public class JournalMarksManager : BaseJournalManager
    {
        MarksRepository marksRepository;
        public JournalMarksManager()
        {
            marksRepository = new MarksRepository(context);
        }
        internal void AddMark()
        {
            Student selectedStudent = GetSelectedEntity (
                context.Students.Include(s => s.Lessons).ToList()
            );           

            if (selectedStudent != null)
            {
                Lesson lesson = GetSelectedEntity(selectedStudent.Lessons);

                Console.Write("Enter new mark (1-12): ");
                int markValue = SafelyInput(new int());

                marksRepository.Create(new Mark { Value = markValue, Lesson = lesson, Student = selectedStudent });
                Console.WriteLine("Success");             
            }
        }

        internal void EditMark()
        {
            Student selectedStudent = GetSelectedEntity(
                context.Students.Include(s => s.Lessons).ToList()
            );

            if (selectedStudent != null)
            {
                Lesson lesson = GetSelectedEntity(selectedStudent.Lessons);

                List<Mark> selectedStudentMarks = marksRepository.GetAll()
                       .Where(mark => mark.StudentId == selectedStudent.Id &&
                       mark.LessonId == lesson.Id).ToList();

                if(selectedStudentMarks.Count > 0)
                {
                    Mark selectedMark = GetSelectedEntity(selectedStudentMarks);
                    Console.Write("Enter new mark (1-12): ");                  
                    selectedMark.Value = SafelyInput(new int());

                    marksRepository.Update(selectedMark);
                    Console.WriteLine("Success");                  
                }
                else
                {
                    Console.WriteLine("There're no marks yet");
                }
            }
        }

        internal void DeleteMark()
        {
            Student selectedStudent = GetSelectedEntity(
                context.Students.Include(s => s.Lessons).ToList()
            );

            if (selectedStudent != null)
            {
                Lesson lesson = GetSelectedEntity(selectedStudent.Lessons);

                List<Mark> selectedStudentMarks = marksRepository.GetAll()
                       .Where(mark => mark.StudentId == selectedStudent.Id &&
                       mark.LessonId == lesson.Id).ToList();

                if (selectedStudentMarks.Count > 0)
                {
                    Mark selectedMark = GetSelectedEntity(selectedStudentMarks);

                    marksRepository.Remove(selectedMark.Id);
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("There're no marks yet");
                }
            }
        }

        public int SafelyInput(int value)
        {
            int.TryParse(Console.ReadLine(), out value);
            while (value <= 0 || value > 12)
            {
                Console.Write("Wrong value, try again: ");
                int.TryParse(Console.ReadLine(), out value);
            }
            return value;
        }

        public void ShowMarks()
        {
            Student selectedStudent = GetSelectedEntity(
                context.Students.Include(s => s.Lessons).ToList()
            );

            if (selectedStudent != null)
            {
                int count = 0;
                int marksCount;
                foreach (var lesson in selectedStudent.Lessons)
                {
                    marksCount = 0;

                    List<Mark> selectedStudentMarks = context.Marks
                        .Where(mark => mark.StudentId == selectedStudent.Id &&
                        mark.LessonId == lesson.Id).ToList();

                    Console.Write($"[{++count}] {lesson} (marks:");

                    selectedStudentMarks.ForEach(mark =>
                    {
                        Console.Write($" {mark}");
                        marksCount++;
                    });

                    Console.WriteLine(marksCount != 0 ? ")" : " not yet)");
                }
            }
        }
    }
}
