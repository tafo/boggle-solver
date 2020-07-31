using System;
using System.IO;

namespace BoggleSolver.Library
{
    public static class WordBook
    {
        public const string Test = "Test";
        public const string Mini = "Mini";
        public const string Midi = "Midi";
        public const string Maxi = "Maxi";

        public static string Path(this string dictionary)
        {
            return $"{Directory.GetCurrentDirectory()}/Dictionary/{dictionary}.txt";
        }

        public static string[] GetWords(this string dictionary)
        {
            return File.ReadAllLines(dictionary.Path());
        }

        public static LetterTrie GetLetterTrie(this string dictionary)
        {
            var root = new LetterTrie();
            Array.ForEach(dictionary.GetWords(), word => root.Set(word));
            return root;
        }
    }
}