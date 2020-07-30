using System.Collections.Generic;

namespace BoggleSolver.Library
{
    public class LetterTrie
    {
        public bool IsLastLetter { get; set; }
        public int LetterCode { get; set; }
        public List<LetterTrie> Letters { get; set; }

        public LetterTrie(int letterCode = -1)
        {
            LetterCode = letterCode;
            Letters = new List<LetterTrie>();
        }

        private LetterTrie this[int i]
        {
            get
            {
                var trie = Letters.Find(x => x.LetterCode == i);
                if (trie != null) return trie;
                trie = new LetterTrie(i);
                Letters.Add(trie);
                return trie;
            }
        }

        private LetterTrie this[char c] => Letters.Find(x => x.LetterCode == c);

        public void Set(string word)
        {
            var i = 0;
            var trie = this;
            do
            {
                trie = trie[(int)word[i++]];
            } while (i < word.Length);

            trie.IsLastLetter = true;
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