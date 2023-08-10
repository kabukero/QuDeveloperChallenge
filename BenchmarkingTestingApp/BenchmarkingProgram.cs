using BenchmarkDotNet.Attributes;
using Domain.Contracts;
using Domain.Models;

namespace BenchmarkingTestingApp
{
    [MemoryDiagnoser]
    public class BenchmarkingProgram
    {
        const int n = 1_000_000;
        IList<string> matrix = new List<string>();
        IList<string> wordStream = new List<string>();

        [GlobalSetup]
        public void GlobalSetup()
        {
            var rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                matrix.Add("hello " + rnd.Next(50, 100));
                wordStream.Add("hello " + rnd.Next(25, 75));
            }
        }

        [Benchmark]
        public void TestWordFinderPerformance()
        {
            IWordFinder wordFinder = new WordFinder(matrix);
            wordFinder.Find(wordStream);
        }
    }
}
