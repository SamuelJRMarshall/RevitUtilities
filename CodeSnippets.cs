using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayDaysOfWeek
{
    class CodeSnippets
    {
        //Call this method from the streamreader
        public Student ReadStudentFromFile(string line)
        {
            string[] parts = line.Split(new char[] { ',' });
            return new Student(parts[0], parts[1], parts[2], int.Parse(parts[3]));
        }
        public int HowtoTryParse(string parse)
        {
            int.TryParse(parse, out int value);
            return value;
        }
    }
}
