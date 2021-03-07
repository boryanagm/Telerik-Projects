using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        string input = string.Empty;

        ProductManager.Products = new List<Product>();

        while ((input = Console.ReadLine()) != "end")
        {
            string[] command = input.Split(' ');

            switch (command[0])
            {
                case "add":

                    string name = command[1];
                    float price = float.Parse(command[2]);
                    string type = command[3];

                    if (ProductManager.IsProductExisting(name))
                    {
                        Console.WriteLine($"Error: Item {name} already exists");
                        break;
                    }
                    else
                    {
                        ProductManager.AddProduct(name, price, type);
                        Console.WriteLine($"Ok: Item {name} added successfully");
                    }

                    break;

                case "filter":

                    string filterBy = command[2];

                    if (filterBy == "price")
                    {
                        if (command[3] == "from" && command.Length == 5)
                        {

                            ProductManager.PrintItems(ProductManager.GetProductsAboveMinPrice(float.Parse(command[4])));
                            //if ((ProductManager.GetProductsAboveMinPrice(float.Parse(command[4]))).Count > 0)
                            //{
                            //    ProductManager.PrintItems(ProductManager.GetProductsAboveMinPrice(float.Parse(command[4])));
                            //}
                            //else
                            //{
                            //    Console.WriteLine("Ok: ");
                            //}
                        }
                        else if (command[3] == "to")
                        {
                            ProductManager.PrintItems(ProductManager.GetProductsUnderMaxPrice(float.Parse(command[4])));

                            //if ((ProductManager.GetProductsUnderMaxPrice(float.Parse(command[4]))).Count > 0)
                            //{
                            //    ProductManager.PrintItems(ProductManager.GetProductsUnderMaxPrice(float.Parse(command[4])));
                            //}
                            //else
                            //{
                            //    Console.WriteLine("Ok: ");
                            //}
                        }
                        else if (command.Length == 7)
                        {
                            ProductManager.PrintItems(ProductManager.GetProductsBetweenPrices(float.Parse(command[4]), float.Parse(command[6])));

                            //if ((ProductManager.GetProductsBetweenPrices(float.Parse(command[4]), float.Parse(command[6]))).Count > 0)
                            //{
                            //    ProductManager.PrintItems(ProductManager.GetProductsBetweenPrices(float.Parse(command[4]), float.Parse(command[6])));
                            //}
                            //else
                            //{
                            //    Console.WriteLine("Ok: ");
                            //}
                        }
                    }
                    else if (filterBy == "type")
                    {
                        if (ProductManager.DoesTypeExist(command[3]))
                        {
                            ProductManager.PrintItems(ProductManager.GetProductsByType(command[3]));
                        }
                        else
                        {
                            Console.WriteLine($"Error: Type {command[3]} does not exists");
                        }
                    }
                    break;
            }
        }
    }
}

public class Product
{
    public Product(string name, float price, string type)
    {
        this.Name = name;
        this.Price = price;
        this.Type = type;
    }

    public string Name { get; set; }
    public float Price { get; set; }
    public string Type { get; set; }
}

public class ProductManager
{
    public static List<Product> Products { get; set; }

    public static bool DoesTypeExist(string type)
    {
        return Products.Any(x => x.Type == type);
    }

    public static bool IsProductExisting(string name)
    {
        return Products.Any(x => x.Name == name);
    }

    public static void AddProduct(string name, float price, string type)
    {
        Products.Add(new Product(name, price, type));
    }

    public static List<string> GetProductsByType(string type)
    {
        return Products.Where(x => x.Type == type).OrderBy(x => x.Price).ThenBy(x => x.Name).Select(x => $"{x.Name}({x.Price})").Take(10).ToList();
    }

    public static List<string> GetProductsUnderMaxPrice(float price)
    {
        return Products.Where(x => x.Price <= price).OrderBy(x => x.Price).ThenBy(x => x.Name).ThenBy(x => x.Type).Select(x => $"{x.Name}({x.Price})").Take(10).ToList();
    }

    public static List<string> GetProductsAboveMinPrice(float price)
    {
        return Products.Where(x => x.Price >= price).OrderBy(x => x.Price).ThenBy(x => x.Name).ThenBy(x => x.Type).Select(x => $"{x.Name}({x.Price})").Take(10).ToList();
    }

    public static List<string> GetProductsBetweenPrices(float price1, float price2)
    {
        return Products.Where(x => x.Price >= price1 && x.Price <= price2).OrderBy(x => x.Price).ThenBy(x => x.Name).ThenBy(x => x.Type).Select(x => $"{x.Name}({x.Price})").Take(10).ToList();
    }

    public static void PrintItems(List<string> ordered)
    {
        Console.WriteLine("Ok: " + string.Join(", ", ordered));

        //StringBuilder sb = new StringBuilder();
        //sb.Append("Ok: ");

        //string separator = ", ";

        //foreach (var item in ordered)
        //{
        //    sb.Append($"{item.Name}({item.Price})");
        //    sb.Append(separator);
        //}

        //if (sb.Length < 5)
        //{
        //    Console.WriteLine(sb.ToString());
        //}
        //else
        //{
        //    Console.WriteLine(sb.ToString().TrimEnd(',', ' '));
        //}
    }
}
