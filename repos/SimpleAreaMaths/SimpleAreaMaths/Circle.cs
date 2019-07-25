using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAreaMaths
{
    class Circle
    {
        private int radius;

        public Circle()
        {
            radius = 0;
        }

        public Circle(int initialRadius)
        {
            radius = initialRadius;
           
        }

        public double Area()
        {
            return Math.PI * radius * radius;
        }
    }

    
}
