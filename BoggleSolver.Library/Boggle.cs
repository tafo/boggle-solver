using System;

namespace BoggleSolver.Library
{
    public class Boggle
    {
        public char[][] Grid { get; set; }
        public int RowSize => Grid.Length;
        public int ColSize => Grid[0].Length;
        public int MaxRowIndex => RowSize - 1;
        public int MaxColIndex => ColSize - 1;
        public int Size => RowSize * ColSize;
        public int Count { get; set; }
        public int Score { get; set; }

        public BoggleCell[][] CellGrid { get; set; }

        public override string ToString()
        {
            return $"{RowSize}X{ColSize}";
        }

        public void MapCells()
        {
            CellGrid = new BoggleCell[RowSize][];
            for (var i = 0; i < RowSize; i++)
            {
                CellGrid[i] = new BoggleCell[ColSize];
                for (var j = 0; j < ColSize; j++)
                {
                    CellGrid[i][j] = new BoggleCell(Grid[i][j]);
                }
            }

            for (var i = 0; i < RowSize; i++)
            {
                for (var j = 0; j < ColSize; j++)
                {
                    var rowMin = Math.Max(0, i - 1);
                    var colMin = Math.Max(0, j - 1);

                    var rowMax = Math.Min(MaxRowIndex, i + 1);
                    var colMax = Math.Min(MaxColIndex, j + 1);

                    for (var x = rowMin; x <= rowMax; x++)
                    {
                        for (var y = colMin; y <= colMax; y++)
                        {
                            if (x == i && y == j) continue;
                            CellGrid[i][j].AdjacentCells.Add(CellGrid[x][y]);
                        }
                    }
                }
            }
        }
    }
}