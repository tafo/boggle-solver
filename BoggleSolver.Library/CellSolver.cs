namespace BoggleSolver.Library
{
    public class CellSolver
    {
        public LetterTrie RootTrie { get; set; }
        public int ChainCounter { get; set; }

        public ResultModel Run(Boggle boggle)
        {
            var output = new ResultModel();

            boggle.MapCells();
            
            foreach (var cell in boggle.Cells)
            {
                Chain(cell, string.Empty);
            }

            return output;

            void Chain(BoggleCell cell, string chain)
            {
                cell.IsVisited = true;
                chain = $"{chain}{cell.Letter}";
                if (!CheckChain(chain))
                {
                    cell.IsVisited = false;
                    return;
                }

                foreach (var adjacentCell in cell.AvailableAdjacentCells)
                {
                    Chain(adjacentCell, chain);
                }

                cell.IsVisited = false;
            }

            bool CheckChain(string chain)
            {
                ChainCounter++;

                if (chain.Length < 3) return true;

                if (chain.Length > boggle.Size) return false;

                switch (RootTrie.Check(chain))
                {
                    case -1:
                        return false;
                    case 0:
                        // ToDo: !
                        break;
                    case 1:
                        output.Words.Add(chain);
                        break;
                }

                return true;
            }
        }

        public override string ToString() => "Cell Solver";
    }
}