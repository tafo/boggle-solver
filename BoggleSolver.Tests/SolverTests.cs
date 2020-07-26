using System.Diagnostics;
using BoggleSolver.Library;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace BoggleSolver.Tests
{
    public class SolverTests
    {
        private readonly ITestOutputHelper _testOutput;

        public SolverTests(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public void Test_SlowSolver()
        {
            var solver = new SlowSolver { Words = Size.Test.ToArray() };
            var timer = Stopwatch.StartNew();
            var result = solver.Run(TestData.Boggle);
            timer.Stop();

            _testOutput.WriteLine($"Found {result.Count} words in {timer.Elapsed}");
            result.ForEach(x => _testOutput.WriteLine(x));
            result.Count.Should().Be(TestData.Boggle.Count);
        }

        [Fact]
        public void Test_BinarySolver()
        {
            var solver = new BinarySolver { Words = Size.Test.ToArray() };
            var timer = Stopwatch.StartNew();
            var result = solver.Run(TestData.Boggle);
            timer.Stop();

            _testOutput.WriteLine($"Found {result.Count} words in {timer.Elapsed}");
            result.ForEach(x => _testOutput.WriteLine(x));
            result.Count.Should().Be(TestData.Boggle.Count);
        }
    }
}