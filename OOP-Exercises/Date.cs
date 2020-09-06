using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exercises
{
    class Date
    {
        public int Day { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }
        public new string ToString => $"{Day}-{Month}-{Year}";
        private static bool LeapYear = false;
        private static int[] MonthsOf31 = new int[] { 1, 3, 5, 7, 8, 10, 12};        

        public Date(int day, int month, int year)
        {
            SetDate(day, month, year);                 
        }


        public void SetDate(int day, int month, int year)
        {
            if (CheckParameters(day, month, year))
            {
                Day = day;
                Month = month;
                Year = year;
            }
            else
            {
                Console.WriteLine("Process Failed");
            }
        }

        private bool CheckParameters(int day, int month, int year)
        {
            if (year % 4 == 0)
                LeapYear = true;

            if (month > 12 || month < 1)
            {
                return InvalidValue("month");
            }

            switch (day)
            {
                case 29:
                    if (month == 2 && !LeapYear)
                        return InvalidValue("day");                    
                    break;

                case 30:
                    if (month == 2)
                        return InvalidValue("day");                    
                    break;

                case 31:
                    if (MonthsOf31.All(x => x != month))
                        return InvalidValue("day");
                    break;

                default:
                    if (day < 1 || day > 31)
                    {
                        return InvalidValue("day");
                    }
                    break;
            }
            return true;
        }

        private bool InvalidValue(string parameter)
        {
            Console.WriteLine("The parameter of {0}, is an invalid number", parameter);
            return false;
        }
    }
}
