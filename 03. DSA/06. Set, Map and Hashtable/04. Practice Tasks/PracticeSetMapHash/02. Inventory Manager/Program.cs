using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string input = string.Empty;

        Dictionary<string, double> itemPricePair = new Dictionary<string, double>();
        Dictionary<string, string> itemTypePair = new Dictionary<string, string>();

        while ((input = Console.ReadLine()) != "end")
        {
            string[] command = input.Split(' ');

            switch (command[0])
            {
                case "add":

                    string name = command[1];
                    double price = double.Parse(command[2]);
                    string type = command[3];

                    if (itemPricePair.ContainsKey(name))
                    {
                        Console.WriteLine($"Error: Item {name} already exists");
                        break;
                    }
                    else
                    {
                        itemPricePair[name] = price;
                        itemTypePair[name] = type;

                        Console.WriteLine($"Ok: Item {name} added successfully");
                    }

                    break;

                case "filter":

                    string filterBy = command[2];

                    if (filterBy == "name")
                    {

                    }
                    else if (filterBy == "price")
                    {

                    }
                    else if (filterBy == "type")
                    {
                        if (!itemTypePair.ContainsValue(command[3]))
                        {
                            Console.WriteLine($"Error: Type {command[3]} does not exists");
                            break;
                        }
                        else
                        {
                            int counter = 0;

                            foreach (var kvp in itemPricePair.OrderBy(x => x.Value))
                            {
                                if (itemTypePair.ContainsValue(command[3]))
                                {
                                    Console.Write($"{kvp.Key}({kvp.Value})");
                                    counter++;
                                }
                               
                                if (counter == 10)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    break;
            }
        }
    }
}
