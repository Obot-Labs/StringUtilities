using BenchmarkDotNet.Attributes;
using System.Text;

namespace StringUtilities.Benchmark
{
    public class ExtractStringBenchmark
    {
        //var benchmark = BenchmarkRunner.Run<ExtractStringBenchmark>();



        private readonly string _testDummy1 = "0123456789";
        private readonly string _testDummy2 = "012345678901234567890123456789";
        private readonly string _testDummy3 = "0123|567890123456|890123456|890123456|89";
        private readonly string _testDummy4 = "0123|56789>123456|890123456|8901<3456|89";
        private readonly string _testDummy5 = "abcdefghijabcdefghijabcdefghijabcdefghij";

        /*
        | Method                        | Mean      | Error    | StdDev   |
        |------------------------------ |----------:|---------:|---------:|
        | Benchmark_SubstringToChar     | 126.46 ns | 0.876 ns | 0.776 ns |
        | Benchmark_SubstringToChar_ALT |  32.44 ns | 0.147 ns | 0.130 ns |
        */

        public ExtractStringBenchmark()
        {
        }




        [Benchmark]
        public void GetStringAtIndexLimitedByChar()
        {
            var result01 = GetStringAtIndexLimitedByChar(_testDummy1, 0, '9');
            var result02 = GetStringAtIndexLimitedByChar(_testDummy2, 5, '9');
            var result03 = GetStringAtIndexLimitedByChar(_testDummy3, 5, '|');
            var result04 = GetStringAtIndexLimitedByChar(_testDummy4, 5, '9');
            var result05 = GetStringAtIndexLimitedByChar(_testDummy5, 5, 'i');
        }
        [Benchmark]
        public void GetStringAtIndexLimitedByChar_ALT()
        {
            var result01 = GetStringAtIndexLimitedByChar_ALT(_testDummy1, 0, '9', true);
            var result02 = GetStringAtIndexLimitedByChar_ALT(_testDummy2, 5, '9', true);
            var result03 = GetStringAtIndexLimitedByChar_ALT(_testDummy3, 5, '|', true);
            var result04 = GetStringAtIndexLimitedByChar_ALT(_testDummy4, 5, '9', true);
            var result05 = GetStringAtIndexLimitedByChar_ALT(_testDummy5, 5, 'i', true);
        }

        public string GetStringAtIndexLimitedByChar(string str, int index, char limitChar)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }
            else if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Value cannot be less than 0.");
            }
            else if (index > str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            }

            if (str[index] == limitChar)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();


            // start backwards
            for (int i = index; i > -1; i--)
            {
                if (str[i] == limitChar)
                {
                    break;
                }
                else
                {
                    stringBuilder.Append(str[i]);
                }
            }

            char[] reversed = stringBuilder.ToString().ToArray();
            Array.Reverse(reversed);

            stringBuilder.Clear();
            stringBuilder.Append(new string(reversed));


            // go forward
            for (int i = index + 1; i < str.Length; i++)
            {
                if (str[i] == limitChar)
                {
                    break;
                }
                else
                {
                    stringBuilder.Append(str[i]);
                }
            }

            return stringBuilder.ToString();
        }

        public string GetStringAtIndexLimitedByChar_ALT(string str, int index, char limitChar, bool includeChar)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }
            else if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Value cannot be less than 0.");
            }
            else if (index > str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            }

            if (str[index] == limitChar)
            {
                return includeChar ? limitChar.ToString() : string.Empty;
            }

            var previousCharIndex = str.LastIndexOf(limitChar, index);

            var previous = previousCharIndex != -1 ?
                         str.Substring((includeChar ? previousCharIndex : previousCharIndex + 1), index - (includeChar ? previousCharIndex - 1 : previousCharIndex)) :
                         str.Substring(0, index);

            var nextCharIndex = str.IndexOf(limitChar, index);

            var next = nextCharIndex != -1 ?
                 str.Substring(index + 1, nextCharIndex - (includeChar ? index : index - 1)) :
                 str.Substring(index + 1);

            return previous + next;
        }


    }
}
