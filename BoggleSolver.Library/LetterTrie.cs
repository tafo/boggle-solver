using System.Collections.Generic;

namespace BoggleSolver.Library
{
    public class LetterTrie
    {
        public static int Level = 1;
        public char Letter { get; set; }
        public List<LetterTrie> Letters { get; set; }
        public HashSet<string> Words { get; set; }

        public LetterTrie(char letter = '#')
        {
            Letter = letter;
            Letters = new List<LetterTrie>();
            Words = new HashSet<string>();
        }

        private LetterTrie this[char c] => Letters.Find(x => x.Letter == c);

        public void Set(string word)
        {
            var trie = Level switch
            {
                1 => Get(word[0]),
                2 => Get(word[0]).Get(word[1]),
                _ => Get(word[0]),
            };

            trie.Words.Add(word);
        }

        private LetterTrie Get(char c)
        {
            var letter = Letters.Find(x => x.Letter == c);
            if (letter != null) return letter;
            letter = new LetterTrie(c);
            Letters.Add(letter);
            return letter;
        }

        public int Check(string chain)
        {
            var trie = Level switch
            {
                1 => this[chain[0]],
                2 => this[chain[0]][chain[1]],
                _ => this[chain[0]],
            };

            if (trie == null) return -1;
            return trie.Words.Contains(chain) ? 1 : 0;
        }
    }
}