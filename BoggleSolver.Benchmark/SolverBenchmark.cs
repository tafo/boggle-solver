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

        public HashSet<string> MiniSet { get; set; }
        public HashSet<string> MidiSet { get; set; }
        public HashSet<string> MaxiSet { get; set; }

        [Params(TheBook.Mini, TheBook.Midi, TheBook.Maxi)]
        public string Size;

        public BoggleModel Boggle { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            MiniDictionary = TheBook.GetDictionary(TheBook.Mini);
            MidiDictionary = TheBook.GetDictionary(TheBook.Midi);
            MaxiDictionary = TheBook.GetDictionary(TheBook.Maxi);

            MiniSet = TheBook.GetSet(TheBook.Mini);
            MidiSet = TheBook.GetSet(TheBook.Midi);
            MaxiSet = TheBook.GetSet(TheBook.Maxi);

            var json = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Boggle.json");
            Boggle = JsonConvert.DeserializeObject<BoggleModel>(json);
        }

        [Benchmark]
        public void Dictionary()
        {
            var solver = new DictionarySolver
            {
                Words = Size switch
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
        public void HashSet()
        {
            var solver = new HashSetSolver
            {
                Words = Size switch
                {
                    TheBook.Mini => MiniSet,
                    TheBook.Midi => MidiSet,
                    TheBook.Maxi => MaxiSet,
                    _ => MiniSet
                }
            };
            solver.Run(Boggle);
        }
    }
}