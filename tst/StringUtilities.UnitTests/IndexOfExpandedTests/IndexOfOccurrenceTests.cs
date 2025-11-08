using StringUtilities.Core.IndexOfExpanded;
using Xunit;

namespace StringUtilities.UnitTests.IndexOfExpandedTests
{
    public partial class IndexOfExpandedTests
    {

        public static IEnumerable<object[]> TestData_IndexOfOccurrence_CharBackwardsCount()
        {
            yield return new object[] { 0, "0123456789 0123456789 0123456789", '0', 1, 0, false, 32 };
            yield return new object[] { 11, "0123456789 0123456789 0123456789", '0', 2, 0, false, 32 };
            yield return new object[] { 22, "0123456789 0123456789 0123456789", '0', 3, 0, false, 32 };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", '0', 4, 0, false, 32 };
            yield return new object[] { 22, "0123456789 0123456789 0123456789", '0', 1, 31, true, 32 };
            yield return new object[] { 11, "0123456789 0123456789 0123456789", '0', 2, 31, true, 32 };
            yield return new object[] { 0, "0123456789 0123456789 0123456789", '0', 3, 31, true, 32 };
            yield return new object[] { 22, "0123456789 0123456789 0123456789", '0', 1, 22, true, 9 };
            yield return new object[] { 11, "0123456789 0123456789 0123456789", '0', 1, 21, true, 11 };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", 'a', 1, 0, false, 31 };
            yield return new object[] { 31, "0123456789 0123456789 0123456789", '9', 3, 0, false, 32 };
            yield return new object[] { 31, "0123456789 0123456789 0123456789", '9', 1, 31, false, 1 };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", '9', 2, 31, false, 1 };
            yield return new object[] { 31, "0123456789 0123456789 0123456789", '9', 3, 0, false, 32 };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", '9', 3, 0, false, 31 };
        }
        [Theory]
        [MemberData(nameof(TestData_IndexOfOccurrence_CharBackwardsCount))]
        public void IndexOfOccurrence_CharBackwardsCount_Tests(object expected, string str, char value, int occurrence, int startIndex, bool backwards, int count)
        {
            var sut = new IndexOfExp();
            var result = sut.IndexOfOccurrence(str, value, occurrence, startIndex, backwards, count);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_IndexOfOccurrence_CharBackwards()
        {
            yield return new object[] { 0, "0123456789 0123456789 0123456789", '0', 1, 0, false };
            yield return new object[] { 11, "0123456789 0123456789 0123456789", '0', 2, 0, false };
            yield return new object[] { 22, "0123456789 0123456789 0123456789", '0', 3, 0, false };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", '0', 4, 0, false };
            yield return new object[] { 22, "0123456789 0123456789 0123456789", '0', 1, 31, true };
            yield return new object[] { 11, "0123456789 0123456789 0123456789", '0', 2, 31, true };
            yield return new object[] { 0, "0123456789 0123456789 0123456789", '0', 3, 31, true };
            yield return new object[] { 22, "0123456789 0123456789 0123456789", '0', 1, 22, true };
            yield return new object[] { 11, "0123456789 0123456789 0123456789", '0', 1, 21, true };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", 'a', 1, 0, false };
            yield return new object[] { 31, "0123456789 0123456789 0123456789", '9', 3, 0, false };
            yield return new object[] { 31, "0123456789 0123456789 0123456789", '9', 1, 31, false };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", '9', 2, 31, false };
        }
        [Theory]
        [MemberData(nameof(TestData_IndexOfOccurrence_CharBackwards))]
        public void IndexOfOccurrence_CharBackwards_Tests(object expected, string str, char value, int occurrence, int startIndex, bool backwards)
        {
            var sut = new IndexOfExp();
            var result = sut.IndexOfOccurrence(str, value, occurrence, startIndex, backwards);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_IndexOfOccurrence_CharEndIndex()
        {
            yield return new object[] { 0, "0123456789 0123456789 0123456789", '0', 1, 0, 31 };
            yield return new object[] { 11, "0123456789 0123456789 0123456789", '0', 2, 0, 31 };
            yield return new object[] { 22, "0123456789 0123456789 0123456789", '0', 3, 0, 31 };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", '0', 4, 0, 31 };
            yield return new object[] { 11, "0123456789 0123456789 0123456789", '0', 1, 5, 31 };
            yield return new object[] { 11, "0123456789 0123456789 0123456789", '0', 1, 11, 31 };
            yield return new object[] { 22, "0123456789 0123456789 0123456789", '0', 1, 15, 31 };
            yield return new object[] { 22, "0123456789 0123456789 0123456789", '0', 1, 22, 22 };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", '0', 3, 0, 20 };
            yield return new object[] { 31, "0123456789 0123456789 0123456789", '9', 3, 0, 31 };
            yield return new object[] { 31, "0123456789 0123456789 0123456789", '9', 1, 22, 31 };
            yield return new object[] { 0, "0123456789 0123456789 0123456789", '0', 1, 0, 0 };
        }
        [Theory]
        [MemberData(nameof(TestData_IndexOfOccurrence_CharEndIndex))]
        public void IndexOfOccurrence_CharEndIndex_Tests(object expected, string str, char value, int occurrence, int startIndex, int endIndex)
        {
            var sut = new IndexOfExp();
            var result = sut.IndexOfOccurrence(str, value, occurrence, startIndex, endIndex);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_IndexOfOccurrence_CharArrayBackwardsCount()
        {
            yield return new object[] { -1, "0123456789 0123456789 0123456789", new char[] { 'a' }, 1, 0, false, 32 };
            yield return new object[] { 0, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 0, false, 32 };
            yield return new object[] { 11, "0123456789 0123456789 0123456789", new char[] { '0' }, 2, 0, false, 32 };
            yield return new object[] { 22, "0123456789 0123456789 0123456789", new char[] { '0' }, 3, 0, false, 32 };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", new char[] { '0' }, 4, 0, false, 32 };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 25, false, 7 };
            yield return new object[] { 0, "0123456789 0123456789 0123456789", new char[] { '0', '1' }, 1, 0, false, 32 };
            yield return new object[] { 1, "0123456789 0123456789 0123456789", new char[] { '0', '1' }, 2, 0, false, 32 };
            yield return new object[] { 11, "0123456789 0123456789 0123456789", new char[] { '0', '1' }, 3, 0, false, 32 };
            yield return new object[] { 0, "0123456789 0123456789 0123456789", new char[] { '0', '1', '2' }, 1, 0, false, 32 };
            yield return new object[] { 1, "0123456789 0123456789 0123456789", new char[] { '0', '1', '2' }, 2, 0, false, 32 };
            yield return new object[] { 2, "0123456789 0123456789 0123456789", new char[] { '0', '1', '2' }, 3, 0, false, 32 };
            yield return new object[] { 11, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 11, false, 21 };
            yield return new object[] { 22, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 15, false, 17 };
            yield return new object[] { 22, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 22, false, 10 };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 30, false, 2 };
            yield return new object[] { 11, "0123456789 0123456789 0123456789", new char[] { '0', '1', '2' }, 1, 11, false, 21 };
            yield return new object[] { 12, "0123456789 0123456789 0123456789", new char[] { '0', '1', '2' }, 2, 11, false, 21 };
            yield return new object[] { 13, "0123456789 0123456789 0123456789", new char[] { '0', '1', '2' }, 3, 11, false, 21 };
            yield return new object[] { 22, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 31, true, 32 };
            yield return new object[] { 22, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 22, true, 23 };
            yield return new object[] { 0, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 0, true, 1 };
            yield return new object[] { 2, "0123456789 0123456789 0123456789", new char[] { '0', '1', '2' }, 1, 10, true, 11 };
            yield return new object[] { 1, "0123456789 0123456789 0123456789", new char[] { '0', '1', '2' }, 2, 10, true, 11 };
            yield return new object[] { 0, "0123456789 0123456789 0123456789", new char[] { '0', '1', '2' }, 3, 10, true, 11 };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", new char[] { '0', '1', '2' }, 4, 10, true, 11 };
            yield return new object[] { 31, "0123456789 0123456789 0123456789", new char[] { '9' }, 1, 31, true, 32 };
            yield return new object[] { 31, "0123456789 0123456789 0123456789", new char[] { '8', '9' }, 2, 30, false, 2 };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", new char[] { '8', '9' }, 3, 31, false, 1 };
            yield return new object[] { 31, "0123456789 0123456789 0123456789", new char[] { '9' }, 3, 0, false, 32 };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", new char[] { '9' }, 3, 0, false, 31 };
        }
        [Theory]
        [MemberData(nameof(TestData_IndexOfOccurrence_CharArrayBackwardsCount))]
        public void IndexOfOccurrence_CharArrayBackwardsCount_Tests(object expected, string str, char[] values, int occurrence, int startIndex, bool backwards, int count)
        {
            var sut = new IndexOfExp();
            var result = sut.IndexOfOccurrence(str, values, occurrence, startIndex, backwards, count);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_IndexOfOccurrence_CharArrayBackwards()
        {
            yield return new object[] { -1, "0123456789 0123456789 0123456789", new char[] { 'a' }, 1, 0, false };
            yield return new object[] { 0, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 0, false };
            yield return new object[] { 11, "0123456789 0123456789 0123456789", new char[] { '0' }, 2, 0, false };
            yield return new object[] { 22, "0123456789 0123456789 0123456789", new char[] { '0' }, 3, 0, false };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", new char[] { '0' }, 4, 0, false };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 25, false };
            yield return new object[] { 0, "0123456789 0123456789 0123456789", new char[] { '0', '1' }, 1, 0, false };
            yield return new object[] { 1, "0123456789 0123456789 0123456789", new char[] { '0', '1' }, 2, 0, false };
            yield return new object[] { 11, "0123456789 0123456789 0123456789", new char[] { '0', '1' }, 3, 0, false };
            yield return new object[] { 0, "0123456789 0123456789 0123456789", new char[] { '0', '1', '2' }, 1, 0, false };
            yield return new object[] { 1, "0123456789 0123456789 0123456789", new char[] { '0', '1', '2' }, 2, 0, false };
            yield return new object[] { 2, "0123456789 0123456789 0123456789", new char[] { '0', '1', '2' }, 3, 0, false };
            yield return new object[] { 11, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 11, false };
            yield return new object[] { 22, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 15, false };
            yield return new object[] { 22, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 22, false };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 30, false };
            yield return new object[] { 11, "0123456789 0123456789 0123456789", new char[] { '0', '1', '2' }, 1, 11, false };
            yield return new object[] { 12, "0123456789 0123456789 0123456789", new char[] { '0', '1', '2' }, 2, 11, false };
            yield return new object[] { 13, "0123456789 0123456789 0123456789", new char[] { '0', '1', '2' }, 3, 11, false };
            yield return new object[] { 22, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 31, true };
            yield return new object[] { 22, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 22, true };
            yield return new object[] { 0, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 0, true };
            yield return new object[] { 2, "0123456789 0123456789 0123456789", new char[] { '0', '1', '2' }, 1, 10, true };
            yield return new object[] { 1, "0123456789 0123456789 0123456789", new char[] { '0', '1', '2' }, 2, 10, true };
            yield return new object[] { 0, "0123456789 0123456789 0123456789", new char[] { '0', '1', '2' }, 3, 10, true };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", new char[] { '0', '1', '2' }, 4, 10, true };
            yield return new object[] { 31, "0123456789 0123456789 0123456789", new char[] { '9' }, 1, 31, true };
            yield return new object[] { 31, "0123456789 0123456789 0123456789", new char[] { '8', '9' }, 2, 30, false };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", new char[] { '8', '9' }, 3, 31, false };
        }
        [Theory]
        [MemberData(nameof(TestData_IndexOfOccurrence_CharArrayBackwards))]
        public void IndexOfOccurrence_CharArrayBackwards_Tests(object expected, string str, char[] values, int occurrence, int startIndex, bool backwards)
        {
            var sut = new IndexOfExp();
            var result = sut.IndexOfOccurrence(str, values, occurrence, startIndex, backwards);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_IndexOfOccurrence_CharArrayEndIndex()
        {
            yield return new object[] { 0, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 0, 31 };
            yield return new object[] { 11, "0123456789 0123456789 0123456789", new char[] { '0' }, 2, 0, 31 };
            yield return new object[] { 22, "0123456789 0123456789 0123456789", new char[] { '0' }, 3, 0, 31 };
            yield return new object[] { 11, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 1, 31 };
            yield return new object[] { 22, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 22, 31 };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", new char[] { '0' }, 1, 23, 31 };
            yield return new object[] { -1, "0123456789 0123456789 0123456789", new char[] { '0' }, 2, 22, 31 };
            yield return new object[] { 0, "0123456789 0123456789 0123456789", new char[] { '0', '1' }, 1, 0, 31 };
            yield return new object[] { 1, "0123456789 0123456789 0123456789", new char[] { '0', '1' }, 2, 0, 31 };
            yield return new object[] { 12, "0123456789 0123456789 0123456789", new char[] { '0', '1' }, 2, 10, 31 };
            yield return new object[] { -1, "0123456789", new char[] { '8', '9' }, 1, 0, 5 };
            yield return new object[] { 8, "0123456789", new char[] { '8', '9' }, 1, 0, 8 };
        }
        [Theory]
        [MemberData(nameof(TestData_IndexOfOccurrence_CharArrayEndIndex))]
        public void IndexOfOccurrence_CharArrayEndIndex_Tests(object expected, string str, char[] values, int occurrence, int startIndex, int endIndex)
        {
            var sut = new IndexOfExp();
            var result = sut.IndexOfOccurrence(str, values, occurrence, startIndex, endIndex);
            Assert.Equal(expected, result);
        }



    }
}
