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
        public Dictionary<char, HashSet<string>> MiniDictionary { get; set; }
        public Dictionary<char, HashSet<string>> MidiDictionary { get; set; }
        public Dictionary<char, HashSet<string>> MaxiDictionary { get; set; }

        public Dictionary<string, HashSet<string>> MiniIndex { get; set; }
        public Dictionary<string, HashSet<string>> MidiIndex { get; set; }
        public Dictionary<string, HashSet<string>> MaxiIndex { get; set; }

        [Params(TheBook.Mini, TheBook.Midi, TheBook.Maxi)]
        public string Size;

        public BoggleModel Boggle { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            MiniDictionary = TheBook.GetDictionary(TheBook.Mini);
            MidiDictionary = TheBook.GetDictionary(TheBook.Midi);
            MaxiDictionary = TheBook.GetDictionary(TheBook.Maxi);

            MiniIndex = TheBook.GetIndex(TheBook.Mini);
            MidiIndex = TheBook.GetIndex(TheBook.Midi);
            MaxiIndex = TheBook.GetIndex(TheBook.Maxi);

            var json = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Boggle.json");
            Boggle = JsonConvert.DeserializeObject<BoggleModel>(json);
        }

        [Benchmark]
        public void Dictionary()
        {
            var solver = new DictionarySolver()
            {
                WordBook = Size switch
                {
                    TheBook.Mini => MiniDictionary,
                    TheBook.Midi => MidiDictionary,
                    TheBook.Maxi => MaxiDictionary,
                    _ => MiniDictionary
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