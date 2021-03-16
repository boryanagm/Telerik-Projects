using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Environment;

class Program
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string currInput;
        int counter = 0;
        int currNum;
        int oldNum = -1;

        var tags = new Stack<string>();
        var spaces = new Stack<int>();
        var result = new StringBuilder();


        for (int i = 0; i < n; i++)
        {
            currInput = Console.ReadLine();
            currNum = int.Parse(new string(currInput.Skip(1).ToArray()));

            if (i != 0)
                oldNum = int.Parse(new string(tags.Peek().Skip(1).ToArray()));

            if (currNum > oldNum && i != 0)
                counter++;

            else if (currNum <= oldNum)
            {
                while (currNum <= oldNum)
                {
                    result.Append($"{new string(' ', spaces.Pop())}</{tags.Pop()}>" + NewLine);

                    if (tags.Count == 0)
                    {
                        counter = 0;
                        break;
                    }
                    oldNum = int.Parse(new string(tags.Peek().Skip(1).ToArray()));
                }
            }

            tags.Push(currInput);
            spaces.Push(counter);
            result.Append($"{new string(' ', spaces.Peek())}<{tags.Peek()}>" + NewLine);
        }

        while (tags.Count != 0)
        {
            result.Append($"{new string(' ', spaces.Pop())}</{tags.Pop()}>" + NewLine);
        }

        Console.WriteLine(result.ToString());
    }
}
