using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exercises
{
    public class MyNode
    {
        public int Value { get; private set; }
        public MyNode Previous { get; set; } = null;
        public MyNode Next { get; set; } = null;

        public MyNode(int value) => Value = value;
        public MyNode(int value, MyNode previous, MyNode next)
            : this(value)
        {
            Previous = previous;
            Next = next;
        }
    }
}
