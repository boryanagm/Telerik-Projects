using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Environment;

class Program
{
    static void Main()
    {
        string[] input;
        string commandResult = "";

        var result = new StringBuilder();

        while (true)
        {
            input = Console.ReadLine().Split();

            if (input[0] == "add")
                commandResult = Inventory.Add(input);

            else if (input[0] == "filter")
                commandResult = Inventory.Filter(input.Skip(2).ToArray());

            else
                break;

            result.Append($"{commandResult}{NewLine}");
        }

        Console.WriteLine(result);
    }


}

public static class Inventory
{
    public static HashSet<Item> items = new HashSet<Item>();
    public static Dictionary<string, HashSet<Item>> itemsByType = new Dictionary<string, HashSet<Item>>();

    public static string Add(string[] parameters)
    {
        string name = parameters[1];
        double price = double.Parse(parameters[2]);
        string type = parameters[3];

        var newItem = new Item(name, price, type);

        if (items.Contains(newItem))
            return $"Error: Item {name} already exists";

        items.Add(newItem);

        if (!itemsByType.ContainsKey(type))
        {
            var newSet = new HashSet<Item>();
            itemsByType.Add(type, newSet);
        }

        itemsByType[type].Add(newItem);
        return $"Ok: Item {name} added successfully";
    }

    public static string Filter(string[] parameters)
    {
        string filterBy = parameters[0];

        if (filterBy == "type")
            return FilterByType(parameters[1]);

        else if (filterBy == "price")
            return FilterByPrice(parameters);

        return "";
    }

    private static string FilterByType(string type)
    {
        if (!itemsByType.ContainsKey(type))
            return $"Error: Type {type} does not exists";

        var orderedItems = itemsByType[type]
            .OrderBy(i => i.Price)
            .ThenBy(i => i.Name)
            .ThenBy(i => i.Type)
            .Take(10);

        return "Ok: " + string.Join(", ", orderedItems.Select(i => $"{i.Name}({i.Price})"));
    }

    private static string FilterByPrice(string[] parameters)
    {
        if (parameters[1] == "from" && parameters.Length == 5)
        {
            var fromPrice = double.Parse(parameters[2]);
            var toPrice = double.Parse(parameters[4]);
            var filteredItems = items.Where(i => i.Price >= fromPrice && i.Price <= toPrice);

            return GetFilterResult(filteredItems);
        }

        else if (parameters[1] == "from" && parameters.Length == 3)
        {
            var fromPrice = double.Parse(parameters[2]);
            var filteredItems = items.Where(i => i.Price >= fromPrice);

            return GetFilterResult(filteredItems);
        }

        else if (parameters[1] == "to" && parameters.Length == 3)
        {
            var toPrice = double.Parse(parameters[2]);
            var filteredItems = items.Where(i => i.Price <= toPrice);

            return GetFilterResult(filteredItems);
        }

        //REMOVE
        return "";
    }

    private static string GetFilterResult(IEnumerable<Item> filteredItems)
    {
        if (!filteredItems.Any())
            return "Ok:";

        var finalCollection = filteredItems.OrderBy(i => i.Price)
            .ThenBy(i => i.Name)
            .ThenBy(i => i.Type)
            .Take(10);

        return "Ok: " + string.Join(", ", finalCollection.Select(i => $"{i.Name}({i.Price})"));
    }
}

public struct Item
{
    public Item(string name, double price, string type)
    {
        this.Name = name;
        this.Price = price;
        this.Type = type;
    }

    public string Name { get; private set; }

    public double Price { get; private set; }

    public string Type { get; private set; }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode();
    }
}
