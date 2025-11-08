using StringUtilities.Core.SubstringExpanded;
using Xunit;

namespace StringUtilities.UnitTests.SubstringExpandedTests
{
    public partial class SubstringExpTests
    {
        public static IEnumerable<object[]> TestData_SubstringToChar()
        {
            yield return new object[] { "34567|", "0|234567|9", 3, '|', true, false };
            yield return new object[] { "34567", "0|234567|9", 3, '|', false, false };
            yield return new object[] { "|23456", "0|234567|9", 6, '|', true, true };
            yield return new object[] { "23456", "0|234567|9", 6, '|', false, true };
            yield return new object[] { "56789", "0123456789", 5, '|', false, false };
            yield return new object[] { "012345", "0123456789", 5, '|', false, true };
            yield return new object[] { "|", "01234|6789", 5, '|', true, false };
            yield return new object[] { "", "01234|6789", 5, '|', false, false };
            yield return new object[] { "|", "01234|6789", 5, '|', true, true };
            yield return new object[] { "", "01234|6789", 5, '|', false, true };
            yield return new object[] { "0|", "0|234567|9", 0, '|', true, false };
            yield return new object[] { "0", "0|234567|9", 0, '|', false, false };
            yield return new object[] { "|9", "0|234567|9", 9, '|', true, true };
            yield return new object[] { "9", "0|234567|9", 9, '|', false, true };
        }
        [Theory]
        [MemberData(nameof(TestData_SubstringToChar))]
        public void SubstringToChar_Tests(object expected, string str, int startIndex, char toChar, bool includeChar, bool backwards)
        {
            var sut = new SubstringExp();
            var result = sut.SubstringToChar(str, startIndex, toChar, includeChar, backwards);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_SubstringToChar_Occurrence()
        {
            yield return new object[] { "34567|", "0|234567|9", 3, '|', 1, true, false };
            yield return new object[] { "34567", "0|234567|9", 3, '|', 1, false, false };
            yield return new object[] { "|23456", "0|234567|9", 6, '|', 1, true, true };
            yield return new object[] { "23456", "0|234567|9", 6, '|', 1, false, true };
            yield return new object[] { "56789", "0123456789", 5, '|', 1, false, false };
            yield return new object[] { "012345", "0123456789", 5, '|', 1, false, true };
            yield return new object[] { "|", "01234|6789", 5, '|', 1, true, false };
            yield return new object[] { "", "01234|6789", 5, '|', 1, false, false };
            yield return new object[] { "|", "01234|6789", 5, '|', 1, true, true };
            yield return new object[] { "", "01234|6789", 5, '|', 1, false, true };
            yield return new object[] { "0|", "0|234567|9", 0, '|', 1, true, false };
            yield return new object[] { "0", "0|234567|9", 0, '|', 1, false, false };
            yield return new object[] { "|9", "0|234567|9", 9, '|', 1, true, true };
            yield return new object[] { "9", "0|234567|9", 9, '|', 1, false, true };
            yield return new object[] { "0|234567|", "0|234567|9", 0, '|', 2, true, false };
            yield return new object[] { "0|234567", "0|234567|9", 0, '|', 2, false, false };
            yield return new object[] { "|234567|9", "0|234567|9", 9, '|', 2, true, true };
            yield return new object[] { "234567|9", "0|234567|9", 9, '|', 2, false, true };
        }
        [Theory]
        [MemberData(nameof(TestData_SubstringToChar_Occurrence))]
        public void SubstringToChar_Occurrence_Tests(object expected, string str, int startIndex, char toChar, int toCharOccurrence, bool includeChar, bool backwards)
        {
            var sut = new SubstringExp();
            var result = sut.SubstringToChar(str, startIndex, toChar, toCharOccurrence, includeChar, backwards);
            Assert.Equal(expected, result);
        }


        public static IEnumerable<object[]> TestData_SubstringToString()
        {
            // startIndex
            yield return new object[] { "0bla", "0bla234567bla9", 0, "bla", true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a234567bla", "0bla234567bla9", 3, "bla", true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "la9", "0bla234567bla9", 11, "bla", true, false, StringComparison.CurrentCultureIgnoreCase };
            // includeString
            yield return new object[] { "0", "0bla234567bla9", 0, "bla", false, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "bla234567bla9", 0, "bla", false, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a234567", "0bla234567bla9", 3, "bla", false, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "la9", "0bla234567bla9", 11, "bla", false, false, StringComparison.CurrentCultureIgnoreCase };
            // index / backwards
            yield return new object[] { "bla9", "0bla234567bla999", 13, "bla", true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bla2345", "0bla234567bla999", 7, "bla", true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "0bla2345", "0bla234567bla999", 7, "blaa", true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bla", "0bla234567bla999", 12, "bla", true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bla234567bl", "0bla234567bla999", 11, "bla", true, true, StringComparison.CurrentCultureIgnoreCase };
            // includeString / backwards
            yield return new object[] { "9", "0bla234567bla9", 13, "bla", false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "234567bl", "0bla234567bla9", 11, "bla", false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "0bla234567bla9", 3, "bla", false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "000b", "000bla234567bla9", 3, "bla", false, true, StringComparison.CurrentCultureIgnoreCase };
            // StringComparison
            yield return new object[] { "0bla", "0bla234567bla9", 0, "BLA", true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "0bla234567bla9", "0bla234567bla9", 0, "BLA", true, false, StringComparison.CurrentCulture };
        }
        [Theory]
        [MemberData(nameof(TestData_SubstringToString))]
        public void SubstringToString_Tests(object expected, string str, int startIndex, string toString, bool includeString, bool backwards, StringComparison stringComparison)
        {
            var sut = new SubstringExp();
            var result = sut.SubstringToString(str, startIndex, toString, includeString, backwards, stringComparison);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_SubstringToString_Occurrence()
        {
            // startIndex
            yield return new object[] { "0bla", "0bla234567bla9", 0, "bla", 1, true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a234567bla", "0bla234567bla9", 3, "bla", 1, true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "la9", "0bla234567bla9", 11, "bla", 1, true, false, StringComparison.CurrentCultureIgnoreCase };
            // includeString
            yield return new object[] { "0", "0bla234567bla9", 0, "bla", 1, false, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "bla234567bla9", 0, "bla", 1, false, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a234567", "0bla234567bla9", 3, "bla", 1, false, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "la9", "0bla234567bla9", 11, "bla", 1, false, false, StringComparison.CurrentCultureIgnoreCase };
            // index / backwards
            yield return new object[] { "bla9", "0bla234567bla999", 13, "bla", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bla2345", "0bla234567bla999", 7, "bla", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "0bla2345", "0bla234567bla999", 7, "blaa", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bla", "0bla234567bla999", 12, "bla", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bla234567bl", "0bla234567bla999", 11, "bla", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            // includeString / backwards
            yield return new object[] { "9", "0bla234567bla9", 13, "bla", 1, false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "234567bl", "0bla234567bla9", 11, "bla", 1, false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "0bla234567bla9", 3, "bla", 1, false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "000b", "000bla234567bla9", 3, "bla", 1, false, true, StringComparison.CurrentCultureIgnoreCase };
            // StringComparison
            yield return new object[] { "0bla", "0bla234567bla9", 0, "BLA", 1, true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "0bla234567bla9", "0bla234567bla9", 0, "BLA", 1, true, false, StringComparison.CurrentCulture };
            // toStringOccurrence
            yield return new object[] { "0bla234567bla", "0bla234567bla9", 0, "bla", 2, true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "0bla234567", "0bla234567bla9", 0, "bla", 2, false, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "0bla234567bla9", "0bla234567bla9", 0, "bla", 3, true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a234567bla9", "0bla234567bla9", 3, "bla", 2, true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bla234567bla9", "0bla234567bla9", 13, "bla", 2, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "234567bla9", "0bla234567bla9", 13, "bla", 2, false, true, StringComparison.CurrentCultureIgnoreCase };
        }
        [Theory]
        [MemberData(nameof(TestData_SubstringToString_Occurrence))]
        public void SubstringToString_Occurrence_Tests(object expected, string str, int startIndex, string toString, int toStringOccurrence, bool includeString, bool backwards, StringComparison stringComparison)
        {
            var sut = new SubstringExp();
            var result = sut.SubstringToString(str, startIndex, toString, toStringOccurrence, includeString, backwards, stringComparison);
            Assert.Equal(expected, result);
        }

    }
}
