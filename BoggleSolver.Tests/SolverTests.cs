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
    public class SolverTests
    {
        private readonly ITestOutputHelper _testOutput;
        private readonly Boggle[] _boggles;

        public SolverTests(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
            var json = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Boggles.json");
            _boggles = JsonConvert.DeserializeObject<Boggle[]>(json);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Test_TrieSolver(int boggleSize)
        {
            var boggle = _boggles[boggleSize];
            var solver = new TrieSolver
            {
                RootTrie = WordBook.Maxi.GetLetterTrie()
            };
            var timer = Stopwatch.StartNew();
            var result = solver.Run(boggle);
            timer.Stop();

            _testOutput.WriteLine($"Checked {solver.ChainCounter} chains");
            _testOutput.WriteLine($"Found {result.Words.Count} words in {timer.ElapsedTicks}");
            _testOutput.WriteLine($"Score = {result.Score}");
        }


        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Test_CellSolver(int boggleSize)
        {
            var boggle = _boggles[boggleSize];
            var solver = new CellSolver
            {
                RootTrie = WordBook.Maxi.GetLetterTrie()
            };
            var timer = Stopwatch.StartNew();
            var result = solver.Run(boggle);
            timer.Stop();

            _testOutput.WriteLine($"Checked {solver.ChainCounter} chains");
            _testOutput.WriteLine($"Found {result.Words.Count} words in {timer.ElapsedTicks}");
            _testOutput.WriteLine($"Score = {result.Score}");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Check_TrieSolver(int boggleSize)
        {
            var boggle = _boggles[boggleSize];
            var solver = new TrieSolver
            {
                RootTrie = WordBook.Test.GetLetterTrie()
            };
            var timer = Stopwatch.StartNew();
            var result = solver.Run(boggle);
            timer.Stop();

            _testOutput.WriteLine($"Checked {solver.ChainCounter} chains");
            _testOutput.WriteLine($"Found {result.Words.Count} words in {timer.ElapsedTicks}");
            result.Words.ToList().ForEach(x => _testOutput.WriteLine(x));
            result.Words.Count.Should().Be(boggle.Count);
            result.Score.Should().Be(boggle.Score);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Check_CellSolver(int boggleSize)
        {
            var boggle = _boggles[boggleSize];
            var solver = new CellSolver
            {
                RootTrie = WordBook.Test.GetLetterTrie()
            };
            var timer = Stopwatch.StartNew();
            var result = solver.Run(boggle);
            timer.Stop();

            _testOutput.WriteLine($"Checked {solver.ChainCounter} chains");
            _testOutput.WriteLine($"Found {result.Words.Count} words in {timer.ElapsedTicks}");
            result.Words.ToList().ForEach(x => _testOutput.WriteLine(x));
            result.Words.Count.Should().Be(boggle.Count);
            result.Score.Should().Be(boggle.Score);
        }
    }
}