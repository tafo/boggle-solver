using System;
using System.Collections.Generic;

namespace BoggleSolver.Library
{
    public class HashSetSolver
    {
        public HashSet<string> Words { get; set; }

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

            
            return result.Sort();

            void Chain(int rowIndex, int colIndex, string chain)
            {
                visited[rowIndex, colIndex] = true;

                chain = $"{chain}{boggle.Grid[rowIndex][colIndex]}";

                if (Words.Contains(chain)) result.Words.Add(chain);

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
        }

        public override string ToString() => "HashSet";
    }
}