using System;

class Program
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());

        Console.WriteLine(CalculateBlocks(rows));
    }

    static int CalculateBlocks(int rows)
    {
        if (rows == 0)
        {
            return 0;
        }
        if (rows == 1)
        {
            return 1;
        }

        return CalculateBlocks(rows - 1) + rows;
    }
}
