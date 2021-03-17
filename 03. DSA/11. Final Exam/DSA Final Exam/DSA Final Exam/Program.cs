using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int numberOfSoldiers = int.Parse(Console.ReadLine());

        string[] soldiers = Console.ReadLine().Split(' ');

        var sergants = new LinkedList<string>();
        var corporals = new LinkedList<string>();
        var privates = new LinkedList<string>();

        for (int i = 0; i < numberOfSoldiers; i++)
        {
            if (soldiers[i][0] == 'S')
            {
                sergants.AddLast(soldiers[i]);
            }
            else if (soldiers[i][0] == 'C')
            {
                corporals.AddLast(soldiers[i]);
            }
            else
            {
                privates.AddLast(soldiers[i]);
            }
        }

        Console.Write(string.Join(" ", sergants));
        Console.Write(" ");
        Console.Write(string.Join(" ", corporals));
        Console.Write(" ");
        Console.Write(string.Join(" ", privates));
    }
}
