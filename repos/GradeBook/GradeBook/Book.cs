using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book :  NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
    }

    public class InMemoryBook: Book
    {
        private List<double> grades = new List<double>();

        public InMemoryBook(string name) : base(name)
        {
            Name = name;
        }

        public override void AddGrade(double grade)
        {
            grades.Add(grade);
            GradeAdded(this, new EventArgs());
        }

        public override event GradeAddedDelegate GradeAdded;
    }

    public class DiskBook : Book
    {
        private List<double> grades = new List<double>();

        public DiskBook(string name) : base(name)
        {
            Name = name;
        }

        public override void AddGrade(double grade)
        {
            var writer = File.AppendText($"{Name}.txt");
            writer.WriteLine(grade);
            GradeAdded(this, new EventArgs());
        }

        public override event GradeAddedDelegate GradeAdded;
    }
}
