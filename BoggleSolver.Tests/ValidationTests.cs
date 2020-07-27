using System.Diagnostics;
using System.Linq;
using BoggleSolver.Library;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace BoggleSolver.Tests
{
    public class ValidationTests
    {
        private readonly ITestOutputHelper _testOutput;

        public ValidationTests(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public void Validate_TrieSolver()
        {
            var solver = new TrieSolver {RootTrie = TheBook.GetTrie(TheBook.Test)};
            var timer = Stopwatch.StartNew();
            var result = solver.Run(TestData.Boggle);
            timer.Stop();

            _testOutput.WriteLine($"Checked {solver.ChainCounter} chains");
            _testOutput.WriteLine($"Found {result.Words.Count} words in {timer.Elapsed}");
            result.Words.ToList().ForEach(x => _testOutput.WriteLine(x));
            result.Words.Count.Should().Be(TestData.Boggle.Count);
            result.Score.Should().Be(TestData.Boggle.Score);
        }

        [Fact]
        public void Validate_IndexSolver()
        {
            var solver = new IndexSolver { WordBook = TheBook.GetIndex(TheBook.Test) };
            var timer = Stopwatch.StartNew();
            var result = solver.Run(TestData.Boggle);
            timer.Stop();

            _testOutput.WriteLine($"Checked {solver.ChainCounter} chains");
            _testOutput.WriteLine($"Found {result.Words.Count} words in {timer.Elapsed}");
            result.Words.ToList().ForEach(x => _testOutput.WriteLine(x));
            result.Words.Count.Should().Be(TestData.Boggle.Count);
            result.Score.Should().Be(TestData.Boggle.Score);
        }
    }
}