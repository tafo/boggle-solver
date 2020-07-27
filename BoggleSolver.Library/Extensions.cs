using System;
using System.Collections.Generic;
using System.IO;

namespace BoggleSolver.Library
{
    public static class Extensions
    {
        public static string Path(this string dictionary)
        {
            return $"{Directory.GetCurrentDirectory()}/Dictionary/{dictionary}.txt";
        }

        public static string[] ToArray(this string size)
        {
            return File.ReadAllLines(size.Path());
        }

        public static HashSet<string> ToHashSet(this string size)
        {
            return new HashSet<string>(size.ToArray());
        }

        public static Dictionary<char, HashSet<string>> ToDictionary(this string size)
        {
            var dictionary = new Dictionary<char, HashSet<string>>();
            var words = size.ToArray();
            Array.ForEach(Constants.Letters, letter => dictionary.Add(letter, new HashSet<string>()));
            Array.ForEach(words, word => dictionary[word[0]].Add(word));
            return dictionary;
        }
    }
}