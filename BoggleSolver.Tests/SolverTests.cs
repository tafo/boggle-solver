using System;
using System.Diagnostics;
using System.Linq;
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
            var results = _testData.Boggles.ToDictionary(boggle => boggle,
                boggle => solver.Run(boggle).SetChainCounter(solver.ChainCounter));
            timer.Stop();

            _testOutput.WriteLine($"Duration = {timer.ElapsedTicks}");
            _testOutput.WriteLine(Environment.NewLine);
            foreach (var (boggle, result) in results)
            {
                _testOutput.WriteLine($"{boggle}");
                _testOutput.WriteLine($"Checked {result.ChainCounter} chains");
            }
        }

        [Fact]
        public void Test_CellSolver()
        {
            var solver = new CellSolver
            {
                RootTrie = WordBook.Maxi.GetLetterTrie()
            };

            var timer = Stopwatch.StartNew();
            var results = _testData.Boggles.ToDictionary(boggle => boggle,
                boggle => solver.Run(boggle).SetChainCounter(solver.ChainCounter));
            timer.Stop();

            _testOutput.WriteLine($"Duration = {timer.ElapsedTicks}");
            _testOutput.WriteLine(Environment.NewLine);
            foreach (var (boggle, result) in results)
            {
                _testOutput.WriteLine($"{boggle}");
                _testOutput.WriteLine($"Checked {result.ChainCounter} chains");
            }
        }

        [Fact]
        public void Check_TrieSolver()
        {
            var solver = new TrieSolver
            {
                RootTrie = WordBook.Test.GetLetterTrie()
            };
            var timer = Stopwatch.StartNew();
            var results = _testData.Boggles.ToDictionary(boggle => boggle,
                boggle => solver.Run(boggle).SetChainCounter(solver.ChainCounter));
            timer.Stop();

            _testOutput.WriteLine($"Duration = {timer.ElapsedTicks}");
            _testOutput.WriteLine(Environment.NewLine);
            foreach (var (boggle, result) in results)
            {
                _testOutput.WriteLine($"{boggle}");
                _testOutput.WriteLine($"Checked {result.ChainCounter} chains");
                _testOutput.WriteLine($"Score = {result.Score}");
                result.Words.Count.Should().Be(boggle.Count);
                result.Score.Should().Be(boggle.Score);
            }
        }

        [Fact]
        public void Check_CellSolver()
        {
            var solver = new CellSolver
            {
                RootTrie = WordBook.Test.GetLetterTrie()
            };
            var timer = Stopwatch.StartNew();
            var results = _testData.Boggles.ToDictionary(boggle => boggle,
                boggle => solver.Run(boggle).SetChainCounter(solver.ChainCounter));
            timer.Stop();

            _testOutput.WriteLine($"Duration = {timer.ElapsedTicks}");
            _testOutput.WriteLine(Environment.NewLine);
            foreach (var (boggle, result) in results)
            {
                _testOutput.WriteLine($"{boggle}");
                _testOutput.WriteLine($"Checked {result.ChainCounter} chains");
                _testOutput.WriteLine($"Score = {result.Score}");
                result.Words.Count.Should().Be(boggle.Count);
                result.Score.Should().Be(boggle.Score);
            }
        }
    }
}