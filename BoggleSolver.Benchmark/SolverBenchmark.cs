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

        [Params(3, 4)] public int Level;

        private BoggleModel _boggle;

        private Dictionary<string, LetterTrie> _tries;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var json = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Boggle.json");
            _boggle = JsonConvert.DeserializeObject<BoggleModel>(json);
            var levels = new[] {3, 4};
            var sizes = new[] {WordBook.Mini, WordBook.Midi, WordBook.Maxi};
            _tries = new Dictionary<string, LetterTrie>();
            Array.ForEach(sizes, size => Array.ForEach(levels, L => _tries.Add(size + L, size.GetTrie(L))));
        }

        [Benchmark]
        public void Trie()
        {
            new Solver { RootTrie = _tries[Size + Level], TrieLevel = Level }.Run(_boggle);
        }
    }
}