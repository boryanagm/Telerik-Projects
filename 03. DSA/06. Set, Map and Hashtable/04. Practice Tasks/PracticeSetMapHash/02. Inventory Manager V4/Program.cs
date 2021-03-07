using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        string input = string.Empty;

        var result = new StringBuilder();

        while ((input = Console.ReadLine()) != "end")
        {
            string[] command = input.Split(' ');

            switch (command[0])
            {
                case "add":

                    string name = command[1];
                    double price = double.Parse(command[2]);
                    string type = command[3];

                    result.AppendLine(ProductManager.AddProduct(name, price, type));

                    break;

                case "filter":

                    string filterBy = command[2];

                    if (filterBy == "price")
                    {
                        result.AppendLine(ProductManager.FilterByPrice(command));
                    }
                    else if (filterBy == "type")
                    {
                        result.AppendLine(ProductManager.FilterByType(command[3]));
                    }

                    break;
            }
        }

        Console.WriteLine(result);
    }
}

public struct Product
{
    public Product(string name, double price, string type)
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

public static class ProductManager
{
    public static HashSet<Product> productsSet = new HashSet<Product>();
    public static Dictionary<string, HashSet<Product>> productsByType = new Dictionary<string, HashSet<Product>>();
   
    public static string AddProduct(string name, double price, string type)
    {
        var newProduct = new Product(name, price, type);

        if (productsSet.Contains(newProduct)) // productsSet.Any(x => x.Name == name) -> because of Any there was a Time Limit exception!!!!
        {
            return $"Error: Item {name} already exists";
        }

        productsSet.Add(newProduct);

        if (!productsByType.ContainsKey(type))
        {
            var newSet = new HashSet<Product>();
            productsByType.Add(type, newSet);
        }

        productsByType[type].Add(newProduct);
        return $"Ok: Item {name} added successfully";
    }

    public static string FilterByType(string type)
    {
        if (!productsByType.ContainsKey(type))
        {
            return $"Error: Type {type} does not exists";
        }

        var orderedItems = productsByType[type]
                          .OrderBy(x => x.Price)
                          .ThenBy(x => x.Name)
                          .ThenBy(x => x.Type)
                          .Take(10);

        return "Ok: " + string.Join(", ", orderedItems.Select(x => $"{x.Name}({x.Price})"));
    }

    public static string FilterByPrice(string[] parameters)
    {
        if (parameters[3] == "from" && parameters.Length == 5)
        {
            double fromPrice = double.Parse(parameters[4]);

            var filteredItems = productsSet.Where(x => x.Price >= fromPrice);

            return OrderedResult(filteredItems);
        }
        else if (parameters[3] == "to")
        {
            double toPrice = double.Parse(parameters[4]);

            var filteredItems = productsSet.Where(x => x.Price <= toPrice);

            return OrderedResult(filteredItems);
        }
        else if (parameters[3] == "from" && parameters.Length == 7)
        {
            double fromPrice = double.Parse(parameters[4]);
            double toPrice = double.Parse(parameters[6]);

            var filteredItems = productsSet.Where(x => x.Price >= fromPrice && x.Price <= toPrice);

            return OrderedResult(filteredItems);
        }

        return "-1";
    }
    private static string OrderedResult(IEnumerable<Product> filteredItems)
    {
        if (!filteredItems.Any())
        { 
            return "Ok:";
        }

        var orderedResult = filteredItems.OrderBy(x => x.Price)
            .ThenBy(x => x.Name)
            .ThenBy(x => x.Type)
            .Take(10);

        return "Ok: " + string.Join(", ", orderedResult.Select(x => $"{x.Name}({x.Price})"));
    }
}