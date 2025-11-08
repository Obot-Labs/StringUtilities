using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using StringUtilities.Core.IndexOfExpanded;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringUtilities.Benchmark
{
    public class IndexByOccurrenceBenchmark
    {

        /*
            | Method                              | Mean         | Error     | StdDev    |
            |------------------------------------ |-------------:|----------:|----------:|
            | Benchmark_IndexOfByOccurrencef      |    132.82 ns |  0.930 ns |  0.824 ns |
            | Benchmark_IndexOfByOccurrencef_ALT  |     55.25 ns |  0.204 ns |  0.191 ns |
         

        private readonly IndexOfOccurrence indexOfOccurrence = new IndexOfOccurrence();

        private readonly string _testDummy1 = "0123456789";
        private readonly string _testDummy2 = "012345678901234567890123456789";
        private readonly string _testDummy3 = "0123|567890123456|890123456|890123456|89";
        private readonly string _testDummy4 = "0123|56789>123456|890123456|8901<3456|89";
        private readonly string _testDummy5 = "abcdefghijabcdefghijabcdefghijabcdefghij";


        [Benchmark]
        public void Benchmark_IndexOfByOccurrencef()
        {
            var result01 = indexOfOccurrence.IndexOfByOccurrence(_testDummy1, '0', 1, 0, false);
            var result02 = indexOfOccurrence.IndexOfByOccurrence(_testDummy2, '0', 1, 0, false);
            var result03 = indexOfOccurrence.IndexOfByOccurrence(_testDummy3, '0', 1, 0, false);
            var result04 = indexOfOccurrence.IndexOfByOccurrence(_testDummy4, '0', 1, 0, false);
            var result05 = indexOfOccurrence.IndexOfByOccurrence(_testDummy5, 'g', 4, 0, false);
            var result06 = indexOfOccurrence.IndexOfByOccurrence(_testDummy1, '0', 1, _testDummy1.Length - 1, true);
            var result07 = indexOfOccurrence.IndexOfByOccurrence(_testDummy2, '0', 1, _testDummy2.Length - 1, true);
            var result08 = indexOfOccurrence.IndexOfByOccurrence(_testDummy3, '0', 1, _testDummy3.Length - 1, true);
            var result09 = indexOfOccurrence.IndexOfByOccurrence(_testDummy4, '0', 1, _testDummy4.Length - 1, true);
            var result10 = indexOfOccurrence.IndexOfByOccurrence(_testDummy5, 'g', 4, _testDummy5.Length - 1, true);
        }
        [Benchmark]
        public void Benchmark_IndexOfByOccurrencef_ALT2()
        {
            var result01 = indexOfOccurrence.IndexOfByOccurrence_ALT(_testDummy1, '0', 1, 0, false);
            var result02 = indexOfOccurrence.IndexOfByOccurrence_ALT(_testDummy2, '0', 1, 0, false);
            var result03 = indexOfOccurrence.IndexOfByOccurrence_ALT(_testDummy3, '0', 1, 0, false);
            var result04 = indexOfOccurrence.IndexOfByOccurrence_ALT(_testDummy4, '0', 1, 0, false);
            var result05 = indexOfOccurrence.IndexOfByOccurrence_ALT(_testDummy5, 'g', 4, 0, false);
            var result06 = indexOfOccurrence.IndexOfByOccurrence_ALT(_testDummy1, '0', 1, _testDummy1.Length - 1, true);
            var result07 = indexOfOccurrence.IndexOfByOccurrence_ALT(_testDummy2, '0', 1, _testDummy2.Length - 1, true);
            var result08 = indexOfOccurrence.IndexOfByOccurrence_ALT(_testDummy3, '0', 1, _testDummy3.Length - 1, true);
            var result09 = indexOfOccurrence.IndexOfByOccurrence_ALT(_testDummy4, '0', 1, _testDummy4.Length - 1, true);
            var result10 = indexOfOccurrence.IndexOfByOccurrence_ALT(_testDummy5, 'g', 4, _testDummy5.Length - 1, true);

        }
        */


    }
}
