using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        Console.WriteLine(ChangePi(input, 0, "")); 
    }

    static string ChangePi(string input, int currentIndex, string newStr)
    {
        if (currentIndex > input.Length - 1)
        {
            return newStr; 
        }

        if (currentIndex == input.Length - 1)
        {
            return newStr + input[input.Length - 1];
        }

        if (input[currentIndex] == 'p' && input[currentIndex + 1] == 'i')
        {
            return ChangePi(input, currentIndex + 2, newStr + "3.14");
        }
        else
        {
            return ChangePi(input, currentIndex + 1, newStr + input[currentIndex]);
        }
    }
}
