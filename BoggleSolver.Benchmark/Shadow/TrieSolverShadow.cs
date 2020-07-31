using System;
using BoggleSolver.Library;

namespace BoggleSolver.Benchmark.Shadow
{
    public class TrieSolverShadow
    {
        private readonly int _maxWordLength;
        public int ChainCounter { get; set; }

        public TrieSolverShadow(int maxWordLength)
        {
            _maxWordLength = maxWordLength;
        }

        public ResultModel Run(Boggle boggle)
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
                return chain.Length <= _maxWordLength;
            }
        }

        public override string ToString() => "Trie Solver";
    }
}