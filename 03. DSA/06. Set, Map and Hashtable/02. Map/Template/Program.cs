using System;
using System.Collections.Generic;

namespace InHomeActivity.Map
{
    class Program
    {
        static void Main()
        {
            var data = new[]
            {
             new KeyValuePair<string,string>("US", "New York"),
             new KeyValuePair<string,string>("BG", "Sofia"),
             new KeyValuePair<string,string>("UK", "London"),
             new KeyValuePair<string,string>("BG", "Plovdiv"),
             new KeyValuePair<string,string>("UK", "Manchester"),
             new KeyValuePair<string,string>("US", "Chicago")
            };

            var groupedData = Group(data);

            foreach (var item in groupedData)
            {
                Console.WriteLine($"{item.Key}: {string.Join(", ", item.Value)}");
            }
        }

        static Dictionary<string, int> CountOccurrences(string[] array)
        {
            var dictionary = new Dictionary<string, int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (dictionary.ContainsKey(array[i]))
                {
                    dictionary[array[i]]++;
                }
                else
                {
                    dictionary[array[i]] = 1;
                }
            }

            return dictionary;
        }

        static Dictionary<string, List<string>> Group(KeyValuePair<string, string>[] data)
        {
            var dictionary = new Dictionary<string, List<string>>();

            foreach (var kvp in data)
            {
                if (!dictionary.ContainsKey(kvp.Key))
                {
                    dictionary[kvp.Key] = new List<string>();
                }

                dictionary[kvp.Key].Add(kvp.Value);
            }

            return dictionary;
        }
    }
}
