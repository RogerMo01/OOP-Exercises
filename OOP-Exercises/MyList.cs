using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exercises
{
    class MyList
    {
        public int[] Sequence { get; set; }
        public int Count => Sequence.Length;


        /// <summary>
        /// Initialize an empty MyList
        /// </summary>
        public MyList() => Sequence = new int[0];
        /// <summary>
        /// Initialize MyList based on an already exists Array
        /// </summary>
        /// <param name="baseArray"></param>
        public MyList(int[] baseArray) => Sequence = baseArray;        


        /// <summary>
        /// Adds an int element to the end of MyList
        /// </summary>
        /// <param name="element"></param>
        public void Add(int element)
        {
            int[] newSequence = new int[Sequence.Length + 1];

            Array.Copy(Sequence, newSequence, Sequence.Length);
            newSequence[newSequence.Length - 1] = element;

            Sequence = newSequence;
        }

        /// <summary>
        /// Adds the elements of an Array collection to the end of MyList
        /// </summary>
        /// <param name="collection"></param>
        public void AddRange(int[] collection)
        {
            int[] newSequence = new int[Sequence.Length + collection.Length];

            Array.Copy(Sequence, newSequence, Sequence.Length);
            Array.ConstrainedCopy(collection, 0, newSequence, Sequence.Length, collection.Length);

            Sequence = newSequence;
        }

        /// <summary>
        /// Searches the entire sorted MyList for an element using the default comparer.
        /// Return: The index of the int value in MyList, if value is found; otherwise, a negative number.
        /// If this method is called with a non-sorted MyList, the return value can be incorrect and a negative number could be returned, even if value is present in MyList.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public int BinarySearch(int element)
        {
            return Array.BinarySearch(Sequence, element);
        }

        /// <summary>
        /// Removes all elements from MyList.
        /// </summary>
        public void Clear()
        {
            Sequence = new int[0];
        }

        /// <summary>
        /// Determines whether an element is in MyList.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Contains(int element)
        {
            return (Array.IndexOf(Sequence, element) == -1) ? false : true;            
        }

        /// <summary>
        /// Copies a range of elements from the System.Collections.Generic.List`1 to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        /// <param name="count"></param>
        public void CopyTo(int listStartIndex, int[] destnationArray, int destinationArrayStartIndex, int count)
        {
            for (int i = 0; i < destnationArray.Length; i++)
            {                
                while (i >= destinationArrayStartIndex && i < destinationArrayStartIndex + count)
                {
                    destnationArray[i] = Sequence[listStartIndex];
                    listStartIndex++;
                    break;
                }
            }
        }

        /// <summary>
        /// Creates a shallow copy of a range of elements in the source MyList.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public MyList GetRange(int index, int count)
        {
            int[] newListSequence = new int[count];

            for (int i = index; i <= count; i++)
            {
                newListSequence[i - index] = Sequence.ElementAt(i);
            }

            return new MyList(newListSequence);
        }

        /// <summary>
        /// Searches for the specified item within the range of elements in MyList that starts at the specified index and contains the specified number of elements.    
        /// Return: The zero-based index of (the first occurrence within the specified range and starts at specified index) item in MyList, if found; otherwise, –1.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int IndexOf(int item, int index, int count)
        {
            return Array.IndexOf(Sequence, item, index, count);
        }

        /// <summary>
        /// Searches for the specified item first occurrence within the range of elements in MyList that extends from the specified index to the last element.
        /// Return: The zero-based index of first occurrence in MyList that extends from index to the last element, if found; otherwise, –1.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public int IndexOf(int item, int index)
        {
            return Array.IndexOf(Sequence, item, index);
        }

        /// <summary>
        /// Searches for the specified item first occurrence within the entire MyList.
        /// Return: The zero-based index of the first occurrence of item within the entire MyList, if found; otherwise, –1.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(int item)
        {
            return Array.IndexOf(Sequence, item);
        }

        /// <summary>
        /// Inserts an element into MyList at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, int item)
        {
            InsertRange(index, new int[1] { item });            
        }

        /// <summary>
        /// Inserts the elements of an int Array into MyList at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="collection"></param>
        public void InsertRange(int index, int[] collection)
        {
            int[] newSequence = new int[Sequence.Length + collection.Length];

            Array.Copy(Sequence, 0, newSequence, 0, index);
            Array.Copy(collection, 0, newSequence, index, collection.Length);
            Array.Copy(Sequence, index, newSequence, index + collection.Length, Sequence.Length - index);

            Sequence = newSequence;
        }

        /// <summary>
        /// Removes the first occurrence of a specific item from MyList.
        /// Returns: true if item is successfully removed; otherwise, false. This method also returns false if item was not found in MyList.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(int item)
        {
            int index = Array.IndexOf(Sequence, item);

            if (index > -1)
            {
                RemoveAt(index);
                return true;
            }
            else return false;            
        }

        /// <summary>
        /// Removes the item at the specified index from MyList.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            int[] newSequence = new int[Sequence.Length - 1];

            Array.Copy(Sequence, newSequence, index);
            Array.Copy(Sequence, index + 1, newSequence, index, newSequence.Length - index);

            Sequence = newSequence;
        }        

        /// <summary>
        /// Reverses the order of the items in the entire MyList.
        /// </summary>
        public void Reverse()
        {
            Array.Reverse(Sequence);
        }

        /// <summary>
        /// Reverses the order of the items in the specified range.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        public void Reverse(int index, int count)
        {
            Array.Reverse(Sequence, index, count);
        }

        /// <summary>
        /// Sorts the elements in the entire MyList using the default comparer.
        /// </summary>
        public void Sort()
        {
            Array.Sort(Sequence);
        }

        /// <summary>
        /// Return the elements of MyList in an one-dimensional array.
        /// </summary>
        /// <returns></returns>
        public int[] ToArray()
        {
            return Sequence;
        }
    }
}
