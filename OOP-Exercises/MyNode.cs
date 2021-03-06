﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exercises
{
    public class Node
    {
        public int Value { get; private set; }
        public Node Previous { get; set; } = null;
        public Node Next { get; set; } = null;

        public Node(int value) => Value = value;
        public Node(int value, Node previous, Node next)
            : this(value)
        {
            Previous = previous;
            Next = next;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj);
        }

        public static bool operator == (Node node, Node node2)
        {
            return node.Equals(node2);
        }
        public static bool operator != (Node node, Node node2)
        {
            return !node.Equals(node2);
        }
    }
}
