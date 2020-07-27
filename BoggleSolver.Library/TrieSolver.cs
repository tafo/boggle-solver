using System;

namespace BoggleSolver.Library
{
    public class TrieSolver
    {
        public LetterTrie RootTrie { get; set; }
        public int ChainCounter { get; set; }

        public ResultModel Run(BoggleModel boggle)
        {
            var result = new ResultModel();

            var visited = new bool[boggle.RowSize, boggle.ColSize];

            for (var i = 0; i < boggle.RowSize; i++)
            {
                for (var j = 0; j < boggle.ColSize; j++)
                {
                    Chain(i, j, string.Empty);
                }
            }

            return result;

            void Chain(int rowIndex, int colIndex, string chain)
            {
                visited[rowIndex, colIndex] = true;

                chain = $"{chain}{boggle.Grid[rowIndex][colIndex]}";

                if (!CheckChain(chain))
                {
                    visited[rowIndex, colIndex] = false;
                    return;
                }

                var rowMin = Math.Max(0, rowIndex - 1);
                var colMin = Math.Max(0, colIndex - 1);

                var rowMax = Math.Min(boggle.RowSize - 1, rowIndex + 1);
                var colMax = Math.Min(boggle.ColSize - 1, colIndex + 1);

                for (var x = rowMin; x <= rowMax; x++)
                {
                    for (var y = colMin; y <= colMax; y++)
                    {
                        if (visited[x, y]) continue;
                        Chain(x, y, chain);
                    }
                }

                visited[rowIndex, colIndex] = false;
            }

            bool CheckChain(string chain)
            {
                ChainCounter++;

                if (chain.Length < 3) return true;

                if (chain.Length > boggle.Size) return false;

                var i = 0;
                var trie = RootTrie;
                while (i < LetterTrie.Level && i < chain.Length)
                {
                    var letter = chain[i];
                    trie = trie.Children.Find(x => x.Letter == letter);
                    if (trie == null) return false;
                    i++;
                }

                if (trie == null) return false;
                if (trie.IsLastLetter || trie.Words.Contains(chain)) result.Add(chain);
                return true;
            }
        }

        public override string ToString() => "Trie";
    }
}