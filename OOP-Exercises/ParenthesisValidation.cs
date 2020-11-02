using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exercises
{
    static class ParenthesesValidation
    {
        public static bool AreParenthesesValidated(string expression)
        {
            char[] characters = expression.ToCharArray();

            LinkedList<char> pending = new LinkedList<char>();

            for (int i = 0; i < characters.Length; i++)
            {
                if (IsOpenParenthesis(characters[i]))
                    pending.AddLast(characters[i]);
                else
                {
                    if (IsHomologous(pending.Last.Value, characters[i]))
                        pending.RemoveLast();
                }
            }

            return pending.Count == 0;
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
