using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string input = string.Empty;

        Dictionary<string, double> namePricePair = new Dictionary<string, double>();
        Dictionary<string, List<string>> typeNamePair = new Dictionary<string, List<string>>();

        while ((input = Console.ReadLine()) != "end")
        {
            string[] command = input.Split(' ');

            switch (command[0])
            {
                case "add":

                    string name = command[1];
                    double price = double.Parse(command[2]);
                    string type = command[3];

                    if (namePricePair.ContainsKey(name))
                    {
                        Console.WriteLine($"Error: Item {name} already exists");
                    }
                    else
                    {
                        namePricePair[name] = price;

                        if (!typeNamePair.ContainsKey(type))
                        {
                            typeNamePair[type] = new List<string>();
                        }
                        typeNamePair[type].Add(name);

                        Console.WriteLine($"Ok: Item {name} added successfully");
                    }

                    break;

                case "filter":

                    string filterBy = command[2];

                    List<string> ordered = new List<string>();

                    if (filterBy == "price")
                    {
                        double price1 = double.Parse(command[4]);

                        if (command[3] == "from" && command.Length == 5)
                        {
                            foreach (var kvp in namePricePair.Where(x => x.Value >= price1).OrderBy(x => x.Value).ThenBy(x => x.Key))
                            {
                                ordered.Add($"{kvp.Key}({kvp.Value})");
                            }
                        }
                        else if (command[3] == "to")
                        {
                            foreach (var kvp in namePricePair.Where(x => x.Value <= price1).OrderBy(x => x.Value).ThenBy(x => x.Key))
                            {
                                ordered.Add($"{kvp.Key}({kvp.Value})");
                            }
                        }
                        else if (command.Length == 7)
                        {
                            double price2 = double.Parse(command[6]);

                            foreach (var kvp in namePricePair.Where(x => x.Value >= price1 && x.Value <= price2).OrderBy(x => x.Value).ThenBy(x => x.Key))
                            {
                                ordered.Add($"{kvp.Key}({kvp.Value})");
                            }
                        }
                    }
                    else if (filterBy == "type")
                    {
                        string currentType = command[3];

                        if (!typeNamePair.ContainsKey(currentType))
                        {
                            Console.WriteLine($"Error: Type {currentType} does not exists");
                            break;
                        }
                        else
                        {
                            foreach (var kvp in namePricePair.OrderBy(x => x.Value).ThenBy(x => x.Key))
                            {
                                for (int i = 0; i < typeNamePair[currentType].Count; i++)
                                {
                                    if (kvp.Key == typeNamePair[currentType][i])
                                    {
                                        ordered.Add($"{kvp.Key}({kvp.Value})");
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    ordered = ordered.Take(10).ToList();

                    Console.WriteLine($"Ok: {string.Join(", ", ordered)}");

                    break;
            }
        }
    }
}
