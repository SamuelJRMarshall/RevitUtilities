using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Book 1");
            book.GradeAdded += OnGradeAdded;
            EnterGrade(book);

        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }

        private static void EnterGrade(IBook book)
        {
            book.AddGrade(90);
            book.AddGrade(80);
            book.AddGrade(70);
        }
    }
}
