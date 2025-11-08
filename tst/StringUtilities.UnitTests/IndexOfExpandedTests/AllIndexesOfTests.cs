using StringUtilities.Core.IndexOfExpanded;
using Xunit;

namespace StringUtilities.UnitTests.IndexOfExpandedTests
{
    public partial class IndexOfExpandedTests
    {
        // -- char --

        public static IEnumerable<object[]> TestData_AllIndexesOf_CharBackwardsCount()
        {
            yield return new object[] { new List<int> { }, "0123456789", 'a', 0, false, 10 };
            yield return new object[] { new List<int> { 0 }, "0123456789", '0', 0, false, 10 };
            yield return new object[] { new List<int> { 9 }, "0123456789", '9', 0, false, 10 };
            yield return new object[] { new List<int> { }, "0123456789", '9', 0, false, 9 };
            yield return new object[] { new List<int> { 0 }, "0123456789", '0', 9, true, 10 };
            yield return new object[] { new List<int> { }, "0123456789", '0', 9, true, 3 };
            yield return new object[] { new List<int> { 0, 5 }, "0123406789", '0', 0, false, 10 };
            yield return new object[] { new List<int> { 5, 0 }, "0123406789", '0', 9, true, 10 };
            yield return new object[] { new List<int> { 5 }, "0123406789", '0', 9, true, 5 };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_CharBackwardsCount))]
        public void AllIndexesOf_CharBackwardsCount_Tests(object expected, string str, char value, int startIndex, bool backwards, int count)
        {
            //ARRANGE
            var sut = new IndexOfExp();
            //ACT
            var result = sut.AllIndexesOf(str, value, startIndex, backwards, count);
            //ASSERT
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_AllIndexesOf_CharBackwards()
        {
            yield return new object[] { new List<int> { }, "0123456789", 'a', 0, false };
            yield return new object[] { new List<int> { 0 }, "0123456789", '0', 0, false };
            yield return new object[] { new List<int> { 9 }, "0123456789", '9', 0, false };
            yield return new object[] { new List<int> { 2, 7 }, "01|3456|89", '|', 0, false };
            yield return new object[] { new List<int> { }, "0123456789", '0', 1, false };
            yield return new object[] { new List<int> { 9 }, "0123456789", '9', 8, false };
            yield return new object[] { new List<int> { 0 }, "0123456789", '0', 1, true };
            yield return new object[] { new List<int> { }, "0123456789", '9', 8, true };
            yield return new object[] { new List<int> { 2 }, "abcde", 'c', 0, false };
            yield return new object[] { new List<int> { }, "abcde", 'C', 0, false };
            yield return new object[] { new List<int> { }, "0123456789", 'a', 10, false };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_CharBackwards))]
        public void AllIndexesOf_CharBackwards_Tests(object expected, string str, char value, int startIndex, bool backwards)
        {
            //ARRANGE
            var sut = new IndexOfExp();
            //ACT
            var result = sut.AllIndexesOf(str, value, startIndex, backwards);
            //ASSERT
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_AllIndexesOf_CharEndIndex()
        {
            yield return new object[] { new List<int> { }, "0123456789", 'a', 0, 9 };
            yield return new object[] { new List<int> { 4 }, "0123a56789", 'a', 0, 9 };
            yield return new object[] { new List<int> { 0 }, "a123456789", 'a', 0, 9 };
            yield return new object[] { new List<int> { 9 }, "012345678a", 'a', 0, 9 };
            yield return new object[] { new List<int> { }, "012345678a", 'a', 0, 8 };
            yield return new object[] { new List<int> { }, "a123456789", 'a', 1, 9 };
            yield return new object[] { new List<int> { }, "0123a56789", 'A', 0, 9 };
            yield return new object[] { new List<int> { 4 }, "0123a56789", 'a', 0, 9 };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_CharEndIndex))]
        public void AllIndexesOf_CharEndIndex_Tests(object expected, string str, char value, int startIndex, int endIndex)
        {
            var sut = new IndexOfExp();
            var result = sut.AllIndexesOf(str, value, startIndex, endIndex);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_AllIndexesOf_CharArrayBackwardsCount()
        {
            yield return new object[] { new List<int> { }, "0123456789", new char[] { 'a', 'b' }, 0, false, 10 };
            yield return new object[] { new List<int> { 0 }, "0123456789", new char[] { '0' }, 0, false, 10 };
            yield return new object[] { new List<int> { 0, 4 }, "0123456789", new char[] { '0', '4' }, 0, false, 10 };
            yield return new object[] { new List<int> { 0, 4 }, "0123456789", new char[] { '0', '4', 'a' }, 0, false, 10 };
            yield return new object[] { new List<int> { }, "0123456789", new char[] { '0' }, 1, false, 9 };
            yield return new object[] { new List<int> { 0 }, "0123456789", new char[] { '0' }, 9, true, 10  };
            yield return new object[] { new List<int> { 9 }, "0123456789", new char[] { '9' }, 9, true, 10 };
            yield return new object[] { new List<int> { }, "0123456789", new char[] { '9' }, 8, true, 9  };
            yield return new object[] { new List<int> { }, "0123456789", new char[] { 'a' }, 9, true, 10 };
            yield return new object[] { new List<int> { 6, 5 }, "0123456789", new char[] { '5', '6' }, 9, true, 5 };
            yield return new object[] { new List<int> { 6 }, "0123456789", new char[] { '5', '6' }, 9, true, 4 };
            yield return new object[] { new List<int> { }, "0123456789", new char[] { '5', '6' }, 9, true, 3 };
            yield return new object[] { new List<int> { 5, 6 }, "0123456789", new char[] { '5', '6' }, 0, false, 7 };
            yield return new object[] { new List<int> { 5 }, "0123456789", new char[] { '5', '6' }, 0, false, 6 };
            yield return new object[] { new List<int> { }, "0123456789", new char[] { '5', '6' }, 0, false, 5 };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_CharArrayBackwardsCount))]
        public void AllIndexesOf_CharArrayBackwardsCount_Tests(object expected, string str, char[] values, int startIndex, bool backwards, int count)
        {
            var sut = new IndexOfExp();
            var result = sut.AllIndexesOf(str, values, startIndex, backwards, count);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_AllIndexesOf_CharArrayBackwards()
        {
            yield return new object[] { new List<int> { }, "0123456789", new char[] { 'a', 'b' }, 0, false };
            yield return new object[] { new List<int> { 0 }, "0123456789", new char[] { '0' }, 0, false };
            yield return new object[] { new List<int> { 0, 4 }, "0123456789", new char[] { '0', '4' }, 0, false };
            yield return new object[] { new List<int> { 0, 4 }, "0123456789", new char[] { '0', '4', 'a' }, 0, false };
            yield return new object[] { new List<int> { }, "0123456789", new char[] { '0' }, 1, false };
            yield return new object[] { new List<int> { 0 }, "0123456789", new char[] { '0' }, 9, true };
            yield return new object[] { new List<int> { 9 }, "0123456789", new char[] { '9' }, 9, true };
            yield return new object[] { new List<int> {  }, "0123456789", new char[] { '9' }, 8, true };
            yield return new object[] { new List<int> {  }, "0123456789", new char[] { 'a' }, 9, true };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_CharArrayBackwards))]
        public void AllIndexesOf_CharArrayBackwards_Tests(object expected, string str, char[] values, int startIndex, bool backwards)
        {
            var sut = new IndexOfExp();
            var result = sut.AllIndexesOf(str, values, startIndex, backwards);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_AllIndexesOf_CharArrayEndIndex()
        {
            yield return new object[] { new List<int> { }, "0123456789", new char[] { 'a' }, 0, 9 };
            yield return new object[] { new List<int> { 0 }, "0123456789", new char[] { '0' }, 0, 9 };
            yield return new object[] { new List<int> { 0, 5 }, "0123456789", new char[] { '0', '5' }, 0, 9 };
            yield return new object[] { new List<int> { 5 }, "0123456789", new char[] { '0', '5' }, 1, 9 };
            yield return new object[] { new List<int> { 9 }, "0123456789", new char[] { '9' }, 1, 9 };
            yield return new object[] { new List<int> { }, "0123456789", new char[] { '9' }, 1, 8 };
            yield return new object[] { new List<int> { 3, 5, 7 }, "0123456789", new char[] { '0', '1', '3', '5', '7', '9' }, 2, 8 };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_CharArrayEndIndex))]
        public void AllIndexesOf_CharArrayEndIndex_Tests(object expected, string str, char[] values, int startIndex, int endIndex)
        {
            var sut = new IndexOfExp();
            var result = sut.AllIndexesOf(str, values, startIndex, endIndex);
            Assert.Equal(expected, result);
        }



        // -- char - exceptions --

        public static IEnumerable<object[]> TestData_AllIndexesOf_CharBackwardsCount_Exceptions()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { null, 'a', 0, false, 5, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'str')" };
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { "0123456789", 'a', -1, false, 5, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", 'a', 11, false, 5, typeof(ArgumentOutOfRangeException), "Value cannot be greater than parameter str's Lenght. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", 'a', 0, false, -1, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'count')" };
            yield return new object[] { "0123456789", 'a', 0, false, 12, typeof(ArgumentOutOfRangeException), "If parameter backwards is false, the sum of parameter count with startIndex cannot be greater than parameter str's Lenght. (Parameter 'count')" };
            yield return new object[] { "0123456789", 'a', 1, false, 11, typeof(ArgumentOutOfRangeException), "If parameter backwards is false, the sum of parameter count with startIndex cannot be greater than parameter str's Lenght. (Parameter 'count')" };
            yield return new object[] { "0123456789", 'a', 6, false, 6, typeof(ArgumentOutOfRangeException), "If parameter backwards is false, the sum of parameter count with startIndex cannot be greater than parameter str's Lenght. (Parameter 'count')" };
            yield return new object[] { "0123456789", 'a', 1, true, 3, typeof(ArgumentOutOfRangeException), "If parameter backwards is true, the result of startIndex + 1 - count must be 0 or positive. (Parameter 'count')" };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_CharBackwardsCount_Exceptions))]
        public void AllIndexesOf_CharBackwardsCount_ExceptionsTests(string str, char value, int startIndex, bool backwards, int count, Type expectedExceptionType, string expectedMessage)
        {
            var sut = new IndexOfExp();
            var exception = Assert.Throws(expectedExceptionType, () => sut.AllIndexesOf(str, value, startIndex, backwards, count));
            Assert.Equal(expectedMessage, exception.Message);
        }

        public static IEnumerable<object[]> TestData_AllIndexesOf_CharBackwards_Exceptions()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { null, 'a', 0, false, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'str')" };
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { "0123456789", 'a', -1, false, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", 'a', 11, false, typeof(ArgumentOutOfRangeException), "Value cannot be greater than parameter str's Lenght. (Parameter 'startIndex')" };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_CharBackwards_Exceptions))]
        public void AllIndexesOf_CharBackwards_ExceptionsTests(string str, char value, int startIndex, bool backwards, Type expectedExceptionType, string expectedMessage)
        {
            var sut = new IndexOfExp();
            var exception = Assert.Throws(expectedExceptionType, () => sut.AllIndexesOf(str, value, startIndex, backwards));
            Assert.Equal(expectedMessage, exception.Message);
        }

        public static IEnumerable<object[]> TestData_AllIndexesOf_CharEndIndex_Exceptions()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { null, 'a', 0, 9, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'str')" };
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { "0123456789", 'a', -1, 9, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", 'a', 30, 9, typeof(ArgumentOutOfRangeException), "Value cannot be greater than parameter str's Lenght. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", 'a', 0, -1, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'endIndex')" };
            yield return new object[] { "0123456789", 'a', 0, 30, typeof(ArgumentOutOfRangeException), "Value cannot be greater than parameter str's Lenght. (Parameter 'endIndex')" };
            yield return new object[] { "0123456789", 'a', 5, 3, typeof(ArgumentException), "Parameter startIndex cannot be greater than parameter endIndex." };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_CharEndIndex_Exceptions))]
        public void AllIndexesOf_CharEndIndex_ExceptionsTests(string str, char value, int startIndex, int endIndex, Type expectedExceptionType, string expectedMessage)
        {
            var sut = new IndexOfExp();
            var exception = Assert.Throws(expectedExceptionType, () => sut.AllIndexesOf(str, value, startIndex, endIndex));
            Assert.Equal(expectedMessage, exception.Message);
        }

        public static IEnumerable<object[]> TestData_AllIndexesOf_CharArrayBackwardsCount_Exceptions()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { null, new char[] { 'a' }, 0, false, 5, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'str')" };
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { "0123456789", new char[] { 'a' }, -1, false, 5, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", new char[] { 'a' }, 11, false, 5, typeof(ArgumentOutOfRangeException), "Value cannot be greater than parameter str's Lenght. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", new char[] { 'a' }, 0, false, -1, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'count')" };
            yield return new object[] { "0123456789", new char[] { 'a' }, 0, false, 12, typeof(ArgumentOutOfRangeException), "If parameter backwards is false, the sum of parameter count with startIndex cannot be greater than parameter str's Lenght. (Parameter 'count')" };
            yield return new object[] { "0123456789", new char[] { 'a' }, 1, false, 11, typeof(ArgumentOutOfRangeException), "If parameter backwards is false, the sum of parameter count with startIndex cannot be greater than parameter str's Lenght. (Parameter 'count')" };
            yield return new object[] { "0123456789", new char[] { 'a' }, 6, false, 6, typeof(ArgumentOutOfRangeException), "If parameter backwards is false, the sum of parameter count with startIndex cannot be greater than parameter str's Lenght. (Parameter 'count')" };
            yield return new object[] { "0123456789", new char[] { 'a' }, 1, true, 3, typeof(ArgumentOutOfRangeException), "If parameter backwards is true, the result of startIndex + 1 - count must be 0 or positive. (Parameter 'count')" };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_CharArrayBackwardsCount_Exceptions))]
        public void AllIndexesOf_CharArrayBackwardsCount_ExceptionsTests(string str, char[] values, int startIndex, bool backwards, int count, Type expectedExceptionType, string expectedMessage)
        {
            var sut = new IndexOfExp();
            var exception = Assert.Throws(expectedExceptionType, () => sut.AllIndexesOf(str, values, startIndex, backwards, count));
            Assert.Equal(expectedMessage, exception.Message);
        }

        public static IEnumerable<object[]> TestData_AllIndexesOf_CharArrayBackwards_Exceptions()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { null, new char[] { 'a' }, 0, false, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'str')" };
            yield return new object[] { "0123456789", null, 0, false, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'values')" };
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { "0123456789", new char[] { 'a' }, -1, false, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", new char[] { 'a' }, 30, false, typeof(ArgumentOutOfRangeException), "Value cannot be greater than parameter str's Lenght. (Parameter 'startIndex')" };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_CharArrayBackwards_Exceptions))]
        public void AllIndexesOf_CharArrayBackwards_ExceptionsTests(string str, char[] values, int startIndex, bool backwards, Type expectedExceptionType, string expectedMessage)
        {
            var sut = new IndexOfExp();
            var exception = Assert.Throws(expectedExceptionType, () => sut.AllIndexesOf(str, values, startIndex, backwards));
            Assert.Equal(expectedMessage, exception.Message);
        }

        public static IEnumerable<object[]> TestData_AllIndexesOf_CharArrayEndIndex_Exceptions()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { null, new char[] { 'a' }, 0, 9, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'str')" };
            yield return new object[] { "0123456789", null, 0, 9, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'values')" };
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { "0123456789", new char[] { 'a' }, -1, 9, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", new char[] { 'a' }, 30, 9, typeof(ArgumentOutOfRangeException), "Value cannot be greater than parameter str's Lenght. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", new char[] { 'a' }, 0, -1, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'endIndex')" };
            yield return new object[] { "0123456789", new char[] { 'a' }, 0, 30, typeof(ArgumentOutOfRangeException), "Value cannot be greater than parameter str's Lenght. (Parameter 'endIndex')" };
            yield return new object[] { "0123456789", new char[] { 'a' }, 5, 3, typeof(ArgumentException), "Parameter startIndex cannot be greater than parameter endIndex." };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_CharArrayEndIndex_Exceptions))]
        public void AllIndexesOf_CharArrayEndIndex_ExceptionsTests(string str, char[] values, int startIndex, int endIndex, Type expectedExceptionType, string expectedMessage)
        {
            var sut = new IndexOfExp();
            var exception = Assert.Throws(expectedExceptionType, () => sut.AllIndexesOf(str, values, startIndex, endIndex));
            Assert.Equal(expectedMessage, exception.Message);
        }



        // -- string --

        public static IEnumerable<object[]> TestData_AllIndexesOf_StringBackwardsCount()
        {
            yield return new object[] { new List<int> { }, "0123456789", "ab", 0, false, 10, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0 }, "ab23456789", "ab", 0, false, 10, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 8 }, "01234567ab", "ab", 0, false, 10, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 8 }, "01234567ab", "ab", 5, false, 5, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { }, "01234567ab", "ab", 5, true, 6, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0 }, "ab23456789", "ab", 5, true, 6, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0 }, "ab23456789", "AB", 5, true, 6, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0 }, "ab23456789", "ab", 5, true, 6, StringComparison.CurrentCulture };
            yield return new object[] { new List<int> { }, "ab23456789", "AB", 5, true, 6, StringComparison.CurrentCulture };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_StringBackwardsCount))]
        public void AllIndexesOf_StringBackwardsCount_Tests(object expected, string str, string value, int startIndex, bool backwards, int count, StringComparison stringComparison)
        {
            var sut = new IndexOfExp();
            var result = sut.AllIndexesOf(str, value, startIndex, backwards, count, stringComparison);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_AllIndexesOf_StringBackwards()
        {
            yield return new object[] { new List<int> { }, "0123456789", "ab", 0, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0 }, "ab23456789", "ab", 0, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 8 }, "01234567ab", "ab", 0, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 8 }, "01234567ab", "ab", 5, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { }, "01234567ab", "ab", 5, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0 }, "ab23456789", "ab", 5, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0 }, "ab23456789", "AB", 5, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0 }, "ab23456789", "ab", 5, true, StringComparison.CurrentCulture };
            yield return new object[] { new List<int> { }, "ab23456789", "AB", 5, true, StringComparison.CurrentCulture };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_StringBackwards))]
        public void AllIndexesOf_StringBackwards_Tests(object expected, string str, string value, int startIndex, bool backwards, StringComparison stringComparison)
        {
            var sut = new IndexOfExp();
            var result = sut.AllIndexesOf(str, value, startIndex, backwards, stringComparison);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_AllIndexesOf_StringEndIndex()
        {
            yield return new object[] { new List<int> { }, "0123456789", "ab", 0, 9, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0 }, "ab23456789", "ab", 0, 9, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 8 }, "01234567ab", "ab", 0, 9, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 5 }, "ab234ab789", "ab", 5, 9, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0, 5 }, "ab234ab789", "ab", 0, 9, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0 }, "ab234ab789", "ab", 0, 5, StringComparison.CurrentCultureIgnoreCase };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_StringEndIndex))]
        public void AllIndexesOf_StringEndIndex_Tests(object expected, string str, string value, int startIndex, int endIndex, StringComparison stringComparison)
        {
            var sut = new IndexOfExp();
            var result = sut.AllIndexesOf(str, value, startIndex, endIndex, stringComparison);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_AllIndexesOf_StringArrayBackwardsCount()
        {
            yield return new object[] { new List<int> { }, "0123456789", new string[] { "ab" }, 0, false, 10, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0 }, "ab23456789", new string[] { "ab" }, 0, false, 10, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 8 }, "01234567ab", new string[] { "ab" }, 0, false, 10, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0, 8 }, "ab234567cd", new string[] { "ab", "cd" }, 0, false, 10, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0, 8 }, "ab234567cd", new string[] { "AB", "CD" }, 0, false, 10, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { }, "ab234567cd", new string[] { "AB", "CD" }, 0, false, 10, StringComparison.CurrentCulture };
            yield return new object[] { new List<int> { 8 }, "ab234567cd", new string[] { "AB", "cd" }, 0, false, 10, StringComparison.CurrentCulture };
            yield return new object[] { new List<int> { 8, 0 }, "ab234567cd", new string[] { "ab", "cd" }, 10, true, 11, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 8 }, "ab234567cd", new string[] { "ab", "cd" }, 10, true, 5, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { }, "ab234567cd", new string[] { "ab", "cd" }, 10, true, 1, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0 }, "ab234567cd", new string[] { "ab", "cd" }, 0, false, 9, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0 }, "ab234567cd", new string[] { "ab", "cd" }, 0, false, 5, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { }, "ab234567cd", new string[] { "ab", "cd" }, 0, false, 1, StringComparison.CurrentCultureIgnoreCase };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_StringArrayBackwardsCount))]
        public void AllIndexesOf_StringArrayBackwardsCount_Tests(object expected, string str, string[] values, int startIndex, bool backwards, int count, StringComparison stringComparison)
        {
            var sut = new IndexOfExp();
            var result = sut.AllIndexesOf(str, values, startIndex, backwards, count, stringComparison);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_AllIndexesOf_StringArrayBackwards()
        {
            yield return new object[] { new List<int> { }, "0123456789", new string[] { "ab" }, 0, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0 }, "ab23456789", new string[] { "ab" }, 0, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0, 8 }, "ab234567cd", new string[] { "ab", "cd" }, 0, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 8, 0 }, "ab234567cd", new string[] { "ab", "cd" }, 9, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0, 8 }, "ab234567cd", new string[] { "cd", "ab" }, 0, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0, 8 }, "ab234567cd", new string[] { "cd", "ab" }, 0, false, StringComparison.CurrentCulture };
            yield return new object[] { new List<int> { 0 }, "ab234567cd", new string[] { "CD", "ab" }, 0, false, StringComparison.CurrentCulture };
            yield return new object[] { new List<int> {  }, "ab234567cd", new string[] { "CD", "AB" }, 0, false, StringComparison.CurrentCulture };
            yield return new object[] { new List<int> { 0, 8 }, "ab234567cd", new string[] { "CD", "AB" }, 0, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 8, 0 }, "ab234567cd", new string[] { "ab", "cd" }, 9, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0 }, "ab234567cd", new string[] { "ab", "cd" }, 8, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 8 }, "ab234567cd", new string[] { "ab", "cd" }, 1, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 9 }, "ab234567cd", new string[] { "d" }, 9, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 9 }, "ab234567cd", new string[] { "d" }, 9, true, StringComparison.CurrentCultureIgnoreCase };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_StringArrayBackwards))]
        public void AllIndexesOf_StringArrayBackwards_Tests(object expected, string str, string[] values, int startIndex, bool backwards, StringComparison stringComparison)
        {
            var sut = new IndexOfExp();
            var result = sut.AllIndexesOf(str, values, startIndex, backwards, stringComparison);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_AllIndexesOf_StringArrayEndIndex()
        {
            yield return new object[] { new List<int> { }, "0123456789", new string[] { "ab" }, 0, 9, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0 }, "ab23456789", new string[] { "ab" }, 0, 9, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0, 8 }, "ab234567cd", new string[] { "ab", "cd" }, 0, 9, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 8 }, "ab234567cd", new string[] { "ab", "cd" }, 1, 9, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { }, "ab234567cd", new string[] { "ab", "cd" }, 1, 8, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 0, 8 }, "ab234567cd", new string[] { "ab", "cd" }, 0, 9, StringComparison.CurrentCulture };
            yield return new object[] { new List<int> { 0, 8 }, "ab234567cd", new string[] { "cd", "ab" }, 0, 9, StringComparison.CurrentCulture };
            yield return new object[] { new List<int> { }, "ab234567cd", new string[] { "AB", "CD" }, 0, 9, StringComparison.CurrentCulture };
            yield return new object[] { new List<int> { 0, 8 }, "ab234567cd", new string[] { "AB", "CD" }, 0, 9, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { new List<int> { 9 }, "ab234567cd", new string[] { "d" }, 9, 9, StringComparison.CurrentCultureIgnoreCase };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_StringArrayEndIndex))]
        public void AllIndexesOf_StringArrayEndIndex_Tests(object expected, string str, string[] values, int startIndex, int endIndex, StringComparison stringComparison)
        {
            var sut = new IndexOfExp();
            var result = sut.AllIndexesOf(str, values, startIndex, endIndex, stringComparison);
            Assert.Equal(expected, result);
        }



        // -- string - exceptions --

        public static IEnumerable<object[]> TestData_AllIndexesOf_StringBackwardsCount_Exceptions()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { null, "a", 0, false, 5, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'str')" };
            yield return new object[] { "0123456789", null, 0, false, 5, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'value')" };
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { "0123456789", "a", -1, false, 5, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", "a", 11, false, 5, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be greater than parameter str's Lenght. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", "a", 0, false, -1, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'count')" };
            yield return new object[] { "0123456789", "a", 0, false, 12, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "If parameter backwards is false, the sum of parameter count with startIndex cannot be greater than parameter str's Lenght. (Parameter 'count')" };
            yield return new object[] { "0123456789", "a", 1, false, 11, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "If parameter backwards is false, the sum of parameter count with startIndex cannot be greater than parameter str's Lenght. (Parameter 'count')" };
            yield return new object[] { "0123456789", "a", 6, false, 6, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "If parameter backwards is false, the sum of parameter count with startIndex cannot be greater than parameter str's Lenght. (Parameter 'count')" };
            yield return new object[] { "0123456789", "a", 1, true, 3, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "If parameter backwards is true, the result of startIndex + 1 - count must be 0 or positive. (Parameter 'count')" };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_StringBackwardsCount_Exceptions))]
        public void AllIndexesOf_StringBackwardsCount_ExceptionsTests(string str, string value, int startIndex, bool backwards, int count, StringComparison stringComparison, Type expectedExceptionType, string expectedMessage)
        {
            var sut = new IndexOfExp();
            var exception = Assert.Throws(expectedExceptionType, () => sut.AllIndexesOf(str, value, startIndex, backwards, count, stringComparison));
            Assert.Equal(expectedMessage, exception.Message);
        }

        public static IEnumerable<object[]> TestData_AllIndexesOf_StringBackwards_Exceptions()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { null, "ab", 0, false, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'str')" };
            yield return new object[] { "0123456789", null, 0, false, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'value')" };
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { "0123456789", "ab", -1, false, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", "ab", 30, false, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be greater than parameter str's Lenght. (Parameter 'startIndex')" };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_StringBackwards_Exceptions))]
        public void AllIndexesOf_StringBackwards_ExceptionsTests(string str, string value, int startIndex, bool backwards, StringComparison stringComparison, Type expectedExceptionType, string expectedMessage)
        {
            var sut = new IndexOfExp();
            var exception = Assert.Throws(expectedExceptionType, () => sut.AllIndexesOf(str, value, startIndex, backwards, stringComparison));
            Assert.Equal(expectedMessage, exception.Message);
        }

        public static IEnumerable<object[]> TestData_AllIndexesOf_StringEndIndex_Exceptions()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { null, "ab", 0, 9, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'str')" };
            yield return new object[] { "0123456789", null, 0, 9, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'value')" };
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { "0123456789", "ab", -1, 9, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", "ab", 30, 9, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be greater than parameter str's Lenght. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", "ab", 0, -1, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'endIndex')" };
            yield return new object[] { "0123456789", "ab", 0, 30, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be greater than parameter str's Lenght. (Parameter 'endIndex')" };
            yield return new object[] { "0123456789", "ab", 5, 3, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentException), "Parameter startIndex cannot be greater than parameter endIndex." };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_StringEndIndex_Exceptions))]
        public void AllIndexesOf_StringEndIndex_ExceptionsTests(string str, string value, int startIndex, int endIndex, StringComparison stringComparison, Type expectedExceptionType, string expectedMessage)
        {
            var sut = new IndexOfExp();
            var exception = Assert.Throws(expectedExceptionType, () => sut.AllIndexesOf(str, value, startIndex, endIndex, stringComparison));
            Assert.Equal(expectedMessage, exception.Message);
        }

        public static IEnumerable<object[]> TestData_AllIndexesOf_StringArrayBackwardsCount_Exceptions()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { null, new string[] { "a" }, 0, false, 5, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'str')" };
            yield return new object[] { "0123456789", null, 0, false, 5, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'values')" };
            yield return new object[] { "0123456789",  new string[] { null }, 0, false, 5, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Parameter values cannot contain nulls. (Parameter 'values')" };
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { "0123456789",  new string[] { "a" }, -1, false, 5, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789",  new string[] { "a" }, 11, false, 5, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be greater than parameter str's Lenght. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789",  new string[] { "a" }, 0, false, -1, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'count')" };
            yield return new object[] { "0123456789",  new string[] { "a" }, 0, false, 12, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "If parameter backwards is false, the sum of parameter count with startIndex cannot be greater than parameter str's Lenght. (Parameter 'count')" };
            yield return new object[] { "0123456789",  new string[] { "a" }, 1, false, 11, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "If parameter backwards is false, the sum of parameter count with startIndex cannot be greater than parameter str's Lenght. (Parameter 'count')" };
            yield return new object[] { "0123456789",  new string[] { "a" }, 6, false, 6, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "If parameter backwards is false, the sum of parameter count with startIndex cannot be greater than parameter str's Lenght. (Parameter 'count')" };
            yield return new object[] { "0123456789", new string[] { "a" }, 1, true, 3, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "If parameter backwards is true, the result of startIndex + 1 - count must be 0 or positive. (Parameter 'count')" };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_StringArrayBackwardsCount_Exceptions))]
        public void AllIndexesOf_StringArrayBackwardsCount_ExceptionsTests(string str, string[] values, int startIndex, bool backwards, int count, StringComparison stringComparison, Type expectedExceptionType, string expectedMessage)
        {
            var sut = new IndexOfExp();
            var exception = Assert.Throws(expectedExceptionType, () => sut.AllIndexesOf(str, values, startIndex, backwards, count, stringComparison));
            Assert.Equal(expectedMessage, exception.Message);
        }

        public static IEnumerable<object[]> TestData_AllIndexesOf_StringArrayBackwards_Exceptions()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { null, new string[] { "ab" }, 0, false, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'str')" };
            yield return new object[] { "0123456789", null, 0, false, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'values')" };
            yield return new object[] { "0123456789", new string[] { "ab", null }, 0, false, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Parameter values cannot contain nulls. (Parameter 'values')" }; //"Parameter values cannot contain nulls."
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { "0123456789", new string[] { "ab" }, -1, false, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", new string[] { "ab" }, 30, false, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be greater than parameter str's Lenght. (Parameter 'startIndex')" };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_StringArrayBackwards_Exceptions))]
        public void AllIndexesOf_StringArrayBackwards_ExceptionsTests(string str, string[] values, int startIndex, bool backwards, StringComparison stringComparison, Type expectedExceptionType, string expectedMessage)
        {
            var sut = new IndexOfExp();
            var exception = Assert.Throws(expectedExceptionType, () => sut.AllIndexesOf(str, values, startIndex, backwards, stringComparison));
            Assert.Equal(expectedMessage, exception.Message);
        }

        public static IEnumerable<object[]> TestData_AllIndexesOf_StringArrayEndIndex_Exceptions()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { null, new string[] { "ab" }, 0, 9, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'str')" };
            yield return new object[] { "0123456789", null, 0, 9, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'values')" };
            yield return new object[] { "0123456789", new string[] { "ab", null }, 0, false, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Parameter values cannot contain nulls. (Parameter 'values')" }; //"Parameter values cannot contain nulls."
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { "0123456789", new string[] { "ab" }, -1, 9, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", new string[] { "ab" }, 30, 9, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be greater than parameter str's Lenght. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", new string[] { "ab" }, 0, -1, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'endIndex')" };
            yield return new object[] { "0123456789", new string[] { "ab" }, 0, 30, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be greater than parameter str's Lenght. (Parameter 'endIndex')" };
            yield return new object[] { "0123456789", new string[] { "ab" }, 5, 3, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentException), "Parameter startIndex cannot be greater than parameter endIndex." };
        }
        [Theory]
        [MemberData(nameof(TestData_AllIndexesOf_StringArrayEndIndex_Exceptions))]
        public void AllIndexesOf_StringArrayEndIndex_ExceptionsTests(string str, string[] values, int startIndex, int endIndex, StringComparison stringComparison, Type expectedExceptionType, string expectedMessage)
        {
            var sut = new IndexOfExp();
            var exception = Assert.Throws(expectedExceptionType, () => sut.AllIndexesOf(str, values, startIndex, endIndex, stringComparison));
            Assert.Equal(expectedMessage, exception.Message);
        }


    }
}
