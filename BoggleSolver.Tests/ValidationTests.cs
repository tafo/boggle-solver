using System.Diagnostics;
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
        public void Validate_HashSetSolver()
        {
            var solver = new HashSetSolver {Words = TheBook.GetSet(TheBook.Test)};
            var timer = Stopwatch.StartNew();
            var result = solver.Run(TestData.Boggle);
            timer.Stop();

            _testOutput.WriteLine($"Found {result.Count} words in {timer.Elapsed}");
            result.ForEach(x => _testOutput.WriteLine(x));
            result.Count.Should().Be(TestData.Boggle.Count);
        }

        [Fact]
        public void Validate_DictionarySolver()
        {
            var solver = new DictionarySolver {Words = TheBook.GetDictionary(TheBook.Test)};
            var timer = Stopwatch.StartNew();
            var result = solver.Run(TestData.Boggle);
            timer.Stop();

            _testOutput.WriteLine($"Found {result.Count} words in {timer.Elapsed}");
            result.ForEach(x => _testOutput.WriteLine(x));
            result.Count.Should().Be(TestData.Boggle.Count);
        }
    }
}