using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(CalculateFactorial(n));
    }

    static BigInteger CalculateFactorial(int n)
    {
        if (n == 0)
        {
            return 1;
        }

        return n * CalculateFactorial(n - 1);
    }
}
