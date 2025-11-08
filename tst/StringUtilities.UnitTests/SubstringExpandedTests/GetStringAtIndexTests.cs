using StringUtilities.Core.SubstringExpanded;
using Xunit;

namespace StringUtilities.UnitTests.SubstringExpandedTests
{
    public partial class SubstringExpTests
    {
        public static IEnumerable<object[]> TestData_GetStringAtIndexLimitedByChar_Char()
        {
            //   1      8   12     19
            // "0|234567|9 0|234567|9"
            yield return new object[] { "|234567|", "0|234567|9 0|234567|9", 5, '|', true };
            yield return new object[] { "234567", "0|234567|9 0|234567|9", 5, '|', false };
            yield return new object[] { "01234|", "01234|6789", 2, '|', true };
            yield return new object[] { "01234", "01234|6789", 2, '|', false };
            yield return new object[] { "|6789", "01234|6789", 7, '|', true };
            yield return new object[] { "6789", "01234|6789", 7, '|', false };
            yield return new object[] { "|", "01234|6789", 5, '|', true };
            yield return new object[] { "", "01234|6789", 5, '|', false };
            yield return new object[] { "|6|", "01234|6|89", 6, '|', true };
            yield return new object[] { "6", "01234|6|89", 6, '|', false };
            yield return new object[] { "|67|", "01234|67|89", 6, '|', true };
            yield return new object[] { "67", "01234|67|89", 6, '|', false };
            yield return new object[] { "|67|", "01234|67|89", 7, '|', true };
            yield return new object[] { "67", "01234|67|9", 7, '|', false };
            yield return new object[] { "0|", "0|23456789", 0, '|', true };
            yield return new object[] { "0", "0|23456789", 0, '|', false };
            yield return new object[] { "|9", "0|234567|9", 9, '|', true };
            yield return new object[] { "9", "0|234567|9", 9, '|', false };
            yield return new object[] { "0123456789", "0123456789", 5, '|', true };
            yield return new object[] { "0123456789", "0123456789", 5, '|', false };
        }
        [Theory]
        [MemberData(nameof(TestData_GetStringAtIndexLimitedByChar_Char))]
        public void GetStringAtIndexLimitedByChar_Char_Tests(object expected, string str, int index, char limitChar, bool includeChar)
        {
            var sut = new SubstringExp();
            var result = sut.GetStringAtIndexLimitedByChar(str, index, limitChar, includeChar);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_GetStringAtIndexLimitedByChar_CharArray()
        {
            yield return new object[] { "|3456<", "aaa0<|3456<|9bbb", 8, new char[] { '|', '<' }, true };
            yield return new object[] { "3456", "aaa0<|3456<|9bbb", 8, new char[] { '|', '<' }, false };
            yield return new object[] { "012345|", "012345|<89", 3, new char[] { '|', '<' }, true };
            yield return new object[] { "012345", "012345|<89", 3, new char[] { '|', '<' }, false };
            yield return new object[] { "<3456789", "0|<3456789", 6, new char[] { '|', '<' }, true };
            yield return new object[] { "3456789", "0|<3456789", 6, new char[] { '|', '<' }, false };
            yield return new object[] { "<", "01234|<789", 6, new char[] { '|', '<' }, true };
            yield return new object[] { "", "01234|<789", 6, new char[] { '|', '<' }, false };
            yield return new object[] { "|5<", "0123|5<789", 5, new char[] { '|', '<' }, true };
            yield return new object[] { "5", "0123|5<789", 5, new char[] { '|', '<' }, false };
            yield return new object[] { "0|", "0|234567<9", 0, new char[] { '|', '<' }, true };
            yield return new object[] { "0", "0|234567<9", 0, new char[] { '|', '<' }, false };
            yield return new object[] { "<9", "0|234567<9", 9, new char[] { '|', '<' }, true };
            yield return new object[] { "9", "0|234567<9", 9, new char[] { '|', '<' }, false };
            yield return new object[] { "0123456789", "0123456789", 4, new char[] { '|', '<' }, false };
        }
        [Theory]
        [MemberData(nameof(TestData_GetStringAtIndexLimitedByChar_CharArray))]
        public void GetStringAtIndexLimitedByChar_CharArray_Tests(object expected, string str, int index, char[] limitChars, bool includeChar)
        {
            var sut = new SubstringExp();
            var result = sut.GetStringAtIndexLimitedByChar(str, index, limitChars, includeChar);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_GetStringAtIndexLimitedByChar_CharOffset()
        {
            yield return new object[] { "|9 0|", "0|234567|9 0|234567|9", 5, '|', true, 1, false };
            yield return new object[] { "9 0", "0|234567|9 0|234567|9", 5, '|', false, 1, false };
            yield return new object[] { "|234567|", "0|234567|9 0|234567|9", 5, '|', true, 2, false };
            yield return new object[] { "234567", "0|234567|9 0|234567|9", 5, '|', false, 2, false };
            yield return new object[] { "|9 0|", "0|234567|9 0|234567|9", 16, '|', true, 1, true };
            yield return new object[] { "9 0", "0|234567|9 0|234567|9", 16, '|', false, 1, true };
            yield return new object[] { "|6789", "01234|6789", 5, '|', true, 1, false };
            yield return new object[] { "6789", "01234|6789", 5, '|', false, 1, false };
            yield return new object[] { "01234|", "01234|6789", 5, '|', true, 1, true };
            yield return new object[] { "01234", "01234|6789", 5, '|', false, 1, true };
            yield return new object[] { "|234567|", "0|234567|9", 5, '|', true, 0, true };
            yield return new object[] { "234567", "0|234567|9", 5, '|', false, 0, true };
            yield return new object[] { "|", "01234|6789", 5, '|', true, 0, false };
            yield return new object[] { "", "01234|6789", 5, '|', false, 0, false };
            yield return new object[] { "||", "01234||789", 5, '|', true, 1, false };
            yield return new object[] { "", "01234||789", 5, '|', false, 1, false };
            yield return new object[] { "||", "0123||6789", 5, '|', true, 1, true };
            yield return new object[] { "", "0123||6789", 5, '|', false, 1, true };
            yield return new object[] { "|789", "01234||789", 5, '|', true, 2, false };
            yield return new object[] { "789", "01234||789", 5, '|', false, 2, false };
            yield return new object[] { "0123|", "0123||6789", 5, '|', true, 2, true };
            yield return new object[] { "0123", "0123||6789", 5, '|', false, 2, true };
            yield return new object[] { "0|", "0|23456789", 0, '|', true, 0, true };
            yield return new object[] { "0", "0|23456789", 0, '|', false, 0, true };
            yield return new object[] { "|9", "01234567|9", 9, '|', true, 0, false };
            yield return new object[] { "9", "01234567|9", 9, '|', false, 0, false };
            yield return new object[] { "", "0|23456789", 0, '|', true, 1, true };
            yield return new object[] { "", "0|23456789", 0, '|', false, 1, true };
            yield return new object[] { "", "01234567|9", 9, '|', true, 1, false };
            yield return new object[] { "", "01234567|9", 9, '|', false, 1, false };
            yield return new object[] { "", "0123|56789", 4, '|', true, 2, false };
            yield return new object[] { "", "0123|56789", 4, '|', false, 2, false };
            yield return new object[] { "", "0123|56789", 4, '|', true, 2, true };
            yield return new object[] { "", "0123|56789", 4, '|', false, 2, true };
        }
        [Theory]
        [MemberData(nameof(TestData_GetStringAtIndexLimitedByChar_CharOffset))]
        public void GetStringAtIndexLimitedByChar_CharOffset_Tests(object expected, string str, int index, char limitChar, bool includeChar, int offset, bool backwards)
        {
            var sut = new SubstringExp();
            var result = sut.GetStringAtIndexLimitedByChar(str, index, limitChar, includeChar, offset, backwards);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_GetStringAtIndexLimitedByChar_CharArrayOffset()
        {
            yield return new object[] { "<9 0|", "0|234567<9 0|234567<9", 5, new char[] { '|', '<' }, true, 1, false };
            yield return new object[] { "9 0", "0|234567<9 0|234567<9", 5, new char[] { '|', '<' }, false, 1, false };
            yield return new object[] { "|234567<", "0|234567<9 0|234567<9", 5, new char[] { '|', '<' }, true, 2, false };
            yield return new object[] { "234567", "0|234567<9 0|234567<9", 5, new char[] { '|', '<' }, false, 2, false };
            yield return new object[] { "<9", "0|234567<9 0|234567<9", 5, new char[] { '|', '<' }, true, 3, false };
            yield return new object[] { "9", "0|234567<9 0|234567<9", 5, new char[] { '|', '<' }, false, 3, false };
            yield return new object[] { "<9 0|", "0|234567<9 0|234567<9", 16, new char[] { '|', '<' }, true, 1, true };
            yield return new object[] { "9 0", "0|234567<9 0|234567<9", 16, new char[] { '|', '<' }, false, 1, true };
            yield return new object[] { "|234567<", "0|234567<9 0|234567<9", 16, new char[] { '|', '<' }, true, 2, true };
            yield return new object[] { "234567", "0|234567<9 0|234567<9", 16, new char[] { '|', '<' }, false, 2, true };
            yield return new object[] { "0|", "0|234567<9 0|234567<9", 16, new char[] { '|', '<' }, true, 3, true };
            yield return new object[] { "0", "0|234567<9 0|234567<9", 16, new char[] { '|', '<' }, false, 3, true };
            yield return new object[] { "<56789", "0123<56789", 4, new char[] { '|', '<' }, true, 1, false };
            yield return new object[] { "56789", "0123<56789", 4, new char[] { '|', '<' }, false, 1, false };
            yield return new object[] { "", "0123<56789", 4, new char[] { '|', '<' }, true, 2, false };
            yield return new object[] { "", "0123<56789", 4, new char[] { '|', '<' }, false, 2, false };
            yield return new object[] { "0123<", "0123<56789", 4, new char[] { '|', '<' }, true, 1, true };
            yield return new object[] { "0123", "0123<56789", 4, new char[] { '|', '<' }, false, 1, true };
            yield return new object[] { "", "0123<56789", 4, new char[] { '|', '<' }, true, 2, true };
            yield return new object[] { "", "0123<56789", 4, new char[] { '|', '<' }, false, 2, true };
            yield return new object[] { "<", "0123<56789", 4, new char[] { '|', '<' }, true, 0, false };
            yield return new object[] { "", "0123<56789", 4, new char[] { '|', '<' }, false, 0, false };
            yield return new object[] { "<", "0123<56789", 4, new char[] { '|', '<' }, true, 0, true };
            yield return new object[] { "", "0123<56789", 4, new char[] { '|', '<' }, false, 0, true };
            yield return new object[] { "<5|", "0123<5|789", 5, new char[] { '|', '<' }, true, 0, false };
            yield return new object[] { "5", "0123<5|789", 5, new char[] { '|', '<' }, false, 0, false };
            yield return new object[] { "<5|", "0123<5|789", 5, new char[] { '|', '<' }, true, 0, true };
            yield return new object[] { "5", "0123<5|789", 5, new char[] { '|', '<' }, false, 0, true };
            yield return new object[] { "<|", "01234<|789", 5, new char[] { '|', '<' }, true, 1, false };
            yield return new object[] { "", "01234<|789", 5, new char[] { '|', '<' }, false, 1, false };
            yield return new object[] { "<|", "0123<|6789", 5, new char[] { '|', '<' }, true, 1, true };
            yield return new object[] { "", "0123<|6789", 5, new char[] { '|', '<' }, false, 1, true };
        }
        [Theory]
        [MemberData(nameof(TestData_GetStringAtIndexLimitedByChar_CharArrayOffset))]
        public void GetStringAtIndexLimitedByChar_CharArrayOffset_Tests(object expected, string str, int index, char[] limitChars, bool includeChar, int offset, bool backwards)
        {
            var sut = new SubstringExp();
            var result = sut.GetStringAtIndexLimitedByChar(str, index, limitChars, includeChar, offset, backwards);
            Assert.Equal(expected, result);
        }



    }
}
