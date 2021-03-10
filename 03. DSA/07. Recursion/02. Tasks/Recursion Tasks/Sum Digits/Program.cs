using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(CountSevens(n));
    }

    static int CountSevens(int n)
    {
        if (n / 10 == 0)
        {
            if (n == 7)
            {
                return 1;
            }
            return 0;
        }


        return CountSevens(n % 10) + CountSevens(n / 10);
    }
}
