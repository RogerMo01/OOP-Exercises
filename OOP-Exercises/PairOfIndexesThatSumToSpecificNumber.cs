using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exercises
{
    class PairOfIndexesThatSumToSpecificNumber
    {
        int[] Sequence;
        int Target = 0;

        public PairOfIndexesThatSumToSpecificNumber(int[] sequence, int target)
        {
            Sequence = sequence;
            Target = target;
        }

        public void GetIndexes()
        {
            for (int i = 0; i < Sequence.Length - 1; i++)
            {
                for (int j = i + 1; j < Sequence.Length; j++)
                {
                    if (Sequence[i] + Sequence[j] == Target)
                    {
                        Console.WriteLine($"[{i},{j}]");
                        return;
                    }
                }
            }
            Console.WriteLine("Target not reached");
        }
    }
}
