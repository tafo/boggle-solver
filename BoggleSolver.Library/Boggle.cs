using System;
using System.Collections.Generic;

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

        public List<BoggleCell> Cells { get; set; }

        public override string ToString()
        {
            return $"{RowSize}X{ColSize}";
        }

        public void MapCells()
        {
            Cells = new List<BoggleCell>(Size);
            for (var i = 0; i < RowSize; i++)
            {
                for (var j = 0; j < ColSize; j++)
                {
                    var cell = GetCell(i, j);
                    var rowMin = Math.Max(0, i - 1);
                    var colMin = Math.Max(0, j - 1);

                    var rowMax = Math.Min(MaxRowIndex, i + 1);
                    var colMax = Math.Min(MaxColIndex, j + 1);

                    for (var x = rowMin; x <= rowMax; x++)
                    {
                        for (var y = colMin; y <= colMax; y++)
                        {
                            if (x == i && y == j) continue;
                            var adjacentCell = GetCell(x, y);
                            cell.AdjacentCells.Add(adjacentCell);
                        }
                    }
                }
            }

            BoggleCell GetCell(int i, int j)
            {
                var key = i * 10 + j;
                var cell = Cells.Find(x => x.Key == key);
                if (cell != null) return cell;
                cell = new BoggleCell(i, j, Grid[i][j]);
                Cells.Add(cell);
                return cell;
            }
        }
    }
}