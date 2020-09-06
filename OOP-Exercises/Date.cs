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
            if (month > 12 || month < 1)
            {
                return InvalidValue("month");
            }

            int daysInMonth = 31 - ((month == 2) ? (3 - LeapYearsCase(year)) : ((month - 1) % 7 % 2));

            if (day < 1 || day > daysInMonth)
            {
                return InvalidValue("day");
            }
            
            return true;
        }

        private int LeapYearsCase(int year)
        {
            return (year % 4 == 0) ? 1 : 0;
        }

        private bool InvalidValue(string parameter)
        {
            Console.WriteLine("The parameter of {0}, is an invalid number", parameter);
            return false;
        }
    }
}
