using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exercises
{

    class Circle
    {
        public const double Pi = 3.1416;
        public double Diameter { get; private set; }
        public double Radius { get; private set; }


        public Circle() { }
        public Circle(double radius)
            : this()
        {
            Radius = radius;
            Diameter = 2 * radius;
        }


        public double GetRadius()
        {
            return Radius;
        }

        public double GetArea()
        {
            return Pi * Math.Pow(Radius, 2);
        }

        public double GetPerimeter()
        {
            return 2 * Pi * Radius;            
        }


    }
}
