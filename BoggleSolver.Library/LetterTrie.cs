using System.Collections.Generic;
using System.Linq;

namespace BoggleSolver.Library
{
    public class LetterTrie
    {
        public bool IsLastLetter { get; set; }
        public char Letter { get; set; }
        public List<LetterTrie> Letters { get; set; }

        public LetterTrie(char letter = '?')
        {
            Letter = letter;
            Letters = new List<LetterTrie>();
        }

        public LetterTrie this[char letter] => Letters.Find(x => x.Letter == letter);

        public void Set(string word)
        {
            var lastTrie = word.Aggregate(this, (trie, letter) => trie.Set(letter));
            lastTrie.IsLastLetter = true;
        }

        private LetterTrie Set(char letter)
        {
            return this[letter] ?? Create(letter);
        }

        private LetterTrie Create(char letter)
        {
            var trie = new LetterTrie(letter);
            Letters.Add(trie);
            return trie;
        }

        public int Check(string chain)
        {
            var i = 0;
            var trie = this;
            do
            {
                trie = trie[chain[i++]];
            } while (trie != null && i < chain.Length);

            if (trie == null) return -1;
            return trie.IsLastLetter ? 1 : 0;
        }
    }
}