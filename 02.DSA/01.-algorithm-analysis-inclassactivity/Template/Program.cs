using System;

namespace AlgorithmAnalysis
{
	class Program
	{
		static void Main()
		{
		}

		// Returns the product of two numbers.
		// Complexity O(n)
		static int Product(int a, int b)
		{
			int sum = 0;

			for (int i = 0; i < b; i++)
			{
				sum += a;
			}

			return sum;
		}

		// Returns a to the power of b
		// Complexity O(n)
		static int Power(int a, int b)
		{
			if (b < 0)
			{
				return 0;
			}

			if (b == 0)
			{
				return 1;
			}

			int power = a;

			while (b > 1)
			{
				power *= a;
				b--;
			}

			return power;
		}

		// Returns the remainder after dividing a by b
		// // Complexity O(1)
		static int Mod(int a, int b)
		{
			if (b < 0)
			{
				return -1;
			}

			int div = a / b;
			return a - div * b;
		}

		// Complexity O(n^3)
		static int Sum3(int n)
		{
			int sum = 0;
			for (int a = 0; a < n; a++)
			{
				for (int b = 0; b < n; b++)
				{
					for (int c = 0; c < n; c++)
					{
						sum += (a * b * c);
					}
				}
			}
			return sum;
		}

		// Complexity O(n^2)
		static int SumNM(int n, int m)
		{
			int sum = 0;
			for (int a = 0; a < n; a++)
			{
				for (int b = 0; b < m; b++)
				{
					sum += (a * b);
				}
			}
			return sum;
		}

		// Determines if a number is even.
		// Complexity O(1)
		static bool IsEven(int number)
		{
			return number % 2 == 0;
		}

		// Determines if a number is odd.
		// Complexity O(1)
		static bool IsOdd(int number)
		{
			bool result = number % 2 != 0;
			return result;
		}

		// Returns the first element of an array.
		// Complexity O(1)
		static int GetFirstElement(int[] array)
		{
			int element = array[0];
			return element;
		}

		// Returns the last element of an array.
		// Complexity O(1)
		static int GetLastElement(int[] array)
		{
			int element = array[array.Length - 1];
			return element;
		}

		// Returns the element at the given index.
		// Complexity O(1)
		static int GetElementByIndex(int[] array, int index)
		{
			int element = array[index];
			return element;
		}

		// Finds the maximum value from an unsorted array.
		// Complexity O(n)
		static int FindMaxElement(int[] array)
		{
			int max = int.MinValue;

			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] > max)
				{
					max = array[i];
				}
			}

			return max;
		}

		// Determines whether an element exists in an unsorted array.
		// Complexity O(n)
		static bool Contains(int[] array, int element)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == element)
				{
					return true;
				}
			}

			return false;
		}

		// Finds the index of an element in a sorted array.
		// Complexity O(log(n))
		static int GetElementIndex(int[] array, int elementToFind)
		{
			// array must be sorted!
			Array.Sort(array);

			// Perform binary search
			int leftIndex = 0;
			int rightIndex = array.Length - 1;

			while (leftIndex <= rightIndex)
			{
				int middleIndex = leftIndex + (rightIndex - leftIndex) / 2;
				int middleElement = array[middleIndex];

				// Check if the element is at the middle
				if (middleElement == elementToFind)
				{
					return middleIndex;
				}

				// If the element is greater than the element in the middle, ignore the left half 
				if (elementToFind > middleElement)
				{
					leftIndex = middleIndex + 1;
				}
				// If the element is smaller than the element in the middle, ignore the right half 
				else
				{
					rightIndex = middleIndex - 1;
				}
			}

			// The element has not been found, return -1
			return -1;
		}

		// Checks if an array has duplicate values.
		// Complexity O(n^2)
		static bool HasDuplicates(int[] numbers)
		{
			for (int outerIndex = 0; outerIndex < numbers.Length; outerIndex++)
			{
				for (int innerIndex = 0; innerIndex < numbers.Length; innerIndex++)
				{
					if (outerIndex == innerIndex)
					{
						continue;
					}

					if (numbers[outerIndex] == numbers[innerIndex])
					{
						return true;
					}
				}
			}

			return false;
		}

		// Returns the Fibonacci number on the n-th position using an iterative approach.
		// Complexity O(n)
		static int GetFibonacciIterative(int n)
		{
			if (n < 0)
			{
				return 0;
			}

			if (n < 2)
			{
				return n;
			}

			int prev = 0;
			int result = 1;

			for (int i = 1; i < n; i++)
			{
				int temp = result;
				result += prev;
				prev = temp;
			}

			return result;
		}

		// Returns the Fibonacci number on the n-th position using a recursive approach.
		// Complecity O(2^n)
		static int GetFibonacciRecursive(int n)
		{
			if (n <= 1)
				return 1;

			return GetFibonacciRecursive(n - 1) + GetFibonacciRecursive(n - 2);
		}
	}
}
