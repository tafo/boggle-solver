using System.Collections.Generic;

namespace BoggleSolver.Library
{
    public class BoggleCell
    {
        public BoggleCell(int rowIndex, int colIndex, char letter)
        {
            RowIndex = rowIndex;
            ColIndex = colIndex;
            Key = rowIndex * 10 + colIndex;
            Letter = letter;
            IsVisited = false;
            AdjacentCells = new List<BoggleCell>(8);
        }

        public int Key { get; set; }
        public int RowIndex { get; set; }
        public int ColIndex { get; set; }
        public char Letter { get; set; }
        public bool IsVisited { get; set; }

        public List<BoggleCell> AdjacentCells { get; set; }
        public List<BoggleCell> AvailableAdjacentCells => AdjacentCells.FindAll(x => !x.IsVisited);
    }
}