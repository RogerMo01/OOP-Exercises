using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exercises
{
    class BalancedParenthesis
    {
        public string Expression { get; private set; } = "";

        public BalancedParenthesis(string expression)
        {
            Expression = expression;

            if (!AreAllParenthesis(Expression))
            {
                Console.WriteLine("Invalid Expression");
                return;
            }

            Console.WriteLine($"Is Balanced: {IsBalanced(Expression)}");
        }

        private static bool AreAllParenthesis(string expression)
        {
            return expression.All(x => x == '(' || x == ')');
        }

        private static bool IsBalanced(string expression)
        {
            int counter = 0;

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                    counter++;
                else counter--;
            }

            return counter == 0;
        }
    }
}
