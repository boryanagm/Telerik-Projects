using System;

class Program
{
    static void Main()
    {
        GenerateOneZeroVector(3, "");
    }

    static void GenerateOneZeroVector(int n, string bits)
    {
        if (n == 0)
        {
            Console.WriteLine(bits);
            return;
        }

        GenerateOneZeroVector(n - 1, bits + "0");
        GenerateOneZeroVector(n - 1, bits + "1");
    }
}
