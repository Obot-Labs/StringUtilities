using StringUtilities.Core.IndexOfExpanded;
using Xunit;

namespace StringUtilities.UnitTests.IndexOfExpandedTests
{
    public partial class IndexOfExpandedTests
    {
        // -- IndexOfAny --

        public static IEnumerable<object[]> TestData_IndexOfAny()
        {
            yield return new object[] { -1, "0123456789", new string[] { "ab" }, 0, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 0, "0123456789", new string[] { "01" }, 0, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 0, "0123456789", new string[] { "01", "89" }, 0, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 0, "0123456789", new string[] { "89", "01" }, 0, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 8, "0123456789", new string[] { "01", "89" }, 1, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 0, "ab234567cd", new string[] { "ab", "cd" }, 0, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 0, "ab234567cd", new string[] { "AB", "CD" }, 0, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { -1, "ab234567cd", new string[] { "AB", "CD" }, 0, StringComparison.CurrentCulture };
            yield return new object[] { 8, "ab234567cd", new string[] { "AB", "CD" }, 1, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 9, "ab234567cd", new string[] { "D" }, 9, StringComparison.CurrentCultureIgnoreCase };
        }
        [Theory]
        [MemberData(nameof(TestData_IndexOfAny))]
        public void IndexOfAny_Tests(object expected, string str, string[] values, int startIndex, StringComparison stringComparison)
        {
            var sut = new IndexOfExp();
            var result = sut.IndexOfAny(str, values, startIndex, stringComparison);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_IndexOfAny_Count()
        {
            yield return new object[] { -1, "0123456789", new string[] { "ab" }, 0, 10, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 0, "0123456789", new string[] { "01" }, 0, 10, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 0, "0123456789", new string[] { "01", "89" }, 0, 10, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 8, "0123456789", new string[] { "01", "89" }, 1, 9, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 0, "0123456789", new string[] { "89", "01" }, 0, 10, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 0, "ab234567cd", new string[] { "ab", "cd" }, 0, 10, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 0, "ab234567cd", new string[] { "AB", "CD" }, 0, 10, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { -1, "ab234567cd", new string[] { "AB", "CD" }, 0, 10, StringComparison.CurrentCulture };
            yield return new object[] { 8, "ab234567cd", new string[] { "AB", "cd" }, 0, 10, StringComparison.CurrentCulture };
            yield return new object[] { -1, "ab234567cd", new string[] { "cd" }, 0, 6, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 9, "ab234567cd", new string[] { "d" }, 0, 10, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 9, "ab234567cd", new string[] { "d" }, 9, 1, StringComparison.CurrentCultureIgnoreCase };
        }
        [Theory]
        [MemberData(nameof(TestData_IndexOfAny_Count))]
        public void IndexOfAny_Tests_Count(object expected, string str, string[] values, int startIndex, int count, StringComparison stringComparison)
        {
            var sut = new IndexOfExp();
            var result = sut.IndexOfAny(str, values, startIndex, count, stringComparison);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_LastIndexOfAny()
        {
            yield return new object[] { -1, "0123456789", new string[] { "ab" }, 0, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 0, "0123456789", new string[] { "01" }, 9, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 8, "0123456789", new string[] { "01", "89" }, 9, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 9, "0123456789", new string[] { "9" }, 10, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 9, "0123456789", new string[] { "9" }, 9, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 8, "ab234567cd", new string[] { "ab", "cd" }, 9, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 8, "ab234567cd", new string[] { "AB", "CD" }, 9, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { -1, "ab234567cd", new string[] { "AB", "CD" }, 9, StringComparison.CurrentCulture };
            yield return new object[] { 0, "ab234567cd", new string[] { "ab", "CD" }, 9, StringComparison.CurrentCulture };
            yield return new object[] { 0, "ab234567cd", new string[] { "ab", "cd" }, 8, StringComparison.CurrentCulture };

        }
        [Theory]
        [MemberData(nameof(TestData_LastIndexOfAny))]
        public void LastIndexOfAny_Tests(object expected, string str, string[] values, int startIndex, StringComparison stringComparison)
        {
            var sut = new IndexOfExp();
            var result = sut.LastIndexOfAny(str, values, startIndex, stringComparison);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_LastIndexOfAny_Count()
        {
            yield return new object[] { -1, "0123456789", new string[] { "ab" }, 9, 10, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 0, "0123456789", new string[] { "01" }, 10, 11, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 8, "0123456789", new string[] { "01", "89" }, 10, 11, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 8, "ab234567cd", new string[] { "ab", "cd" }, 10, 11, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 0, "ab234567cd", new string[] { "ab", "cd" }, 8, 9, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 8, "ab234567cd", new string[] { "ab", "cd" }, 10, 3, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 0, "ab234567cd", new string[] { "ab", "cd" }, 3, 4, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { 8, "ab234567cd", new string[] { "ab", "cd" }, 10, 11, StringComparison.CurrentCulture };
            yield return new object[] { 8, "ab234567cd", new string[] { "AB", "CD" }, 10, 11, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { -1, "ab234567cd", new string[] { "AB", "CD" }, 10, 11, StringComparison.CurrentCulture };
            yield return new object[] { 0, "ab234567cd", new string[] { "ab", "CD" }, 10, 11, StringComparison.CurrentCulture };
        }
        [Theory]
        [MemberData(nameof(TestData_LastIndexOfAny_Count))]
        public void LastIndexOfAny_Tests_Count(object expected, string str, string[] values, int startIndex, int count, StringComparison stringComparison)
        {
            var sut = new IndexOfExp();
            var result = sut.LastIndexOfAny(str, values, startIndex, count, stringComparison);
            Assert.Equal(expected, result);
        }


        // -- IndexOfAny - exceptions --

        public static IEnumerable<object[]> TestData_IndexOfAny_Exceptions()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { null, new string[] { "ab" }, 0, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'str')" };
            yield return new object[] { "0123456789", null, 0, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'values')" };
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { "0123456789", new string[] { "ab" }, -1, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", new string[] { "ab" }, 30, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be greater than parameter str's Lenght. (Parameter 'startIndex')" };
        }
        [Theory]
        [MemberData(nameof(TestData_IndexOfAny_Exceptions))]
        public void IndexOfAny_ExceptionsTests(string str, string[] values, int startIndex, StringComparison stringComparison, Type expectedExceptionType, string expectedMessage)
        {
            var sut = new IndexOfExp();
            var exception = Assert.Throws(expectedExceptionType, () => sut.IndexOfAny(str, values, startIndex, stringComparison));
            Assert.Equal(expectedMessage, exception.Message);
        }

        public static IEnumerable<object[]> TestData_IndexOfAny_Count_Exceptions()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { null, new string[] { "ab" }, 0, 10, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'str')" };
            yield return new object[] { "0123456789", null, 0, 10, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'values')" };
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { "0123456789", new string[] { "ab" }, -1, 10, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", new string[] { "ab" }, 30, 10, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be greater than parameter str's Lenght. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", new string[] { "ab" }, 0, -1, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'count')" };
            yield return new object[] { "0123456789", new string[] { "ab" }, 0, 30, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Sum of parameter count with startIndex cannot be greater than parameter str's Lenght. (Parameter 'count')" };
        }
        [Theory]
        [MemberData(nameof(TestData_IndexOfAny_Count_Exceptions))]
        public void IndexOfAny_Count_ExceptionsTests(string str, string[] values, int startIndex, int count, StringComparison stringComparison, Type expectedExceptionType, string expectedMessage)
        {
            var sut = new IndexOfExp();
            var exception = Assert.Throws(expectedExceptionType, () => sut.IndexOfAny(str, values, startIndex, count, stringComparison));
            Assert.Equal(expectedMessage, exception.Message);
        }

        public static IEnumerable<object[]> TestData_LastIndexOfAny_Exceptions()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { null, new string[] { "ab" }, 10, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'str')" };
            yield return new object[] { "0123456789", null, 10, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'values')" };
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { "0123456789", new string[] { "ab" }, -1, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", new string[] { "ab" }, 30, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be greater than parameter str's Lenght. (Parameter 'startIndex')" };
        }
        [Theory]
        [MemberData(nameof(TestData_LastIndexOfAny_Exceptions))]
        public void LastIndexOfAny_ExceptionsTests(string str, string[] values, int startIndex, StringComparison stringComparison, Type expectedExceptionType, string expectedMessage)
        {
            var sut = new IndexOfExp();
            var exception = Assert.Throws(expectedExceptionType, () => sut.LastIndexOfAny(str, values, startIndex, stringComparison));
            Assert.Equal(expectedMessage, exception.Message);
        }

        public static IEnumerable<object[]> TestData_LastIndexOfAny_Count_Exceptions()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { null, new string[] { "ab" }, 0, 10, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'str')" };
            yield return new object[] { "0123456789", null, 0, 10, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'values')" };
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            yield return new object[] { "0123456789", new string[] { "ab" }, -1, 10, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", new string[] { "ab" }, 30, 10, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be greater than parameter str's Lenght. (Parameter 'startIndex')" };
            yield return new object[] { "0123456789", new string[] { "ab" }, 0, -1, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "Value cannot be less than 0. (Parameter 'count')" };
            yield return new object[] { "0123456789", new string[] { "ab" }, 0, 30, StringComparison.CurrentCultureIgnoreCase, typeof(ArgumentOutOfRangeException), "The result of startIndex + 1 - count must be 0 or positive. (Parameter 'count')" };
        }
        [Theory]
        [MemberData(nameof(TestData_LastIndexOfAny_Count_Exceptions))]
        public void LastIndexOfAny_Count_ExceptionsTests(string str, string[] values, int startIndex, int count, StringComparison stringComparison, Type expectedExceptionType, string expectedMessage)
        {
            var sut = new IndexOfExp();
            var exception = Assert.Throws(expectedExceptionType, () => sut.LastIndexOfAny(str, values, startIndex, count, stringComparison));
            Assert.Equal(expectedMessage, exception.Message);
        }


    }
}

/*
        [Fact]
        public void BatchTest()
        {
            //ARRANGE
            var sutExample = new int[10] { 20, 20, 20, 20, 20, 20, 20, 20, 20, 20 };
            var batchecQuantity = 5;

            var expectedBatches = 2;
            var expectedNumPerBactch = 5;

            //ACT
            var result = sutExample.Batch(batchecQuantity);
            var countBatches = result.Count();
            var countInsideBatch = result.First().Count();

            //ASSERT
            Assert.Equal(expectedBatches, countBatches);
            Assert.Equal(expectedNumPerBactch, countInsideBatch);
        }
 */