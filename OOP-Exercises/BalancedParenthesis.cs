using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exercises
{
    static class BalancedParenthesis
    {
        public static bool AreParenthesesBalanced(string expression)
        {
            if (!AreAllParenthesis(expression))
            {
                Console.WriteLine("Invalid Expression");
                return false;
            }

            int counter = 0;

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                    counter++;
                else counter--;
            }

            return counter == 0;
        }
        
        private static bool AreAllParenthesis(string expression)
        {
            return expression.All(x => x == '(' || x == ')');
        }
    }
}
