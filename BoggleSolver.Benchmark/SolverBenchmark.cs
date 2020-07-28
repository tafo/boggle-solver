using System;
using System.Collections.Generic;
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

        [Params(4, 5)] public int Level;

        private BoggleModel _boggle;

        private Dictionary<string, LetterTrie> _tries;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var json = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Boggle.json");
            _boggle = JsonConvert.DeserializeObject<BoggleModel>(json);
            var levels = new[] {4, 5};
            var sizes = new[] {WordBook.Mini, WordBook.Midi, WordBook.Maxi};
            _tries = new Dictionary<string, LetterTrie>();
            Array.ForEach(sizes, size => Array.ForEach(levels, L =>
            {
                LetterTrie.Level = L;
                _tries.Add(size + L, size.GetTrie());
            }));
        }

        [Benchmark]
        public void Trie()
        {
            LetterTrie.Level = Level;
            new Solver {RootTrie = _tries[Size + Level]}.Run(_boggle);
        }
    }
}