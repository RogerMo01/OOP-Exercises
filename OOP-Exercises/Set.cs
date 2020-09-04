using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exercises
{
    class Set
    {
        public List<int> Sequence { get; private set; }
        public Set(List<int> sequence) => Sequence = sequence;

        public bool Contains(int element)
        {
            return Sequence.Contains(element);
        }

        public void Add(int element)
        {
            Sequence.Add(element);            
        }

        public int Cardinality()
        {
            return Sequence.Count;
        }
        
        private static Set Union(Set s1, Set s2)
        {
            Set finalSet = new Set(new List<int>());

            foreach (var item in s1.Sequence)
            {
                finalSet.Add(item);
            }

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
            Set finalSet = new Set(new List<int>());

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
            Set finalSet = new Set(new List<int>());

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
