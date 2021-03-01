using System;
using System.Collections.Generic;

namespace TelerikAcademy.Core
{
    public class ArrayHelpers
    {
        /// <summary>
        /// Adds the int element at the start of the array source.
        /// </summary>
        /// <param name="source">The array to add to</param>
        /// <param name="element">The element to add</param>
        /// <returns>A new array that has all the elements from the original array and the added element at head position.</returns>
        /// <author>Boryana Mihaylova</author>
        public static int[] AddFirst(int[] source, int element)
        {
            int[] newArr = new int[source.Length + 1];

            for (int i = 0; i < newArr.Length; i++)
            {
                if (i == 0)
                {
                    newArr[i] = element;
                }
                else
                {
                    newArr[i] = source[i - 1];
                }
            }

            return newArr;
        }

        /// <summary>
        /// Adds the int element at the end of the array source.
        /// </summary>
        /// <param name="source">The array to add to</param>
        /// <param name="element">The element to add</param>
        /// <returns>A new array that has all the elements from the original array and the added element at last position.</returns>
        /// <author>Boryana Mihaylova</author>

        public static int[] AddLast(int[] source, int element)
        {
            int[] newArr = new int[source.Length + 1];

            for (int i = 0; i < newArr.Length; i++)
            {
                if (i == newArr.Length - 1)
                {
                    newArr[i] = element;
                }
                else
                {
                    newArr[i] = source[i];
                }
            }

            return newArr;
        }

        /// <summary>
        /// Append elements to the source array.
        /// </summary>
        /// <param name="source">The array to add to</param>
        /// <param name="element">The elements to add in the source array</param>
        /// <returns>A new array that has all the new elements from the original array and the added elements at the end of the source array.</returns>
        /// <author>Cvetomir Georgiev</author>

        public static int[] AppendAll(int[] source, int[] elements)
        {
            int[] result = new int[source.Length + elements.Length];

            for (int index = 0; index < source.Length; index++)
            {
                result[index] = source[index];
            }

            int elementIndex = 0;

            for (int index = source.Length; index < result.Length; index++)
            {
                result[index] = elements[elementIndex];
                elementIndex++;
            }

            return result;
        }

        /// <summary>
        /// Inserts an element to a certain position in the array.
        /// </summary>
        /// <param name="source">The array to add to</param>
        /// <param name="index">The index of the element to add in the source array</param>
        /// <param name="element">The element to add in the array</param>
        /// <returns>A new array that has all the new elements from the original plus one element at a certain index.</returns>
        /// <author>Cvetomir Georgiev</author>

        public static int[] InsertAt(int[] source, int index, int element)
        {
            int[] result = new int[source.Length + 1];

            int[] firstPart = new int[index + 1];

            for (int i = 0; i < index; i++)
            {
                firstPart[i] = source[i];
            }

            firstPart[firstPart.Length - 1] = element;

            int[] secondPart = new int[result.Length - firstPart.Length];

            for (int i = 0; i < secondPart.Length; i++)
            {
                secondPart[i] = source[index + i];
            }

            result = AppendAll(firstPart, secondPart);

            return result;
        }
        /// <summary>
        /// A check if an element is contained in an array.
        /// </summary>
        /// <param name="source">An array to check from</param>
        /// <param name="element">A ?contained element to check from source</param>
        /// <returns>Bool return if element is contained in source</returns>
        /// <author>Dimitar Piskov</author>

        public static bool Contains(int[] source, int element)
        {
            bool elementIsContained = false;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == element)
                {
                    elementIsContained = true;
                }
            }
            return elementIsContained;
        }/// <summary>
         /// A void method to create a partial or full copy of an existing array.
         /// </summary>
         /// <param name="sourceArray">Array to be copied.</param>
         /// <param name="destinationArray">New created partial/full address(copy) of SourceArray</param>
         /// <param name="count">Number of indexes to copy</param>
         /// <author>Dimitar Piskov</author>

        public static void Copy(int[] sourceArray, int[] destinationArray, int count)
        {
            if (count > sourceArray.Length) count = sourceArray.Length;
            for (int i = 0; i < count; i++)
            {
                destinationArray[i] = sourceArray[i];
            }
        }
        /// <summary>
        /// Copies elements from sourceArray, starting from sourceStartIndex into destinationArray, starting from destStartIndex, taking count elements.
        /// </summary>
        /// <param name="sourceArray">The array to copy from</param>
        /// <param name="sourceStartIndex">The starting index in sourceArray</param>
        /// <param name="destinationArray">The array to copy to</param>
        /// <param name="destStartIndex">The starting index in destinationArray</param>
        /// <param name="count">The number of elements to copy</param>
        /// <author>Emil Nenchev</author>
        public static void CopyFrom(int[] sourceArray, int sourceStartIndex, int[] destinationArray, int destStartIndex, int count)
        {
            for (int i = 0; i < count; i++)
            {
                destinationArray[destStartIndex] = sourceArray[sourceStartIndex];
                destStartIndex++;
                sourceStartIndex++;
            }
        }
        /// <summary>
        /// Fills source with element.
        /// </summary>
        /// <param name="source">The array to fill</param>
        /// <param name="element">The element to fill with</param>
        /// <author>Emil Nenchev</author>
        public static void Fill(int[] source, int element)
        {
            for (int i = 0; i < source.Length; i++)
            {
                source[i] = element;
            }
        }
        /// <summary>
        /// Finds the first index of `target` within `source`.
        /// </summary>
        /// <param name="source">The array to check in</param>
        /// <param name="target">The element to check for</param>
        /// <returns>The first index of `target` within `source`</returns>
        /// <author>Georgi Avramov</author>
        public static int FirstIndexOf(int[] source, int target)
        {

            int index = -1;

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == target)
                {
                    index = i;
                    break;
                }
            }
            return index;

        }
        /// <summary>
        /// Finds the last index of `target` within `source`.
        /// </summary>
        /// <param name="source">The array to check in</param>
        /// <param name="target">The element to check for</param>
        /// <returns>The last index of `target` within `source`</returns>
        /// <author>Georgi Avramov</author>
        public static int LastIndexOf(int[] source, int target)
        {
            int index = -1;

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == target)
                {
                    index = i;
                }
            }
            return index;
        }
        /// <summary>
        /// Checks if given index is a valid index in an array.
        /// </summary>
        /// <param name="source">The array to check against</param>
        /// <param name="element">The index to check for</param>
        /// <returns>`bool` - `true` if `index` is valid, otherwise, `false`.</returns>
        /// <author>Svetlin Vlaev</author>
        public static bool IsValidIndex(int[] source, int index)
        {
            if (source.Length > index)
            {
                if (index < 0)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Removes all occurrences of element within array source.
        /// </summary>
        /// <param name="source">The array to remove from</param>
        /// <param name="element">The element to check for</param>
        /// <returns>A new array with all occurences of element removed.</returns>
        /// <author>Svetlin Vlaev</author>
        public static int[] RemoveAllOccurrences(int[] source, int element)
        {
            List<int> clearList = new List<int>();
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] != element)
                {
                    clearList.Add(source[i]);
                }
            }
            source = clearList.ToArray();
            return source;
        }
        /// <summary>
        /// Reverses a given array.
        /// </summary>
        /// <param name="arrayToReverse">Array to be reversed</param>
        /// <author>Dimitar Piskov</author>
        public static void Reverse(int[] arrayToReverse)
        {
            int temp = 0;
            for (int i = 0; i < arrayToReverse.Length / 2; i++)
            {
                temp = arrayToReverse[i];
                arrayToReverse[i] = arrayToReverse[arrayToReverse.Length - 1 - i];
                arrayToReverse[arrayToReverse.Length - 1 - i] = temp;
            }
        }

        /// <summary>
        /// Returns a new int array, starting from startIndex and ending at endIndex.
        /// </summary>
        /// <param name="source">The array to take elements from.</param>
        /// <param name="startIndex">The starting position in source (inclusive).</param>
        /// <param name="endIndex">The end position in source (inclusive).</param>
        /// <returns>A new int array, formed by the elements in source, starting from startIndex to endIndex.</returns>
        /// <author>Boryana Mihaylova</author>
        public static int[] Section(int[] source, int startIndex, int endIndex)
        {

            int counter = 0;

            if (startIndex < 0)
            {
                startIndex = 0;
            }

            if (endIndex > source.Length)
            {
                endIndex = source.Length - 1;
            }

            int[] section = new int[endIndex - startIndex + 1];

            for (int i = startIndex; i <= endIndex; i++)
            {
                section[counter] = source[i];
                counter++;
            }

            return section;
        }
    }
}
