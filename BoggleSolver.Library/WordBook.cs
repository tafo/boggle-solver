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

        public static string Path(this string size)
        {
            return $"{Directory.GetCurrentDirectory()}/Dictionary/{size}.txt";
        }

        public static string[] GetWords(this string size)
        {
            return File.ReadAllLines(size.Path());
        }

        public static LetterTrie GetTrie(this string size)
        {
            var root = new LetterTrie();
            var words = size.GetWords();
            Array.ForEach(words, word => { root.Set(word); });
            return root;
        }
    }
}