using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook();

            //GetBookName(book);

            AddGrades(book);

            SaveGrades(book);
            WriteResults(book);

            ISimpleClass someVarThing = new SimpleClass();
           int number = someVarThing.addSomething(3, 4);
            Console.WriteLine(number);
        }

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }
            WriteResults("Average", stats.AverageGrade);
            WriteResults("Highest Grade", stats.HighestGrade);
            WriteResults("Lowest Grade", stats.LowestGrade);
            WriteResults(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void WriteResults(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");
        }

        static void WriteResults(string description, float result)
        {
            Console.WriteLine($"{description} : {result:F2}");
        }
    }
}
