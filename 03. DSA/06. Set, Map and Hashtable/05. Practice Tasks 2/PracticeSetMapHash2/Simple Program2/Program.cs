using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var text = new BigList<string>();

        List<string> test = new List<string> { "one", "three", "four"};

        test.Insert(1, "two");

        Console.WriteLine(string.Join(", ", test));
    }
}
