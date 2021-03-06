using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int result = Sum(n);

        Console.WriteLine(result);
    }

    public static int Sum(int n)
    {
        if (n <= 1)
        {
            return n;
        }

        int result = n + Sum(n - 1);

        return result;
    }
}
