using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());

        Console.WriteLine(FindPaths(n, m));
    }

    public static int FindPaths(int n, int m)
    {
        if (n == 1 || m == 1)
        {
            return 1;
        }

        return FindPaths(n, m - 1) + FindPaths(n - 1, m);
    }
}
