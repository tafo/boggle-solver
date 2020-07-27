using System;
using System.Collections.Generic;
using System.IO;

namespace BoggleSolver.Library
{
    public class TheBook
    {
        public const string Test = "Test";
        public const string Mini = "Mini";
        public const string Midi = "Midi";
        public const string Maxi = "Maxi";

        public static string GetPath(string dictionary)
        {
            return $"{Directory.GetCurrentDirectory()}/Dictionary/{dictionary}.txt";
        }

        public static string[] GetWords(string size)
        {
            return File.ReadAllLines(GetPath(size));
        }

        public static HashSet<string> GetSet(string size)
        {
            return new HashSet<string>(GetWords(size));
        }

        public static Dictionary<char, HashSet<string>> GetDictionary(string size)
        {
            var dictionary = new Dictionary<char, HashSet<string>>();
            Array.ForEach(Letters, letter => dictionary.Add(letter, new HashSet<string>()));
            Array.ForEach(GetWords(size), word => dictionary[word[0]].Add(word));
            return dictionary;
        }

        public static readonly char[] Letters =
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
            'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };
    }
}