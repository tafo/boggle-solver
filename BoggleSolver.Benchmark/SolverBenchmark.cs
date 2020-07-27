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
        public LetterTrie MiniBook { get; set; }
        public LetterTrie MidiBook { get; set; }
        public LetterTrie MaxiBook { get; set; }

        public Dictionary<string, HashSet<string>> MiniIndex { get; set; }
        public Dictionary<string, HashSet<string>> MidiIndex { get; set; }
        public Dictionary<string, HashSet<string>> MaxiIndex { get; set; }

        [Params(TheBook.Mini, TheBook.Midi, TheBook.Maxi)]
        public string Size;

        public BoggleModel Boggle { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            MiniBook = TheBook.GetTrie(TheBook.Mini);
            MidiBook = TheBook.GetTrie(TheBook.Midi);
            MaxiBook = TheBook.GetTrie(TheBook.Maxi);

            MiniIndex = TheBook.GetIndex(TheBook.Mini);
            MidiIndex = TheBook.GetIndex(TheBook.Midi);
            MaxiIndex = TheBook.GetIndex(TheBook.Maxi);

            var json = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Boggle.json");
            Boggle = JsonConvert.DeserializeObject<BoggleModel>(json);
        }

        [Benchmark]
        public void Trie()
        {
            var solver = new TrieSolver()
            {
                RootTrie = Size switch
                {
                    TheBook.Mini => MiniBook,
                    TheBook.Midi => MidiBook,
                    TheBook.Maxi => MaxiBook,
                    _ => MiniBook
                }
            };
            solver.Run(Boggle);
        }

        [Benchmark]
        public void Index()
        {
            var solver = new IndexSolver
            {
                WordBook = Size switch
                {
                    TheBook.Mini => MiniIndex,
                    TheBook.Midi => MidiIndex,
                    TheBook.Maxi => MaxiIndex,
                    _ => MiniIndex
                }
            };
            solver.Run(Boggle);
        }
    }
}