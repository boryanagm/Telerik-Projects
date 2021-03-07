using System;

class Program
{
    static void Main()
    {
        int number = 5;

        Console.WriteLine($"Factorial of {number} is: {Factorial(number)}");
    }

    static int Factorial(int n)
    {
        if (n == 0)
        {
            return 1;
        }

        int result = n * (Factorial(n - 1));
        Console.WriteLine($"Current result: {result}");

        return result;
    }
}
