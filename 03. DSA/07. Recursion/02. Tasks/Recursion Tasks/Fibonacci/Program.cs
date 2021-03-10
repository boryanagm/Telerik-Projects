using System;
using System.Numerics;

class Program
{
    public static BigInteger[] memo = new BigInteger[100000];

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(CalculateFibonacci(n));
    }

    static BigInteger CalculateFibonacci(int n)
    {
        if (n == 0)
        {
            return 0;
        }
        if ((n == 1) || (n == 2))
        {
            return 1;
        }
        else
        {
            if (memo[n] == 0)
            {
                memo[n] = CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);

            }
            return memo[n];
        }
    }
}
