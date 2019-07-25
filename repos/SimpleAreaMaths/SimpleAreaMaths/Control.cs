using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAreaMaths
{
    class Control
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            Loop();
        }
        
        static void Loop(int radius = 10)
        {
            Circle c;
            c = new Circle(radius);
            Console.WriteLine(c.Area());
            c = null;
            string nextRad = Console.ReadLine();
            int rad = int.Parse(nextRad);
            Loop(rad);

        }
    }
}
