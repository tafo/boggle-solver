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

        public static LetterTrie GetTrie(this string size, int level)
        {
            var root = new LetterTrie();
            var words = size.GetWords();
            Array.ForEach(words, word => { root.Set(word, level); });
            return root;
        }

        public static int L0(this string word) => word[0];
        public static int L1(this string word) => word[1];
        public static int L2(this string word) => word[2];
        public static int L3(this string word) => word[3];
    }
}