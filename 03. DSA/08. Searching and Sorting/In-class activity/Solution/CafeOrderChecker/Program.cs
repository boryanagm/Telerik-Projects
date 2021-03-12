using System;

namespace CafeOrderChecker
{
	class Program
	{
		public static void Main()
		{
			int[] takeOut = { 1, 3, 5 };
			int[] dineIn = { 2, 4, 6 };
			int[] served = { 1, 2, 3, 4, 5, 6 };
			Console.WriteLine("Expected: True; Actual: " + CheckOrdersVersion1(takeOut, dineIn, served));
			Console.WriteLine("Expected: True; Actual: " + CheckOrderVersion2(takeOut, dineIn, served, 0, 0, 0));
			Console.WriteLine("Expected: True; Actual: " + CheckOrderVersion3(takeOut, dineIn, served));

			served = new int[] { 1, 2, 4, 6, 5, 3 };
			Console.WriteLine("Expected: False; Actual: " + CheckOrdersVersion1(takeOut, dineIn, served));
			Console.WriteLine("Expected: False; Actual: " + CheckOrderVersion2(takeOut, dineIn, served, 0, 0, 0));
			Console.WriteLine("Expected: False; Actual: " + CheckOrderVersion3(takeOut, dineIn, served));

			takeOut = new int[] { };
			dineIn = new int[] { 2, 3, 6 };
			served = new int[] { 2, 3, 6 };
			Console.WriteLine("Expected: True; Actual: " + CheckOrdersVersion1(takeOut, dineIn, served));
			Console.WriteLine("Expected: True; Actual: " + CheckOrderVersion2(takeOut, dineIn, served, 0, 0, 0));
			Console.WriteLine("Expected: True; Actual: " + CheckOrderVersion3(takeOut, dineIn, served));

			takeOut = new int[] { 1, 5 };
			dineIn = new int[] { 2, 3, 6 };
			served = new int[] { 1, 2, 6, 3, 5 };
			Console.WriteLine("Expected: False; Actual: " + CheckOrdersVersion1(takeOut, dineIn, served));
			Console.WriteLine("Expected: False; Actual: " + CheckOrderVersion2(takeOut, dineIn, served, 0, 0, 0));
			Console.WriteLine("Expected: False; Actual: " + CheckOrderVersion3(takeOut, dineIn, served));
		}

		private static bool CheckOrdersVersion1(int[] takeOut, int[] dineIn, int[] served)
		{
			if (served.Length == 0)
			{
				return true;
			}

			if (takeOut.Length > 0 && takeOut[0] == served[0])
			{
				return CheckOrdersVersion1(RemoveFirstFromArray(takeOut), dineIn, RemoveFirstFromArray(served));
			}

			if (dineIn.Length > 0 && dineIn[0] == served[0])
			{
				return CheckOrdersVersion1(takeOut, RemoveFirstFromArray(dineIn), RemoveFirstFromArray(served));
			}

			return false;
		}

		private static int[] RemoveFirstFromArray(int[] array)
		{
			int[] newArray = new int[array.Length - 1];
			Array.Copy(array, 1, newArray, 0, array.Length - 1);
			return newArray;
		}

		private static bool CheckOrderVersion2(int[] takeOut, int[] dineIn, int[] served, int servedIndex, int takeOutIndex, int dineInIndex)
		{
			if (servedIndex == served.Length)
			{
				return true;
			}

			if (takeOutIndex < takeOut.Length && takeOut[takeOutIndex] == served[servedIndex])
			{
				takeOutIndex++;
			}
			else if (dineInIndex < dineIn.Length && dineIn[dineInIndex] == served[servedIndex])
			{
				dineInIndex++;
			}
			else
			{
				return false;
			}

			servedIndex++;

			return CheckOrderVersion2(takeOut, dineIn, served, servedIndex, takeOutIndex, dineInIndex);
		}

		private static bool CheckOrderVersion3(int[] takeOut, int[] dineIn, int[] served)
		{
			int take = 0;
			int dine = 0;

			foreach (int order in served)
			{
				if (take < takeOut.Length && order == takeOut[take])
				{
					take++;
				}
				else if (dine < dineIn.Length && order == dineIn[dine])
				{
					dine++;
				}
				else
				{
					return false;
				}
			}

			return take == takeOut.Length && dine == dineIn.Length;
		}
	}
}
