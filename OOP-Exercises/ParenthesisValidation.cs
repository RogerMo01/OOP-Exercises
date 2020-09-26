using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exercises
{
    class ParenthesisValidation
    {
        public string Expression;

        public ParenthesisValidation(string expression)
        {
            Expression = expression;

            if (CheckValidation(Expression))
                Console.WriteLine("Valid Expression");
            else Console.WriteLine("Invalid Expression");
        }

        private static bool CheckValidation(string expression)
        {
            char[] characters = expression.ToCharArray();
            char[] path = characters.Where(x => IsParentheses(x)).ToArray();

            LinkedList<char> pending = new LinkedList<char>();

            for (int i = 0; i < path.Length; i++)
            {
                if (IsOpenParenthesis(path[i]))
                    pending.AddLast(path[i]);
                else
                {
                    if (IsHomologous(pending.Last.Value, path[i]))
                        pending.RemoveLast();
                }
            }

            return pending.Count == 0;
        }

        private static bool IsParentheses(char element)
        {
            return (IsOpenParenthesis(element) || element == ')' || element == '}' || element == ']');
        }

        private static bool IsOpenParenthesis(char element)
        {
            return (element == '(' || element == '{' || element == '[');
        }

        private static bool IsHomologous(char OpenChar, char ClosedChar)
        {
            switch (OpenChar)
            {
                case '(':
                    return (ClosedChar == ')');
                case '{':
                    return (ClosedChar == '}');
                case '[':
                    return (ClosedChar == ']');
            }
            return false;
        }
    }
}
