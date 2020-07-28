using System.Diagnostics;
using System.IO;
using System.Linq;
using BoggleSolver.Library;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace BoggleSolver.Tests
{
    public class SolverTest
    {
        private readonly ITestOutputHelper _testOutput;

        public SolverTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
            GetBoggles();
        }

        [Theory]
        [InlineData(3, WordBook.Maxi, MiniBoggle)]
        [InlineData(3, WordBook.Midi, MiniBoggle)]
        [InlineData(3, WordBook.Mini, MiniBoggle)]
        [InlineData(4, WordBook.Maxi, MiniBoggle)]
        [InlineData(4, WordBook.Midi, MiniBoggle)]
        [InlineData(4, WordBook.Mini, MiniBoggle)]
        public void Check_Performance(int level, string dictionarySize, string boggleSize)
        {
            var boggle = GetBoggle(boggleSize);
            var solver = new Solver { RootTrie = dictionarySize.GetTrie(level), TrieLevel = level };
            var timer = Stopwatch.StartNew();
            var result = solver.Run(boggle);
            timer.Stop();

            _testOutput.WriteLine($"Checked { solver.ChainCounter} chains");
            _testOutput.WriteLine($"Found {result.Words.Count} words in {timer.Elapsed}");
        }

        [Theory]
        [InlineData(3, TestBoggle)]
        [InlineData(3, MiniBoggle)]
        [InlineData(4, TestBoggle)]
        [InlineData(4, MiniBoggle)]
        public void Check_Result(int level, string boggleSize)
        {
            var solver = new Solver { RootTrie = WordBook.Test.GetTrie(level), TrieLevel = level };
            var boggle = GetBoggle(boggleSize);
            var timer = Stopwatch.StartNew();
            var result = solver.Run(boggle);
            timer.Stop();

            _testOutput.WriteLine($"Checked {solver.ChainCounter} chains");
            _testOutput.WriteLine($"Found {result.Words.Count} words in {timer.Elapsed}");
            result.Words.ToList().ForEach(x => _testOutput.WriteLine(x));
            result.Words.Count.Should().Be(boggle.Count);
            result.Score.Should().Be(boggle.Score);
        }

        private static BoggleModel GetBoggle(string size) =>
            size switch
            {
                TestBoggle => _boggles[0],
                MiniBoggle => _boggles[1],
                _ => _boggles[0],
            };

        private static BoggleModel[] _boggles;

        public static BoggleModel[] GetBoggles()
        {
            if (_boggles != null) return _boggles;
            var json = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Boggles.json");
            _boggles = JsonConvert.DeserializeObject<BoggleModel[]>(json);
            return _boggles;
        }

        private const string TestBoggle = "Test";
        private const string MiniBoggle = "Mini";
        private const string MidiBoggle = "Midi";
        private const string MaxiBoggle = "Maxi";
    }
}