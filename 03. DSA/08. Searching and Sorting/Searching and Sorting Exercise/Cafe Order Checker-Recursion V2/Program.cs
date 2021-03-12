using System;

class Program
{
    static void Main()
    {
        int[] takeOut = new int[] { 1, 3, 5};
        int[] dineIn = new int[] { 2, 4, 6};
        int[] served = new int[] { 1, 2, 3, 5, 4, 6};
       // int[] served = new int[] { 1, 2, 4, 6, 5, 3 };

        Console.WriteLine(CheckOrders(takeOut, dineIn, served));
    }

    // My implementation
    private static bool CheckOrders(int[] takeOut, int[] dineIn, int[] served)
    {
        int takeOutIndex = 0;
        int dineInIndex = 0;
        int servedIndex = 0;


        for (int i = 0; i < served.Length; i++)
        {
            if (takeOutIndex < takeOut.Length && served[servedIndex] == takeOut[takeOutIndex])
            {
                servedIndex++;
                takeOutIndex++;
            }
            else if (dineInIndex < dineIn.Length && served[servedIndex] == dineIn[dineInIndex])
            {
                servedIndex++;
                dineInIndex++;
            }
            else
            {
                return false;
            }

            if (servedIndex == served.Length - 1)
            {
                break;
            }
        }

        return true;
    }
}
