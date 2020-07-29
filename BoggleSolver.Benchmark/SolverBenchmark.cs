using System.Collections.Generic;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using BoggleSolver.Library;
using Newtonsoft.Json;

namespace BoggleSolver.Benchmark
{
    [SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NetCoreApp31)]
    public class SolverBenchmark
    {
        [Params(WordBook.Mini, WordBook.Midi, WordBook.Maxi)]
        public string Size;

        private BoggleModel _boggle;

        private Dictionary<string, LetterTrie> _tries;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var json = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Boggle.json");
            _boggle = JsonConvert.DeserializeObject<BoggleModel>(json);
            _tries = new Dictionary<string, LetterTrie>
            {
                {WordBook.Mini, WordBook.Mini.GetTrie()},
                {WordBook.Midi, WordBook.Midi.GetTrie()},
                {WordBook.Maxi, WordBook.Maxi.GetTrie()}
            };
        }

        [Benchmark]
        public void Trie()
        {
            new Solver {RootTrie = _tries[Size]}.Run(_boggle);
        }
    }
}