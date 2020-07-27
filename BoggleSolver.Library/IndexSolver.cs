using System;
using System.Collections.Generic;

namespace BoggleSolver.Library
{
    public class IndexSolver
    {
        public Dictionary<string, HashSet<string>> WordBook { get; set; }

        public int ChainCounter { get; set; }

        public ResultModel Run(BoggleModel boggle)
        {
            var result = new ResultModel();

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
                chain = $"{chain}{boggle.Grid[rowIndex][colIndex]}";

                if (!CheckChain(chain)) return;

                var rowMin = Math.Max(0, rowIndex - 1);
                var colMin = Math.Max(0, colIndex - 1);

                var rowMax = Math.Min(boggle.RowSize - 1, rowIndex + 1);
                var colMax = Math.Min(boggle.ColSize - 1, colIndex + 1);

                for (var x = rowMin; x <= rowMax; x++)
                {
                    for (var y = colMin; y <= colMax; y++)
                    {
                        if (rowIndex == x && colIndex == y) continue;
                        Chain(x, y, chain);
                    }
                }
            }

            bool CheckChain(string chain)
            {
                ChainCounter++;

                if (chain.Length < 3) return true;

                if (chain.Length > boggle.Size) return false;

                var ABC = chain.Substring(0, 3);

                if (!WordBook.ContainsKey(ABC)) return false;

                if (WordBook[ABC].Contains(chain)) result.Add(chain);
                return true;
            }
        }

        public override string ToString() => "Index";
    }
}