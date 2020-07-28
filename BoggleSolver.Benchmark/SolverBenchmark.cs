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

        [Params(1)] public int Level;

        public BoggleModel Boggle { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            var json = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Boggle.json");
            Boggle = JsonConvert.DeserializeObject<BoggleModel>(json);
        }

        [Benchmark]
        public void Trie()
        {
            LetterTrie.Level = Level;
            var solver = new Solver(Size);
            solver.Run(Boggle);
        }
    }
}