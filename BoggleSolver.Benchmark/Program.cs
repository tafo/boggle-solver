using System;
using BenchmarkDotNet.Running;

namespace BoggleSolver.Benchmark
{
    public class Program
    {
        public static void Main()
        {
            Console.ReadLine();
            BenchmarkRunner.Run(typeof(SolverBenchmark));
            Console.ReadLine();
        }
    }
}