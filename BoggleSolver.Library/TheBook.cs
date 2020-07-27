using System;
using System.Collections.Generic;
using System.IO;

namespace BoggleSolver.Library
{
    public class TheBook
    {
        public const string Abc = "Abc";
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

        public static Dictionary<char, HashSet<string>> GetDictionary(string size)
        {
            var words = GetWords(size);
            return GetDictionary(words);
        }

        private static Dictionary<char, HashSet<string>> GetDictionary(string[] words)
        {
            var dictionary = new Dictionary<char, HashSet<string>>();
            Array.ForEach(Letters, letter => dictionary.Add(letter, new HashSet<string>()));
            Array.ForEach(words, word => dictionary[word[0]].Add(word));
            return dictionary;
        }

        public static Dictionary<string, HashSet<string>> GetIndex(string size)
        {
            var book = new Dictionary<string, HashSet<string>>();
            var words = GetWords(size);
            Array.ForEach(words, word =>
            {
                var ABC = word.Substring(0, 3);
                if (!book.ContainsKey(ABC)) book.Add(ABC, new HashSet<string>());
                book[ABC].Add(word);
            });
            return book;
        }

        public static LetterTrie GetTrie(string size)
        {
            var root = new LetterTrie();
            var words = GetWords(size);
            LetterTrie.IsReadOnly = false;
            Array.ForEach(words, word =>
            {
                var trie = root[word[0]][word[1]][word[2]];
                switch (word.Length)
                {
                    case 3:
                        trie.Words.Add(word);
                        break;
                    default:
                        trie = trie[word[3]];
                        trie.Words.Add(word);
                        break;
                }
            });
            LetterTrie.Level = 4;
            LetterTrie.IsReadOnly = true;
            return root;
        }

        public static readonly char[] Letters =
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
            'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };
    }
}