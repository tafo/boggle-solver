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
        [InlineData(TestBoggle)]
        [InlineData(MiniBoggle)]
        [InlineData(MidiBoggle)]
        [InlineData(MaxiBoggle)]
        public void Check_Performance(string boggleSize)
        {
            var boggle = GetBoggle(boggleSize);
            var solver = new Solver { RootTrie = WordBook.Maxi.GetTrie() };
            var timer = Stopwatch.StartNew();
            var result = solver.Run(boggle);
            timer.Stop();

            _testOutput.WriteLine($"Checked {solver.ChainCounter} chains");
            _testOutput.WriteLine($"Found {result.Words.Count} words in {timer.Elapsed}");
        }

        [Theory]
        [InlineData(TestBoggle)]
        [InlineData(MiniBoggle)]
        [InlineData(MidiBoggle)]
        [InlineData(MaxiBoggle)]
        public void Check_Result(string boggleSize)
        {
            var solver = new Solver { RootTrie = WordBook.Test.GetTrie() };
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

        private static BoggleModel GetBoggle(string size) => size switch
        {
            TestBoggle => _boggles[0],
            MiniBoggle => _boggles[1],
            MidiBoggle => _boggles[2],
            MaxiBoggle => _boggles[3],
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