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
    [SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NetCoreApp31)]
    public class SolverBenchmark
    {
        [Params(WordBook.Mini, WordBook.Midi, WordBook.Maxi)]
        public string DictionarySize;
        public Dictionary<string, LetterTrie> LetterTrieList;
        public Boggle[] Boggles;

        [GlobalSetup]
        public void GlobalSetup()
        {
            LetterTrieList = new Dictionary<string, LetterTrie>
            {
                {WordBook.Mini, WordBook.Mini.GetLetterTrie()},
                {WordBook.Midi, WordBook.Midi.GetLetterTrie()},
                {WordBook.Maxi, WordBook.Maxi.GetLetterTrie()}
            };

            var json = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Boggles.json");
            Boggles = JsonConvert.DeserializeObject<Boggle[]>(json);
        }

        [Benchmark]
        public void TrieSolver()
        {
            var solver = new TrieSolver
            {
                RootTrie = LetterTrieList[DictionarySize]
            };
            Array.ForEach(Boggles, boggle => solver.Run(boggle));
        }

        [Benchmark]
        public void CellSolver()
        {
            var solver = new CellSolver
            {
                RootTrie = LetterTrieList[DictionarySize]
            };
            Array.ForEach(Boggles, boggle => solver.Run(boggle));
        }
    }
}