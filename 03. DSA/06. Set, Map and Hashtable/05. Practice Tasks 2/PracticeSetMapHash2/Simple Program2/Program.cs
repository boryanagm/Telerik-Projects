using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> test = new List<string> { "one", "three", "four"};

        test.Insert(1, "two");

        Console.WriteLine(string.Join(", ", test));
    }
}
