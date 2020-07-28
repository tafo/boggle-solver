using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using BoggleSolver.Library;
using Newtonsoft.Json;

namespace BoggleSolver.Benchmark
{
    [SimpleJob(RunStrategy.Monitoring, RuntimeMoniker.NetCoreApp31)]
    public class SolverBenchmark
    {
        [Params(WordBook.Mini, WordBook.Midi, WordBook.Maxi)]
        public string Size;

        [Params(1, 2, 3)] public int Level;

        private BoggleModel _boggle;

        private Solver _solver;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var json = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Boggle.json");
            _boggle = JsonConvert.DeserializeObject<BoggleModel>(json);
            _solver = new Solver(Size);
        }


        [Benchmark]
        public void Trie()
        {
            LetterTrie.Level = Level;
            _solver.Run(_boggle);
        }
    }
}