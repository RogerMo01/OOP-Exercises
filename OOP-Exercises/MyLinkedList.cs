using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exercises
{
    public class MyLinkedList
    {
        /// <summary>
        /// Gets the first node of MyLinkedList
        /// </summary>
        public MyNode FirstNode { get; private set; } = null;

        /// <summary>
        /// Gets the last node of MyLinkedList
        /// </summary>
        /// <param name="node"></param>
        public MyNode LastNode { get; private set; } = null;
        private int Count = 0;

        /// <summary>
        /// Initializes a new instance of MyLinkedList class that is empty.
        /// </summary>
        public MyLinkedList() { }

        /// <summary>
        /// Adds the specified new node at the start of MyLinkedList
        /// </summary>
        /// <param name="node"></param>
        public void AddFirst(MyNode node)
        {
            if (Count == 0)
            {
                LastNode = node;
            }
            else
            {
                FirstNode.Previous = node;
                node.Next = FirstNode;
            }
            FirstNode = node;
            Count++;
        }

        /// <summary>
        /// Adds a new node containing the specified value at the start of MyLinkedList
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MyNode AddFirst(int value)
        {
            MyNode node;
            if (Count == 0)
            {
                node = new MyNode(value, null, null);
                LastNode = node;
            }
            else
            {
                node = new MyNode(value, null, FirstNode);
                FirstNode.Previous = node;
            }
            FirstNode = node;
            Count++;
            return node;
        }

        /// <summary>
        /// Adds the specified new node at the end of MyLinkedList
        /// </summary>
        /// <param name="node"></param>
        public void AddLast(MyNode node)
        {
            if (Count == 0)
            {
                FirstNode = node;
            }
            else
            {
                LastNode.Next = node;
                node.Previous = LastNode;
            }
            LastNode = node;
            Count++;
        }

        /// <summary>
        /// Adds a new node containing the specified value at the end of MyLinkedList
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MyNode AddLast(int value)
        {
            MyNode node;
            if (Count == 0)
            {
                node = new MyNode(value, null, null);
                FirstNode = node;
            }
            else
            {
                node = new MyNode(value, LastNode, null);
                LastNode.Next = node;
            }
            LastNode = node;
            Count++;
            return node;
        }

        /// <summary>
        /// Adds the specified new node after the specified existing node in MyLinkedList
        /// </summary>
        /// <param name="node"></param>
        /// <param name="newNode"></param>
        public void AddAfter(MyNode node, MyNode newNode)
        {
            if (!Contains(node))
            {
                Console.WriteLine("The entered node does not exists");
                return;
            }
            newNode.Previous = node;
            newNode.Next = node.Next;
            newNode.Next.Previous = newNode;
            node.Next = newNode;
            Count++;
        }

        /// <summary>
        /// Adds a new node containing the specified value after the specified existing node in MyLinkdeList
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public MyNode AddAfter(MyNode node, int value)
        {
            if (!Contains(node))
            {
                Console.WriteLine("The entered node does not exists");
                return null;
            }
            MyNode newNode = new MyNode(value, node, node.Next);
            node.Next = newNode;
            newNode.Next.Previous = newNode;
            Count++;
            return newNode;
        }

        /// <summary>
        /// Adds the specified new node before the specified existing node in MyLinkedList
        /// </summary>
        /// <param name="node"></param>
        /// <param name="newNode"></param>
        public void AddBefore(MyNode node, MyNode newNode)
        {
            if (!Contains(node))
            {
                Console.WriteLine("The entered node does not exists");
                return;
            }
            newNode.Next = node;
            newNode.Previous = node.Previous;
            newNode.Previous.Next = newNode;
            node.Previous = newNode;
            Count++;
        }

        /// <summary>
        /// Adds a new node containing the specified value before the specified existing node in MyLinkedList
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public MyNode AddBefore(MyNode node, int value)
        {
            if (!Contains(node))
            {
                Console.WriteLine("The entered node does not exists");
                return null;
            }

            MyNode newNode = new MyNode(value, node.Previous, node);

            if (node == FirstNode)
            {
                node.Previous = newNode;
                FirstNode = newNode;
                Count++;
            }
            else
            {
                node.Previous.Next = newNode;
                node.Previous = newNode;
                Count++;
            }
            return newNode;
        }

        /// <summary>
        /// Removes all nodes from MyLinkedList
        /// </summary>
        public void Clear()
        {
            FirstNode = null;
            LastNode = null;
            Count = 0;
        }

        /// <summary>
        /// Determines whether a node is in MyLinkedList
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool Contains(MyNode node)
        {
            if (node == LastNode)
                return true;

            MyNode indexer = FirstNode;
            while (indexer != LastNode)
            {
                if (indexer == node)
                    return true;
                indexer = indexer.Next;
            }
            return false;
        }

        /// <summary>
        /// Determines whether a value is in MyLinkedList
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(int value)
        {
            if (value == LastNode.Value)
                return true;

            MyNode indexer = FirstNode;
            while (indexer.Value != LastNode.Value)
            {
                if (indexer.Value == value)
                    return true;
                indexer = indexer.Next;
            }
            return false;
        }

        /// <summary>
        /// Copies the entire MyLinkedList to a compatible one-dimensional Array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        public void CopyTo(int[] array, int index)
        {
            int[] sequence = ToArray();
            Array.Copy(sequence, 0, array, index, sequence.Length);
        }

        /// <summary>
        /// Removes the specified node from MyLinkedList
        /// </summary>
        /// <param name="node"></param>
        public void Remove(MyNode node)
        {
            if (node == LastNode)
            {
                RemoveLast();
                return;
            }
            if (node == FirstNode)
            {
                RemoveFirst();
                return;
            }

            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;

            Count--;
        }

        /// <summary>
        /// Removes the first occurrence of the specified value from MyLinkedList
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Remove(int value)
        {
            if (!Contains(value))
                return false;

            if (value == LastNode.Value || value == FirstNode.Value)
            {
                Remove(LastNode);
                return true;
            }

            MyNode indexer = FirstNode.Next;
            while (indexer.Value != LastNode.Value)
            {
                if (indexer.Value == value)
                {
                    Remove(indexer);
                    return true;
                }
                else indexer = indexer.Next;
            }
            return false;
        }

        /// <summary>
        /// Removes the node at the start of MyLinkedList
        /// </summary>
        public void RemoveFirst()
        {
            FirstNode.Next.Previous = null;
            FirstNode = FirstNode.Next;
            Count--;
        }

        /// <summary>
        /// Removes the node at the end of MyLinkedList
        /// </summary>
        public void RemoveLast()
        {
            LastNode.Previous.Next = null;
            LastNode = LastNode.Previous;
            Count--;
        }

        /// <summary>
        /// Copy all values from MyLinkedList to a new compatible one-dimensional array
        /// </summary>
        /// <returns></returns>
        public int[] ToArray()
        {
            int[] finalArray = new int[Count];

            MyNode indexer = FirstNode;
            for (int i = 0; i < Count; i++)
            {
                finalArray[i] = indexer.Value;
                indexer = indexer.Next;
            }
            return finalArray;
        }
    }
}
