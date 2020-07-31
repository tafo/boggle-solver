using System;
using System.Diagnostics;
using BoggleSolver.Library;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace BoggleSolver.Tests
{
    public class SolverTests : IClassFixture<TestData>
    {
        private readonly ITestOutputHelper _testOutput;
        private readonly TestData _testData;

        public SolverTests(ITestOutputHelper testOutput, TestData testData)
        {
            _testOutput = testOutput;
            _testData = testData;
        }

        [Fact]
        public void Test_TrieSolver()
        {
            var solver = new TrieSolver
            {
                RootTrie = WordBook.Maxi.GetLetterTrie()
            };

            var timer = Stopwatch.StartNew();
            Array.ForEach(_testData.Boggles, boggle => solver.Run(boggle));
            timer.Stop();

            _testOutput.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        [Fact]
        public void Test_CellSolver()
        {
            var solver = new CellSolver
            {
                RootTrie = WordBook.Maxi.GetLetterTrie()
            };

            var timer = Stopwatch.StartNew();
            Array.ForEach(_testData.Boggles, boggle => solver.Run(boggle));
            timer.Stop();

            _testOutput.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        [Fact]
        public void Check_TrieSolver()
        {
            var solver = new TrieSolver
            {
                RootTrie = WordBook.Test.GetLetterTrie()
            };

            Array.ForEach(_testData.Boggles, boggle =>
            {
                var result = solver.Run(boggle);
                _testOutput.WriteLine($"{solver.ChainCounter} chains");
                result.Words.Count.Should().Be(boggle.Count);
                result.Score.Should().Be(boggle.Score);
            });
        }

        [Fact]
        public void Check_CellSolver()
        {
            var solver = new CellSolver
            {
                RootTrie = WordBook.Test.GetLetterTrie()
            };

            Array.ForEach(_testData.Boggles, boggle =>
            {
                var result = solver.Run(boggle);
                _testOutput.WriteLine($"{solver.ChainCounter} chains");
                result.Words.Count.Should().Be(boggle.Count);
                result.Score.Should().Be(boggle.Score);
            });
        }
    }
}