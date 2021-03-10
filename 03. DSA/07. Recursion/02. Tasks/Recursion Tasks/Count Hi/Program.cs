using System;

class Program
{
    static void Main()
    {
        string x = Console.ReadLine();

        Console.WriteLine(CountHi(x, x.Length - 1));
    }

    static int CountHi(string x, int currentIndex)
    {
        if (currentIndex == 0)
        {
            return 0;
        }

        if (currentIndex == 1 || currentIndex == 0)
        {
            if (x[currentIndex - 1] == 'h' && x[currentIndex] == 'i')
            {
                return 1;
            }
            return 0;
        }

        if (x[currentIndex - 1] == 'h' && x[currentIndex] == 'i')
        {
            return CountHi(x, currentIndex - 1) + 1;
        }
        else
        {
            return CountHi(x, currentIndex - 1);
        }
    }
}
