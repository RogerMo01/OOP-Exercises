using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exercises
{
    class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Balance = 0;

        public Account(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public Account(string id, string name, int balance)
            : this(id, name)
        {
            Balance = balance;
        }

        public string GetId()
        {
            return Id;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetBalance()
        {
            return Balance;
        }

        public void Credit(int amount)
        {
            Balance += amount;
        }

        public void Debit(int amount)
        {
            if (amount > Balance)
            {
                PrintHigherAmount();
            }
            else
            {
                Balance -= amount;
            }
        }

        public void TransferTo(Account account, int amount)
        {
            if (amount > Balance)
            {
                PrintHigherAmount();
            }
            else
            {
                Balance -= amount;
                account.Balance += amount;
            }
        }

        private void PrintHigherAmount()
        {
            Console.WriteLine("The amount is higher than current balance");
            Console.WriteLine("Failed Process");
        }
    }
}
