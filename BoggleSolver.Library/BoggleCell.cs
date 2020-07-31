using System.Collections.Generic;

namespace BoggleSolver.Library
{
    public class BoggleCell
    {
        public BoggleCell(char letter)
        {
            Letter = letter;
            IsVisited = false;
            AdjacentCells = new List<BoggleCell>(8);
        }

        public char Letter { get; set; }
        public bool IsVisited { get; set; }

        public List<BoggleCell> AdjacentCells { get; set; }
    }
}