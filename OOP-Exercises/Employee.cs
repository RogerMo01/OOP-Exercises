using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exercises
{
    class Employee
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Salary { get; private set; }

        public Employee(int id, string firstName, string lastName, int salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }

        public int GetId()
        {
            return Id;
        }

        public string GetFirstName()
        {
            return FirstName;
        }

        public string GetLastName()
        {
            return LastName;
        }

        public int GetSalary()
        {
            return Salary;
        }
        public void SetSalary(int newSalary)
        {
            Salary = newSalary;
        }

        public int GetAnualSalary()
        {
            return Salary * 12;
        }

        public void RaiseSalary(int percent)
        {
            Salary += Salary / 100 * percent;
        }
    }
}
