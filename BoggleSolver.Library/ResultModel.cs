using System.Collections.Generic;
using System.Linq;

namespace BoggleSolver.Library
{
    public class ResultModel
    {
        public HashSet<string> Words { get; set; }
        private static readonly int[] Points = {0, 0, 0, 1, 1, 2, 3, 5, 11};
        public int Score => Words.Sum(x => Points[x.Length > 8 ? 8 : x.Length]);
        public int ChainCounter { get; set; }
        public ResultModel()
        {
            Words = new HashSet<string>();
        }

        public ResultModel SetChainCounter(int chainCounter)
        {
            ChainCounter = chainCounter;
            return this;
        }
    }
}