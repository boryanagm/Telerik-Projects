using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        var memo = new BigInteger[100]; // The max length of the array would be the max Fibonacci number
        Console.WriteLine(Fibonacci(50, memo));
    }

    static BigInteger Fibonacci(int n, BigInteger[] memo)
    {
        if ((n == 1) || (n == 2))
        {
            return 1;
        }
        else
        {
            if (memo[n] == 0)
            {
                memo[n] = Fibonacci(n - 1, memo) + Fibonacci(n - 2, memo);
            }
            return memo[n];
        }
    }
}
