using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exercises
{
    class ThreeNumbersThatSumToZero
    {
        int[] Sequence;

        public ThreeNumbersThatSumToZero(int[] sequence)
        {
            Sequence = sequence;

            GetNumbers();
        }

        private void GetNumbers()
        {
            for (int i = 0; i < Sequence.Length; i++)
            {
                for (int j = i + 1; j < Sequence.Length; j++)
                {
                    for (int k = j + 1; k < Sequence.Length; k++)
                    {
                        if (Sequence[i] + Sequence[j] + Sequence[k] == 0)
                        {
                            Console.WriteLine($"[{Sequence[i]}, {Sequence[j]}, {Sequence[k]}]");
                            return;
                        }
                    }
                }
            }
            Console.WriteLine("Target not rached");
        }
    }
}
