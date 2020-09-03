using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exercises
{
    class Set
    {
        public int[] Sequence { get; private set; }
        public Set(int[] sequence) => Sequence = sequence;

        public bool Contains(int element)
        {
            if (Array.IndexOf(Sequence, element) >= 0)
            {
                return true;
            }
            return false;
        }

        public void Add(int element)
        {
            int[] newSequence = new int[Sequence.Length + 1];

            Array.Copy(Sequence, newSequence, Sequence.Length);
            newSequence[newSequence.Length - 1] = element;

            Sequence = newSequence;
        }

        public int Cardinality()
        {
            return Sequence.Length;
        }

        public int[] ToArray()
        {
            if (Sequence == null)
                return Sequence = new int[] { };

            return Sequence;
        }

        private static Set Union(Set s1, Set s2)
        {
            Set finalSet = new Set(new int[s1.Cardinality()]);
            Array.Copy(s1.Sequence, finalSet.Sequence, s1.Sequence.Length);

            foreach (var item in s2.Sequence)
            {
                if (!s1.Contains(item))
                {
                    finalSet.Add(item);
                }
            }

            return finalSet;
        }

        private static Set Intersection(Set s1, Set s2)
        {
            Set finalSet = new Set(new int[] { });

            foreach (var item in s1.Sequence)
            {
                if (s2.Contains(item))
                {
                    finalSet.Add(item);
                }
            }

            return finalSet;
        }

        private static Set Difference(Set s1, Set s2)
        {
            Set finalSet = new Set(new int[] { });

            foreach (var item in s1.Sequence)
            {
                if (!s2.Contains(item))
                {
                    finalSet.Add(item);
                }
            }

            return finalSet;
        }

        public static bool operator ==(Set s1, Set s2)
        {
            return s1.Sequence.SequenceEqual(s2.Sequence);
        }
        public static bool operator !=(Set s1, Set s2)
        {
            return !s1.Sequence.SequenceEqual(s2.Sequence);
        }
        public static Set operator +(Set s1, Set s2)
        {
            return Union(s1, s2);
        }
        public static Set operator *(Set s1, Set s2)
        {
            return Intersection(s1, s2);
        }
        public static Set operator /(Set s1, Set s2)
        {
            return Difference(s1, s2);
        }
    }
}
