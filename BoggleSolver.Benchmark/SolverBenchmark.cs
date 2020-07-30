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

        [Params(MiniBoggle, MidiBoggle, MaxiBoggle)]
        public string BoggleSize;

        private Dictionary<string, Boggle> _boggleList;
        private Dictionary<string, LetterTrie> _letterTrieList;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _letterTrieList = new Dictionary<string, LetterTrie>
            {
                {WordBook.Mini, WordBook.Mini.GetLetterTrie()},
                {WordBook.Midi, WordBook.Midi.GetLetterTrie()},
                {WordBook.Maxi, WordBook.Maxi.GetLetterTrie()}
            };

            var json = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Boggles.json");
            var boggles = JsonConvert.DeserializeObject<Boggle[]>(json);
            _boggleList = new Dictionary<string, Boggle>
            {
                {MiniBoggle, boggles[0]},
                {MidiBoggle, boggles[1]},
                {MaxiBoggle, boggles[2]},
            };
        }

        private const string MiniBoggle = "Mini";
        private const string MidiBoggle = "Midi";
        private const string MaxiBoggle = "Maxi";

        [Benchmark]
        public void TrieSolver()
        {
            new TrieSolver
            {
                RootTrie = _letterTrieList[DictionarySize]
            }.Run(_boggleList[BoggleSize]);
        }

        [Benchmark]
        public void CellSolver()
        {
            new CellSolver
            {
                RootTrie = WordBook.Test.GetLetterTrie()
            }.Run(_boggleList[BoggleSize]);
        }
    }
}