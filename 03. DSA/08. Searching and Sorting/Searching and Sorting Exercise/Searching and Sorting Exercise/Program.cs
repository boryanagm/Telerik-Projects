using System;

class Program
{
    static void Main()
    {
        /*
         Note that our inputs are probably pretty small. This method will take hardly any time or space, even if it could be more efficient. In industry, especially at small startups that want to move quickly, optimizing this might be considered a "premature optimization." Great engineers have both the skill to see how to optimize their code and the wisdom to know when those optimizations aren't worth it. At this point in the interview you can say - "I think we can optimize this a bit further, although given the nature of the input this probably won't be very resource-intensive anyway... should we talk about optimizations?"
          Suppose we do want to optimize further. What are the time and space costs to beat? This method will take O(n2)O(n^2)O(n2) time and O(n2)O(n^2)O(n2)additional space.
         */
    }

    private static bool CheckOrders(int[] takeOut, int[] dineIn, int[] served)
    {
        if (served.Length == 0)
        {
            return true;
        }

        if (takeOut.Length > 0 && takeOut[0] == served[0])
        {
            return CheckOrders(RemoveFirstFromArray(takeOut), dineIn, RemoveFirstFromArray(served));
        }

        if (dineIn.Length > 0 && dineIn[0] == served[0])
        {
            return CheckOrders(takeOut, RemoveFirstFromArray(dineIn), RemoveFirstFromArray(served));
        }

        return false;
    }

    private static int[] RemoveFirstFromArray(int[] array)
    {
        int[] newArray = new int[array.Length - 1];
        Array.Copy(array, 1, newArray, 0, array.Length - 1);

        return newArray;
    }
}
