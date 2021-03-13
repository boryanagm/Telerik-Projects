using System;

class Program
{
    static void Main()
    {

    }
    // We're still taking O(n) space in the call stack because of the recursion. We can rewrite this as an iterative method to get that memory cost down to
    // O(1).
    private static bool CheckOrders(int[] takeOut, int[] dineIn, int[] served, int servedIndex, int takeOutIndex, int dineInIndex)
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

        return CheckOrders(takeOut, dineIn, served, servedIndex, takeOutIndex, dineInIndex);
    }

}
