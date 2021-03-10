using System;

class Program
{
    static void Main()
    {
        string x = Console.ReadLine();

        Console.WriteLine(CountX(x, x.Length - 1));
    }

    static int CountX(string x, int currentIndex)
    {
        if (currentIndex == 0)
        {
            if (x[currentIndex] == 'x')
            {
                return 1;
            }
            return 0;
        }

        if (x[currentIndex] == 'x')
        {
            return CountX(x, currentIndex - 1) + 1;
        }

        return CountX(x, currentIndex - 1);
    }
}
