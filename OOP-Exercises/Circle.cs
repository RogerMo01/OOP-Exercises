using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exercises
{
    class Circle
    {
        public double Radius { get; private set; }

        public Circle()
        {
            Radius = 0;
        }
        public Circle(double radius)
            : this()
        {
            Radius = radius;
        }

        public double GetRadius()
        {
            return Radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;            
        }
    }
}
