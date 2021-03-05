using System;
using System.Collections.Generic;

namespace HashTables.InClassActivity
{
    public class HashTableTasks
    {
        /// <summary>
        /// Counts the number of occurrences of a each word in a collection.
        /// </summary>
        /// <param name="words">A collection of words.</param>
        /// <returns>A dictionary of occurrences by word.</returns>
        public static Dictionary<string, int> CountOccurences(string[] words)
        {
            var dictionary = new Dictionary<string, int>();

            foreach (string item in words)
            {
                if (!dictionary.ContainsKey(item))
                {
                    dictionary[item] = 0;
                }

                dictionary[item]++;
            }

            return dictionary;
        }

        /// <summary>
        /// Return the indices of the first two numbers that sum to a given number.
        /// </summary>
        /// <param name="numbers">Collection of numbers</param>
        /// <param name="sum">Target sum</param>
        /// <returns>An array containing the indices of the first two numbers that produce the target sum.</returns>
        public static int[] TwoSum(int[] numbers, int sum) 
        {
            int[] indices = new int[] { -1, -1 };

            var dictionary = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int diff = sum - numbers[i];

                if (dictionary.ContainsKey(diff))
                {
                    indices[0] = dictionary[diff];
                    indices[1] = i;

                    return indices;
                }

                dictionary[numbers[i]] = i;
            }

            return indices;
        }

        /// <summary>
        /// Counts how many coins are special.
        /// </summary>
        /// <param name="coins">Coins to check.</param>
        /// <param name="catalogue">The catalogue of special coins.</param>
        /// <returns>The count of special coins</returns>
        public static int SpecialCoins(string coins, string catalogue)
        {
            HashSet<char> set = new HashSet<char>();

            for (int i = 0; i < catalogue.Length; i++)
            {
                set.Add(catalogue[i]);
            }

            int counter = 0;

            for (int i = 0; i < coins.Length; i++)
            {
                if (set.Contains(coins[i]))
                {
                    counter++;
                }
            }

            return counter;
        }

        /// <summary>
        /// Determines whether two strings are isomorphic. 
        /// Two strings are considered isomorphic if each character from the first string can map to a character in the seconds string.
        /// </summary>
        /// <param name="s1">The first string.</param>
        /// <param name="s2">The second string.</param>
        /// <returns>True if the two strings are isomorphic; otherwise, false.</returns>
        public static bool AreIsomorphic(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            var dict = new Dictionary<char, char>();

            for (int i = 0; i < s1.Length; i++)
            {
                char currentFromFirstString = s1[i];
                char currentFromSecondString = s2[i];

                if (dict.ContainsKey(currentFromFirstString))
                {
                    if (dict[currentFromFirstString] != currentFromSecondString)
                    {
                        return false;
                    }
                }
                else
                {
                    if (dict.ContainsValue(currentFromSecondString))
                    {
                        return false;
                    }

                    dict[currentFromFirstString] = currentFromSecondString;
                }
            }

            return true;
        }
    }
}
