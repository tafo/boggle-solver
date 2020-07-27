using System.Diagnostics;
using BoggleSolver.Library;
using Xunit;
using Xunit.Abstractions;

namespace BoggleSolver.Tests
{
    public class PerformanceTests
    {
        private readonly ITestOutputHelper _testOutput;

        public PerformanceTests(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Theory]
        [InlineData(TheBook.Mini)]
        [InlineData(TheBook.Midi)]
        [InlineData(TheBook.Maxi)]
        public void Validate_TrieSolver(string size)
        {
            var solver = new TrieSolver { RootTrie = TheBook.GetTrie(size) };
            var timer = Stopwatch.StartNew();
            var result = solver.Run(TestData.Boggle);
            timer.Stop();

            _testOutput.WriteLine($"Checked {solver.ChainCounter} chains");
            _testOutput.WriteLine($"Found {result.Words.Count} words in {timer.Elapsed}");
        }

        [Theory]
        [InlineData(TheBook.Mini)]
        [InlineData(TheBook.Midi)]
        [InlineData(TheBook.Maxi)]
        public void Test_IndexSolver(string size)
        {
            var solver = new IndexSolver { WordBook = TheBook.GetIndex(size) };
            var timer = Stopwatch.StartNew();
            var result = solver.Run(TestData.Boggle);
            timer.Stop();

            _testOutput.WriteLine($"Found {result.Words.Count} words in {timer.Elapsed}");
            _testOutput.WriteLine($"Checked {solver.ChainCounter} chains");
        }
    }
}