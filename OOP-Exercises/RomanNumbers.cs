using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exercises
{
    class RomanNumbers
    {
        private static (int number, string letter)[] Symbols = {
            (1, "I"),
            (5, "V"),
            (10, "X"),
            (50, "L"),
            (100, "C"),
            (500, "D"),
            (1000, "M")
        };

        public static string ToRoman(int number)
        {
            ValidateNumber(number);

            string response = "";
            int times = 0;

            for (int i = Symbols.Length - 1; i >= 0 && number > 0; i--)
            {
                string numberStr = Convert.ToString(number);
                times = number / Symbols[i].number;

                if (numberStr.First() == '9')
                {
                    (int number, string response) resultTuple = Case9(response, number, numberStr.Length);
                    number = resultTuple.number;
                    response = resultTuple.response;
                    continue;
                }
                if (numberStr.First() == '4')
                {
                    (int number, string response) resultTuple = Case4(response, number, numberStr.Length);
                    number = resultTuple.number;
                    response = resultTuple.response;
                    continue;
                }

                number = number % Symbols[i].number;
                // Add letters to roman number result
                while (times > 0)
                {
                    response += Symbols[i].letter;
                    times--;
                }
            }
            return response;
        }

        private static (int, string) Case9(string response, int number, int size)
        {
            response += Symbols[size * 2 - 2].letter + Symbols[size * 2].letter;
            number -= 9 * (int)Math.Pow(10, (double)size - 1);
            return (number, response);
        }
        private static (int, string) Case4(string response, int number, int size)
        {
            response += Symbols[size * 2 - 2].letter + Symbols[size * 2 - 1].letter;
            number -= 4 * (int)Math.Pow(10, (double)size - 1);
            return (number, response);
        }

        public static int ToArabic(string romanNumber)
        {
            int resultNumber = GetEquivalentValue(romanNumber.First().ToString());

            if (!IsRoman(romanNumber))
                throw new Exception("Some letter of the roman number string parameter, doe's not exist in the Romans Numbers");

            if (romanNumber.Length == 1)
                return GetEquivalentValue(romanNumber);

            for (int i = 0; i < romanNumber.Length - 1; i++)
            {
                string letterA = Convert.ToString(romanNumber[i]);
                string letterB = Convert.ToString(romanNumber[i + 1]);

                if (IsGreaterOrEqual(letterA, letterB))
                {
                    resultNumber += GetEquivalentValue(letterB);
                }
                else
                {
                    resultNumber -= 2 * GetEquivalentValue(letterA);
                    resultNumber += GetEquivalentValue(letterB);
                }
            }
            return resultNumber;
        }

        private static bool IsGreaterOrEqual(string firstRoman, string secondRoman)
        {
            if (firstRoman == secondRoman)
                return true;

            foreach (var (number, letter) in Symbols)
            {
                if (letter == firstRoman)
                    return false;
                if (letter == secondRoman)
                    return true;
            }
            return false;
        }

        private static bool IsRoman(string romanNumber)
        {
            char[] numberLetters = romanNumber.ToCharArray();

            return numberLetters.All(x => GetRomanLetters().Any(y => y == x));
        }

        private static char[] GetRomanLetters()
        {
            char[] romanLetters = new char[7];

            for (int i = 0; i < Symbols.Length; i++)
            {
                romanLetters[i] = Convert.ToChar(Symbols[i].letter);
            }
            return romanLetters;
        }

        private static int GetEquivalentValue(string letter)
        {
            foreach (var (numbr, lettr) in Symbols)
            {
                if (letter == lettr)
                    return numbr;
            }
            return 0;
        }

        private static void ValidateNumber(int number)
        {            
            if (number < 0 || number > 3999)
            { throw new Exception("The programg only works with numbers from 0 to 3999"); }
        }
    }
}
