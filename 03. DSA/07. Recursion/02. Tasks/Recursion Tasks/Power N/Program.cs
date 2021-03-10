using System;

class Program
{
    static void Main()
    {
        int baseNum = int.Parse(Console.ReadLine());
        int power = int.Parse(Console.ReadLine());

        Console.WriteLine(CalculatePower(baseNum, power));
    }

    static int CalculatePower(int baseNum, int power)
    {
        if (power == 1)
        {
            return baseNum;
        }

        return baseNum * CalculatePower(baseNum, power - 1);
    }
}
