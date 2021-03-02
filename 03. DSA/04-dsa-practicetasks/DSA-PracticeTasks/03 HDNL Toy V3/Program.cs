using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Stack<char> chars = new Stack<char>();
        Stack<int> digits = new Stack<int>();

        StringBuilder sb = new StringBuilder(n * 2);

        for (int i = 0; i < n; i++)
        {
            string inputPair = Console.ReadLine();

            char currentChar = inputPair[0];
            int currentDigit = int.Parse(inputPair.TrimStart(currentChar));

            if (digits.Count == 0)
            {
                sb.AppendLine($"<{currentChar}{currentDigit}>");

                chars.Push(currentChar);
                digits.Push(currentDigit);
            }
            else
            {
                if (digits.Peek() >= currentDigit)
                {
                    while (digits.Count > 0 && digits.Peek() >= currentDigit)
                    {
                        sb.Append(' ', digits.Count - 1);
                        sb.AppendLine($"</{chars.Pop()}{digits.Pop()}>");
                    }

                    sb.Append(' ', digits.Count);
                    sb.AppendLine($"<{currentChar}{currentDigit}>");

                    chars.Push(currentChar);
                    digits.Push(currentDigit);
                }
                else
                {
                    sb.Append(' ', digits.Count);
                    sb.AppendLine($"<{currentChar}{currentDigit}>");

                    chars.Push(currentChar);
                    digits.Push(currentDigit);
                }
            }
        }

        while (digits.Count > 0)
        {
            sb.Append(' ', digits.Count - 1);
            sb.AppendLine($"</{chars.Pop()}{digits.Pop()}>");
        }

        Console.WriteLine(sb.ToString());
    }
}
