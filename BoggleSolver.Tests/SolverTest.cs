using System.Collections.Generic;
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
        }

        [Theory]
        [MemberData(nameof(PerformanceData))]
        public void Check_Performance(string size, int level)
        {
            LetterTrie.Level = level;
            var solver = new Solver(size);
            var timer = Stopwatch.StartNew();
            var result = solver.Run(Boggle);
            timer.Stop();

            _testOutput.WriteLine($"Checked {solver.ChainCounter} chains");
            _testOutput.WriteLine($"Found {result.Words.Count} words in {timer.Elapsed}");
        }

        [Theory]
        [MemberData(nameof(ResultData))]
        public void Check_Result(string size, int level)
        {
            LetterTrie.Level = level;
            var solver = new Solver(size);
            var timer = Stopwatch.StartNew();
            var result = solver.Run(Boggle);
            timer.Stop();

            _testOutput.WriteLine($"Checked {solver.ChainCounter} chains");
            _testOutput.WriteLine($"Found {result.Words.Count} words in {timer.Elapsed}");
            result.Words.ToList().ForEach(x => _testOutput.WriteLine(x));
            result.Words.Count.Should().Be(Boggle.Count);
            result.Score.Should().Be(Boggle.Score);
        }

        public static IEnumerable<object[]> ResultData
            => new[]
            {
                new object[] {WordBook.Test, 1},
                new object[] {WordBook.Test, 2},
                new object[] {WordBook.Test, 3},
            };

        public static IEnumerable<object[]> PerformanceData
            => new[]
            {
                new object[] {WordBook.Mini, 1},
                new object[] {WordBook.Mini, 2},
                new object[] {WordBook.Mini, 3},
                new object[] {WordBook.Midi, 1},
                new object[] {WordBook.Midi, 2},
                new object[] {WordBook.Midi, 3},
                new object[] {WordBook.Maxi, 1},
                new object[] {WordBook.Maxi, 2},
                new object[] {WordBook.Maxi, 3},
            };

        private static BoggleModel _boggle;
        public static BoggleModel Boggle
        {
            get
            {
                if (_boggle != null) return _boggle;
                var json = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Boggle.json");
                _boggle = JsonConvert.DeserializeObject<BoggleModel>(json);
                return _boggle;
            }
        }
    }
}