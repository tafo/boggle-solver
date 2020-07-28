using System;
using System.Collections.Generic;

namespace BoggleSolver.Library
{
    public class LetterTrie
    {
        public int LetterCode { get; set; }
        public List<LetterTrie> Letters { get; set; }
        public HashSet<string> Words { get; set; }

        public LetterTrie(int letterCode = -1)
        {
            LetterCode = letterCode;
            Letters = new List<LetterTrie>();
            Words = new HashSet<string>();
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

        public void Set(string word, int level)
        {
            var chainSize = Math.Min(word.Length, level);
            var trie = chainSize switch
            {
                4 => this[word.L0()][word.L1()][word.L2()][word.L3()],
                _ => this[word.L0()][word.L1()][word.L2()],
            };

            trie.Words.Add(word);
        }

        public int Check(string chain, int level)
        {
            var chainSize = Math.Min(chain.Length, level);
            var trie = chainSize switch
            {
                4 => this[chain[0]]?[chain[1]]?[chain[2]]?[chain[3]],
                _ => this[chain[0]]?[chain[1]]?[chain[2]],
            };

            if (trie == null) return -1;
            return trie.Words.Contains(chain) ? 1 : 0;
        }
    }
}