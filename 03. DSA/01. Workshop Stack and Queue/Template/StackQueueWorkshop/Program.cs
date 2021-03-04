using System;
using System.Collections.Generic;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> testStack = new Stack<int>();

            testStack.Push(1);
            testStack.Push(2);
            testStack.Push(3);

            Console.WriteLine(string.Join(" ", testStack));
        }
    }
}
