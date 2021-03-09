using System;
using System.Numerics;

class Program
{
    // This will be helpful in case we call more than once Factorial() in Main (because we'll already have it in BigInteger[] factorialMemo)
    static BigInteger[] factorialMemo = new BigInteger[100000];
    static void Main()
    {
        int number = 8000;

        Console.WriteLine($"Factorial of {number} is: {Factorial(number)}");
    }

    static BigInteger Factorial(int n)
    {
        if (n == 0)
        {
            return 1;
        }

        if (factorialMemo[n] == 0)
        {
            factorialMemo[n] = n * Factorial(n - 1);
        }

        return factorialMemo[n];
    }

    
}
