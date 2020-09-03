using MathToolsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exercises
{
    class Fraction
    {
        public int Denominator { get; private set; }
        public int Numerator { get; private set; }

        public Fraction() { }
        public Fraction(int denominator, int numerator)
        {
            Denominator = denominator;
            Numerator = numerator;
            CheckFraction(this);
        }

        private static Fraction CheckFraction(Fraction frac)
        {
            if (frac.Denominator == 0)
            {
                throw new DivideByZeroException();
            }
            if (frac.Denominator < 0)
            {
                frac.Numerator -= (frac.Numerator * 2);
                frac.Denominator -= (frac.Denominator * 2);
            }
            frac.Simplify();

            return frac;
        }
        private Fraction Simplify()
        {
            int mcd = MathTools.MCD(Numerator, Denominator);
            Numerator /= mcd;
            Denominator /= mcd;

            return this;
        }

        private static Fraction Sum(Fraction fraction1, Fraction fraction2)
        {
            Fraction result = new Fraction();
            result.Denominator = MathTools.MCM(fraction1.Denominator, fraction2.Denominator);
            result.Numerator = (result.Denominator / fraction1.Denominator) * fraction1.Numerator + (result.Denominator / fraction2.Denominator) * fraction2.Numerator;

            return result;
        }
        private static Fraction Subtract(Fraction fraction1, Fraction fraction2)
        {
            Fraction result = new Fraction();
            result.Denominator = MathTools.MCM(fraction1.Denominator, fraction2.Denominator);
            result.Numerator = (result.Denominator / fraction1.Denominator) * fraction1.Numerator - (result.Denominator / fraction2.Denominator) * fraction2.Numerator;

            return result;
        }

        private static Fraction Multiply(Fraction fraction1, Fraction fraction2)
        {
            Fraction result = new Fraction
            {
                Numerator = fraction1.Numerator * fraction2.Numerator,
                Denominator = fraction1.Denominator * fraction2.Denominator
            };

            return result.Simplify();
        }
        private static Fraction Divide(Fraction fraction1, Fraction fraction2)
        {
            int tmpNum = fraction2.Numerator;
            int tmpDen = fraction2.Denominator;

            return Multiply(fraction1, new Fraction(tmpNum, tmpDen));
        }


        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            return Sum(f1, f2);
        }
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            return Subtract(f1, f2);
        }
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            return Multiply(f1, f2);
        }
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            return Divide(f1, f2);
        }
    }
}
