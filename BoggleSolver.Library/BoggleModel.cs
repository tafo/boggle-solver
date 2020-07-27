namespace BoggleSolver.Library
{
    public class BoggleModel
    {
        public char[][] Grid { get; set; }
        public int RowSize => Grid.Length;
        public int ColSize => Grid[0].Length;
        public int Size => RowSize * ColSize;
        public int Count { get; set; }
        public int Score { get; set; }

        public override string ToString()
        {
            return $"{RowSize}X{ColSize}";
        }
    }
}