using BenchmarkDotNet.Running;
using StringUtilities.Benchmark;
using StringUtilities.Core.SubstringExpanded;
using StringUtilities.Core.RemoveExpanded;
using System;
using StringUtilities.Core.ReplaceExpanded;
using StringUtilities.Core.Html;
using Microsoft.Diagnostics.Tracing.Parsers.FrameworkEventSource;

namespace StringUtilities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var testSU = new TestStringUtils();
            var testSUhtml = new StuffHtml();

            var blala = "<img            /><br/><br />";

            var bla = testSUhtml.NormalizeSelfClosingTags(blala);

            Console.WriteLine(bla);


        }


    }
}
