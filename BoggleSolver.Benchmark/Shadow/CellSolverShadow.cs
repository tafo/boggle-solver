using BoggleSolver.Library;

namespace BoggleSolver.Benchmark.Shadow
{
    public class CellSolverShadow
    {
        private readonly int _maxWordLength;
        public int ChainCounter { get; set; }

        public CellSolverShadow(int maxWordLength)
        {
            _maxWordLength = maxWordLength;
        }

        public ResultModel Run(Boggle boggle)   
        {
            var result = new ResultModel();
            boggle.MapCells();
            for (var i = 0; i < boggle.RowSize; i++)
            {
                for (var j = 0; j < boggle.ColSize; j++)
                {
                    Chain(boggle.CellGrid[i][j], string.Empty);
                }
            }
            return result;

            void Chain(BoggleCell cell, string chain)
            {
                cell.IsVisited = true;
                chain = $"{chain}{cell.Letter}";
                if (!CheckChain(chain))
                {
                    cell.IsVisited = false;
                    return;
                }

                foreach (var adjacentCell in cell.AdjacentCells)
                {
                    if (adjacentCell.IsVisited) continue;
                    Chain(adjacentCell, chain);
                }

                cell.IsVisited = false;
            }

            bool CheckChain(string chain)
            {
                ChainCounter++;
                return chain.Length <= _maxWordLength;
            }
        }

        public override string ToString() => "Cell Solver";
    }
}