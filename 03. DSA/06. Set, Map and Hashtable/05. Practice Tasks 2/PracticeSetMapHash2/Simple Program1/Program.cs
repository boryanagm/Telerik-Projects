using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        string input = string.Empty;
        string result = string.Empty;
        var printResult = new StringBuilder();

        while ((input = Console.ReadLine()) != "end")
        {
            string[] command = input.Split(' ');

            if (command[0] == "add")
            {
                result = CommandManager.Add(command);
            }
            else if (command[0] == "find")
            {
                result = CommandManager.Find(command);
            }
            else
            {
                result = CommandManager.Ranklist(command);
            }

            printResult.AppendLine(result);
        }

        Console.WriteLine(printResult);
    }
}

public static class CommandManager
{
    public static List<Pokemon> pokemons = new List<Pokemon>();
    public static Dictionary<string, List<Pokemon>> pokemonsByType = new Dictionary<string, List<Pokemon>>();

    public static string Add(string[] parameters)
    {
        string name = parameters[1];
        string type = parameters[2];
        int power = int.Parse(parameters[3]);
        int position = int.Parse(parameters[4]);

        int index = position - 1;

        var currentPokemon = new Pokemon(name, type, power, position);

        if (index < pokemons.Count)
        {
            pokemons.Insert(index, currentPokemon);
        }
        else
        {
            pokemons.Add(currentPokemon);
        }

        if (!pokemonsByType.ContainsKey(type))
        {
            var newPokemonList = new List<Pokemon>();
            pokemonsByType[type] = newPokemonList;
        }

        pokemonsByType[type].Add(currentPokemon);

        return $"Added pokemon {name} to position {position}";
    }

    public static string Find(string[] parameters)
    {
        string type = parameters[1];

        if (!pokemonsByType.ContainsKey(type))
        {
            return $"Type {type}: ";
        }

        var orderedPokemons = pokemonsByType[type]
                             .OrderBy(x => x.Name)
                             .ThenByDescending(x => x.Power)
                             .Take(5);

        return $"Type {type}: " + string.Join("; ", orderedPokemons.Select(x => $"{x.Name}({x.Power})"));
    }

    public static string Ranklist(string[] parameters)
    {
        int startPosition = int.Parse(parameters[1]);
        int endPosition = int.Parse(parameters[2]);

        StringBuilder orderedPokemons = new StringBuilder();

        int counter = startPosition;

        for (int i = startPosition - 1; i <= endPosition - 1; i++)
        {
            orderedPokemons.Append($"{counter}. " + $"{pokemons[i].Name}({pokemons[i].Power})" + "; ");
            counter++;
        }

        if (orderedPokemons.Length > 0)
        {
            orderedPokemons = orderedPokemons.Remove(orderedPokemons.Length - 2, 2);
        }

        return orderedPokemons.ToString();
    }
}

public struct Pokemon
{
    public Pokemon(string name, string type, int power, int position)
    {
        this.Name = name;
        this.Type = type;
        this.Power = power;
        this.Position = position;
    }

    public string Name { get; private set; }
    public string Type { get; private set; }
    public int Power { get; private set; }
    public int Position { get; set; }

}
