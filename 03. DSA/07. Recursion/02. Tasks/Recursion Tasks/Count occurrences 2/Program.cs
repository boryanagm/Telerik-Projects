using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(CountEights(n));
    }

    static int CountEights(int n)
    {
        if (n / 10 == 0)
        {
            if (n == 8)
            {
                return 1;
            }
            return 0;
        }

        if ((n / 10) % 10 == 8 && n % 10 == 8)
        {
            return CountEights(n % 10) + CountEights(n / 10) + 1;
        }
        else
        {
            return CountEights(n % 10) + CountEights(n / 10);
        }
    }
}
