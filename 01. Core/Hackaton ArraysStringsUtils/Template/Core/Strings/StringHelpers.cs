using System;
using System.Linq;

namespace TelerikAcademy.Core
{
    public class StringHelpers
    {

        /// <summary>
        /// Abbreviates a string using ellipses.
        /// </summary>
        /// <param name="source">The string to modify.</param>
        /// <param name="maxLength">Maximum length of the resulting string.</param>
        /// <returns>The abbreviated string.</returns>
        /// <author>Boryana Mihaylova</author>
        public static string Abbreviate(string source, int maxLength)
        {
            string abbreviation = string.Empty;

            if (maxLength > source.Length)
            {
                return source; 
            }

            for (int i = 0; i < maxLength; i++)
            {
                abbreviation += source[i].ToString();
            }

            abbreviation += "...";

            return abbreviation;
        }

        /// <summary>
        /// Makes first letter of a string uppercase.
        /// </summary>
        /// <param name="source">The string that has to be capitalized.</param>
        /// <returns>A string with uppercased first letter.</returns>
        /// <author>Boryana Mihaylova</author>
        public static string Capitalize(string source)
        {
            string capitalized = string.Empty;

            for (int i = 0; i < source.Length; i++)
            {
                if (i == 0)
                {
                    capitalized += source[i].ToString().ToUpper();
                }
                else
                {
                    capitalized += source[i].ToString();
                }
            }

            return capitalized;
        }

        /// <summary>
        /// Concatenates two strings and returns a new string.
        /// </summary>
        /// <param name="string1">The first string</param>
        /// <param name="string2">The second string</param>
        /// <returns>A string that represents the concatenation of string1's characters followed by string2's characters.</returns>
        /// <author>Cvetomir Georgiev</author>

        public static string Concat(string string1, string string2)
        {
            string result = "";

            for (int i = 0; i < string1.Length; i++)
            {
                result += string1[i];
            }
            for (int i = 0; i < string2.Length; i++)
            {
                result += string2[i];
            }

            return result;
        }

        /// <summary>
        /// Checks if a string contains certain symbol.
        /// </summary>
        /// <param name="source">The string to check for containing symbol</param>
        /// <param name="symbol">The symbol to check</param>
        /// <returns>Bool variable.</returns>
        /// <author>Cvetomir Georgiev</author>

        public static bool Contains(string source, char symbol)
        {
            bool isContained = true;

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == symbol)
                {
                    isContained = true;
                }
                else
                {
                    isContained = false;
                }
            }

            return isContained;
        }
        /// <summary>
        /// A check if a string starts with a given character.
        /// </summary>
        /// <param name="source">String to check from.</param>
        /// <param name="target">Character to check for.</param>
        /// <returns>Boolean if source starts with target.</returns>
        /// <author>Dimitar Piskov</author>
        public static bool StartsWith(string source, char target)
        {
            return (source[0] == target);
        }
        /// <summary>
        /// A check if a string ends with a given character.
        /// </summary>
        /// <param name="source">String to check from.</param>
        /// <param name="target">Character to check for.</param>
        /// <returns>Boolean if source starts with target.</returns>
        /// <author>Dimitar Piskov</author>
        public static bool EndsWith(string source, char target)
        {
            return (source[source.Length - 1] == target);
        }
        /// <summary>
        /// Finds the first index of target within source.
        /// </summary>
        /// <param name="source">The string to check</param>
        /// <param name="target">The character to check for</param>
        /// <returns>The first index of target within source, otherwise, -1</returns>
        /// <author>Emil Nenchev</author>
        public static int FirstIndexOf(string source, char target)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (target==source[i])
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Finds the last index of target within source.
        /// </summary>
        /// <param name="source">The string to check</param>
        /// <param name="symbol">The character to check for</param>
        /// <returns>The last index symbol within source or -1 if no match</returns>
        /// <author>Emil Nenchev</author>
        public static int LastIndexOf(string source, char symbol)
        {
            int last = 0;
            for (int i = 0; i < source.Length; i++)
            {
                if (symbol==source[i])
                {
                    last = i;
                }
            }
            if (last>0)
            {
                return last;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Pads string on the left and right sides if it's shorter than length.
        /// </summary>
        /// <param name="source">The string to pad</param>
        /// <param name="length">The length of the string to achieve</param>
        /// <param name="paddingSymbol">The character used as padding</param>
        /// <returns>The padded string</returns>
        /// <author>Georgi Avramov</author>
        public static string Pad(string source, int length, char paddingSymbol)
        {
            int paddingLength = length - source.Length;
            if (paddingLength % 2 != 0)
            {
                paddingLength -= 1;
            }
            string result = "";
            for (int i = 0; i < paddingLength; i++)
            {
                result += paddingSymbol;
                if (i == (paddingLength - 1) / 2)
                {
                    result += source;
                }
            }
            if (length <= 1)
            {
                return source;
            }
            return result;
        }

        /// <summary>
        /// Pads `source` on the right side with `PaddingSymbol` enough times to reach length `length`.
        /// </summary>
        /// <param name="source">The string to pad</param>
        /// <param name="length">The length of the string to achieve</param>
        /// <param name="paddingSymbol">The character used as padding</param>
        /// <returns>The padded string</returns>
        /// <author>Georgi Avramov</author>
        public static string PadEnd(string source, int length, char paddingSymbol)
        {
            int paddingLength = length - source.Length;

            string result = source;
            for (int i = 0; i < paddingLength; i++)
            {
                result += paddingSymbol;
            }
           
            return result;
        }

        /// <summary>
        /// Pads `source` on the left side with `PaddingSymbol` enough times to reach length `length`.
        /// </summary>
        /// <param name="source">The string to pad</param>
        /// <param name="length">The length of the string to achieve</param>
        /// <param name="paddingSymbol">The character used as padding</param>
        /// <returns>The padded string</returns>
        /// <author>Georgi Avramov</author>
        public static string PadStart(string source, int length, char paddingSymbol)
        {
            int paddingLength = length - source.Length;

            string result = "";
            for (int i = 0; i < paddingLength; i++)
            {
                result += paddingSymbol;
            }
            result += source;

            return result;
        }
        /// <summary>
        /// Repeats the given string `times` times.
        /// </summary>
        /// <param name="source">The string to repeat.</param>
        /// <param name="times">The number of times to repeat the string.</param>
        /// <returns>The repeated string.</returns>
        /// <author>Svetlin Vlaev</author>
        public static string Repeat(string source, int times)
        {
            string result = source;
            for (int i = 1; i < times; i++)
            {
                result += source;
            }
            return result;
        }
        /// <summary>
        /// Reverses `source` so that the first element becomes the last, the second element becomes the second to last, and so on.
        /// </summary>
        /// <param name="source">string - *The string to reverse*</param>
        /// <returns>The reversed string</returns>
        /// <author>Svetlin Vlaev</author>
        public static string Reverse(string source)
        {
            char[] cArray = source.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }

        /// <summary>
        /// Gets a certain part of the string and returns new string.
        /// </summary>
        /// <param name="source">The string to modify</param>
        /// <param name="start">The start index</param>
        /// <param name="end">The end index</param>
        /// <returns>A new substringed string.</returns>
        /// <author>Cvetomir Georgiev</author>

        public static string Section(string source, int start, int end)
        {
            string result = "";

            for (int i = start; i <= end; i++)
            {
                result += source[i];
            }

            return result;
        }
    }
}
