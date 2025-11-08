using StringUtilities.Core.SubstringExpanded;
using Xunit;

namespace StringUtilities.UnitTests.SubstringExpandedTests
{
    public partial class SubstringExpTests
    {
        // -- between char --

        public static IEnumerable<object[]> TestData_SubstringBetweenCharsNextToString()
        {
            //             4               20         31     38    44              60            74     81
            var str = "000 <toing tunga=bla> la la la </toing> 111 <toing tunga=bla> bla bla bla </toing> 222";

            // basic
            yield return new object[] { "> la la la <", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, false, '>', '<', true };
            // backwards
            yield return new object[] { "</toing>", str, str.Length, "tunga", StringComparison.CurrentCultureIgnoreCase, true, '>', '<', true };
            // startIndex
            yield return new object[] { "> bla bla bla <", str, 20, "tunga", StringComparison.CurrentCultureIgnoreCase, false, '>', '<', true };
            yield return new object[] { "", str, 55, "tunga", StringComparison.CurrentCultureIgnoreCase, false, '>', '<', true };
            yield return new object[] { "</toing>", str, 60, "tunga", StringComparison.CurrentCultureIgnoreCase, true, '>', '<', true };
            yield return new object[] { "<toing tunga=bla>", str, 30, "la", StringComparison.CurrentCultureIgnoreCase, true, '>', '<', true };
            // stringComparison
            yield return new object[] { "> la la la <", str, 0, "tunga", StringComparison.CurrentCulture, false, '>', '<', true };
            yield return new object[] { "", str, 0, "TUNGA", StringComparison.CurrentCulture, false, '>', '<', true };
            yield return new object[] { "> la la la <", str, 0, "TUNGA", StringComparison.CurrentCultureIgnoreCase, false, '>', '<', true };
        }
        [Theory]
        [MemberData(nameof(TestData_SubstringBetweenCharsNextToString))]
        public void SubstringBetweenCharsNextToString_Tests(object expected, string str, int startIndex, string strReference, StringComparison strRefComparison, bool backwards, char openChar, char closeChar, bool includeLimitChars)
        {
            var sut = new SubstringExp();
            var result = sut.SubstringBetweenCharsNextToString(str, startIndex, strReference, strRefComparison, backwards, openChar, closeChar, includeLimitChars);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_SubstringBetweenCharsNextToString_RefAndLimitsOccurrence()
        {
            //             4               20         31     38    44              60            74     81
            var str = "000 <toing tunga=bla> la la la </toing> 111 <toing tunga=bla> bla bla bla </toing> 222";

            // refOccurrence
            yield return new object[] { "> la la la <", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, '>', '<', 1, true };
            yield return new object[] { "> bla bla bla <", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 2, false, '>', '<', 1, true };
            yield return new object[] { "", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 3, false, '>', '<', 1, true };
            // limitsOccurrence
            yield return new object[] { "> 111 <", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, '>', '<', 2, true };
            yield return new object[] { "> bla bla bla <", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, '>', '<', 3, true };
            yield return new object[] { "", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, '>', '<', 4, true };
            // backwards
            yield return new object[] { "</toing>", str, str.Length, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, true, '>', '<', 1, true };
            yield return new object[] { "", str, str.Length, "tunga", StringComparison.CurrentCultureIgnoreCase, 2, true, '>', '<', 1, true };
            yield return new object[] { "<toing tunga=bla>", str, str.Length, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, true, '>', '<', 2, true };
            // startIndex
            yield return new object[] { "> bla bla bla <", str, 20, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, '>', '<', 1, true };
            yield return new object[] { "", str, 55, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, '>', '<', 1, true };
            yield return new object[] { "</toing>", str, 60, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, true, '>', '<', 1, true};
            yield return new object[] { "<toing tunga=bla>", str, 30, "la", StringComparison.CurrentCultureIgnoreCase, 1, true, '>', '<', 1, true };
            // stringComparison
            yield return new object[] { "> la la la <", str, 0, "tunga", StringComparison.CurrentCulture, 1, false, '>', '<', 1, true };
            yield return new object[] { "", str, 0, "TUNGA", StringComparison.CurrentCulture, 1, false, '>', '<', 1, true };
            yield return new object[] { "> la la la <", str, 0, "TUNGA", StringComparison.CurrentCultureIgnoreCase, 1, false, '>', '<', 1, true };
        }
        [Theory]
        [MemberData(nameof(TestData_SubstringBetweenCharsNextToString_RefAndLimitsOccurrence))]
        public void SubstringBetweenCharsNextToString_RefAndLimitsOccurrence_Tests(object expected, string str, int startIndex, string strReference, StringComparison strRefComparison, int refOccurrence, bool backwards, char openChar, char closeChar, int limitsOccurrence, bool includeLimitChars)
        {
            var sut = new SubstringExp();
            var result = sut.SubstringBetweenCharsNextToString(str, startIndex, strReference, strRefComparison, refOccurrence, backwards, openChar, closeChar, limitsOccurrence, includeLimitChars);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_SubstringBetweenCharsNextToString_RefOpenAndCloseOccurrence()
        {
            //             4               20         31     38    44              60            74     81
            var str = "000 <toing tunga=bla> la la la </toing> 111 <toing tunga=bla> bla bla bla </toing> 222";

            // refOccurrence
            yield return new object[] { "> la la la <", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, '>', 1, '<', 1, true };
            yield return new object[] { "> bla bla bla <", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 2, false, '>', 1, '<', 1, true};
            yield return new object[] { "", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 3, false, '>', 1, '<', 1, true };
            // openOccurrence / closeOccurrence
            yield return new object[] { "> 111 <", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, '>', 2, '<', 1, true };
            yield return new object[] { "> 111 <toing tunga=bla> bla bla bla <", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, '>', 2, '<', 2, true };
            yield return new object[] { "> bla bla bla <", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, '>', 3, '<', 1, true};
            yield return new object[] { "", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, '>', 3, '<', 2, true };
            yield return new object[] { "", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, '>', 4, '<', 1, true };
            // backwards
            yield return new object[] { "</toing>", str, str.Length, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, true, '>', 1, '<', 1, true };
            yield return new object[] { "", str, str.Length, "tunga", StringComparison.CurrentCultureIgnoreCase, 2, true, '>', 1, '<', 1, true };
            yield return new object[] { "<toing tunga=bla>", str, str.Length, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, true, '>', 2, '<', 1, true };
            yield return new object[] { "", str, str.Length, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, true, '>', 2, '<', 2, true };
            // startIndex
            yield return new object[] { "> bla bla bla <", str, 20, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, '>', 1, '<', 1, true };
            yield return new object[] { "", str, 55, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, '>', 1, '<', 1, true };
            yield return new object[] { "</toing>", str, 60, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, true, '>', 1, '<', 1, true };
            yield return new object[] { "<toing tunga=bla>", str, 30, "la", StringComparison.CurrentCultureIgnoreCase, 1, true, '>', 1, '<', 1, true};
            // stringComparison
            yield return new object[] { "> la la la <", str, 0, "tunga", StringComparison.CurrentCulture, 1, false, '>', 1, '<', 1, true };
            yield return new object[] { "", str, 0, "TUNGA", StringComparison.CurrentCulture, 1, false, '>', 1, '<', 1, true };
            yield return new object[] { "> la la la <", str, 0, "TUNGA", StringComparison.CurrentCultureIgnoreCase, 1, false, '>', 1, '<', 1, true };
        }
        [Theory]
        [MemberData(nameof(TestData_SubstringBetweenCharsNextToString_RefOpenAndCloseOccurrence))]
        public void SubstringBetweenCharsNextToString_RefOpenAndCloseOccurrence_Tests(object expected, string str, int startIndex, string strReference, StringComparison strRefComparison, int strRefOccurrence, bool backwards, char openChar, int openOccurrence, char closeChar, int closeOccurrence, bool includeLimitChars)
        {
            var sut = new SubstringExp();
            var result = sut.SubstringBetweenCharsNextToString(str, startIndex, strReference, strRefComparison, strRefOccurrence, backwards, openChar, openOccurrence, closeChar, closeOccurrence, includeLimitChars);
            Assert.Equal(expected, result);
        }


        public static IEnumerable<object[]> TestData_SubstringAllBetweenCharsNextToString()
        {
            //             4               20         31     38    44              60            74     81
            var str = "000 <toing tunga=bla> la la la </toing> 111 <toing tunga=bla> bla bla bla </toing> 222";

            // basic
            yield return new object[] { new string[] { "> la la la <", "> bla bla bla <" }, str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, false, '>', '<', true };
            // backwards
            yield return new object[] { new string[] { "</toing>" }, str, str.Length, "tunga", StringComparison.CurrentCultureIgnoreCase, true, '>', '<', true };
            // startIndex
            yield return new object[] { new string[] { "> bla bla bla <" }, str, 20, "tunga", StringComparison.CurrentCultureIgnoreCase, false, '>', '<', true };
            yield return new object[] { new string[] { }, str, 55, "tunga", StringComparison.CurrentCultureIgnoreCase, false, '>', '<', true };
            yield return new object[] { new string[] { "</toing>" }, str, 60, "tunga", StringComparison.CurrentCultureIgnoreCase, true, '>', '<', true };
            yield return new object[] { new string[] { "<toing tunga=bla>" }, str, 30, "la", StringComparison.CurrentCultureIgnoreCase, true, '>', '<', true };
            // stringComparison
            yield return new object[] { new string[] { "> la la la <", "> bla bla bla <" }, str, 0, "tunga", StringComparison.CurrentCulture, false, '>', '<', true};
            yield return new object[] { new string[] { }, str, 0, "TUNGA", StringComparison.CurrentCulture, false, '>', '<', true };
            yield return new object[] { new string[] { "> la la la <", "> bla bla bla <" }, str, 0, "TUNGA", StringComparison.CurrentCultureIgnoreCase, false, '>', '<', true };
        }
        [Theory]
        [MemberData(nameof(TestData_SubstringAllBetweenCharsNextToString))]
        public void SubstringAllBetweenCharsNextToString_Tests(object expected, string str, int startIndex, string strReference, StringComparison strRefComparison, bool backwards, char openChar, char closeChar, bool includeLimitChars)
        {
            var sut = new SubstringExp();
            var result = sut.SubstringAllBetweenCharsNextToString(str, startIndex, strReference, strRefComparison, backwards, openChar, closeChar, includeLimitChars);
            Assert.Equal(expected, result);
        }





        // -- between string --

        public static IEnumerable<object[]> TestData_SubstringBetweenStringsNextToString()
        {
            var str = "000 <<toing tunga=bla>> la la la <</toing>> 111 <<toing tunga=bla>> bla bla bla <</toing>> 222";

            // basic
            yield return new object[] { ">> la la la <<", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, false, ">>", "<<", true };
            // backwards
            yield return new object[] { "<</toing>>", str, str.Length, "tunga", StringComparison.CurrentCultureIgnoreCase, true, ">>", "<<", true };
            // startIndex
            yield return new object[] { ">> bla bla bla <<", str, 20, "tunga", StringComparison.CurrentCultureIgnoreCase, false, ">>", "<<", true };
            yield return new object[] { "", str, 60, "tunga", StringComparison.CurrentCultureIgnoreCase, false, ">>", "<<", true };
            yield return new object[] { "<</toing>>", str, 60, "tunga", StringComparison.CurrentCultureIgnoreCase, true, ">>", "<<", true };
            yield return new object[] { "<<toing tunga=bla>>", str, 25, "la", StringComparison.CurrentCultureIgnoreCase, true, ">>", "<<", true };
            // stringComparison
            yield return new object[] { ">> la la la <<", str, 0, "tunga", StringComparison.CurrentCulture, false, ">>", "<<", true };
            yield return new object[] { "", str, 0, "TUNGA", StringComparison.CurrentCulture, false, ">>", "<<", true };
            yield return new object[] { ">> la la la <<", str, 0, "TUNGA", StringComparison.CurrentCultureIgnoreCase, false, ">>", "<<", true };
        }
        [Theory]
        [MemberData(nameof(TestData_SubstringBetweenStringsNextToString))]
        public void SubstringBetweenStringsNextToString_Tests(object expected, string str, int startIndex, string strReference, StringComparison strRefComparison, bool backwards, string openString, string closeString, bool includeLimitStrings)
        {
            var sut = new SubstringExp();
            var result = sut.SubstringBetweenStringsNextToString(str, startIndex, strReference, strRefComparison, backwards, openString, closeString, includeLimitStrings);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_SubstringBetweenStringsNextToString_RefAndLimitsOccurrence()
        {
            var str = "000 <<toing tunga=bla>> la la la <</toing>> 111 <<toing tunga=bla>> bla bla bla <</toing>> 222";

            // refOccurrence
            yield return new object[] { ">> la la la <<", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, ">>", "<<", 1, true };
            yield return new object[] { ">> bla bla bla <<", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 2, false, ">>", "<<", 1, true };
            yield return new object[] { "", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 3, false, ">>", "<<", 1, true };
            // limitsOccurrence
            yield return new object[] { ">> 111 <<", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, ">>", "<<", 2, true };
            yield return new object[] { ">> bla bla bla <<", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, ">>", "<<", 3, true };
            yield return new object[] { "", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, ">>", "<<", 4, true };
            // backwards
            yield return new object[] { "<</toing>>", str, str.Length, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, true, ">>", "<<", 1, true };
            yield return new object[] { "", str, str.Length, "tunga", StringComparison.CurrentCultureIgnoreCase, 2, true, ">>", "<<", 1, true };
            yield return new object[] { "<<toing tunga=bla>>", str, str.Length, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, true, ">>", "<<", 2, true };
            // startIndex
            yield return new object[] { ">> bla bla bla <<", str, 20, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, ">>", "<<", 1, true };
            yield return new object[] { "", str, 60, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, ">>", "<<", 1, true };
            yield return new object[] { "<</toing>>", str, 60, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, true, ">>", "<<", 1, true };
            yield return new object[] { "<<toing tunga=bla>>", str, 25, "la", StringComparison.CurrentCultureIgnoreCase, 1, true, ">>", "<<", 1, true };
            // stringComparison
            yield return new object[] { ">> la la la <<", str, 0, "tunga", StringComparison.CurrentCulture, 1, false, ">>", "<<", 1, true };
            yield return new object[] { "", str, 0, "TUNGA", StringComparison.CurrentCulture, 1, false, ">>", "<<", 1, true };
            yield return new object[] { ">> la la la <<", str, 0, "TUNGA", StringComparison.CurrentCultureIgnoreCase, 1, false, ">>", "<<", 1, true };
        }
        [Theory]
        [MemberData(nameof(TestData_SubstringBetweenStringsNextToString_RefAndLimitsOccurrence))]
        public void SubstringBetweenStringsNextToString_RefAndLimitsOccurrence_Tests(object expected, string str, int startIndex, string strReference, StringComparison strRefComparison, int refOccurrence, bool backwards, string openString, string closeString, int limitsOccurrence, bool includeLimitStrings)
        {
            var sut = new SubstringExp();
            var result = sut.SubstringBetweenStringsNextToString(str, startIndex, strReference, strRefComparison, refOccurrence,  backwards, openString, closeString, limitsOccurrence, includeLimitStrings);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_SubstringBetweenStringsNextToString_RefOpenAndCloseOccurrence()
        {
            var str = "000 <<toing tunga=bla>> la la la <</toing>> 111 <<toing tunga=bla>> bla bla bla <</toing>> 222";

            // refOccurrence
            yield return new object[] { ">> la la la <<", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, ">>", 1, "<<", 1, true };
            yield return new object[] { ">> bla bla bla <<", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 2, false, ">>", 1, "<<", 1, true };
            yield return new object[] { "", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 3, false, ">>", 1, "<<", 1, true };
            // openOccurrence / closeOccurrence
            yield return new object[] { ">> 111 <<", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, ">>", 2, "<<", 1, true };
            yield return new object[] { ">> la la la <</toing>> 111 <<", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, ">>", 1, "<<", 2, true };
            yield return new object[] { ">> la la la <</toing>> 111 <<toing tunga=bla>> bla bla bla <<", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, ">>", 1, "<<", 3, true };
            yield return new object[] { "", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, ">>", 1, "<<", 4, true };
            yield return new object[] { ">> bla bla bla <<", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, ">>", 3, "<<", 1, true };
            yield return new object[] { "", str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, ">>", 4, "<<", 1, true };
            // backwards
            yield return new object[] { "<</toing>>", str, str.Length, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, true, ">>", 1, "<<", 1, true };
            yield return new object[] { "", str, str.Length, "tunga", StringComparison.CurrentCultureIgnoreCase, 2, true, ">>", 1, "<<", 1, true };
            yield return new object[] { "<<toing tunga=bla>>", str, str.Length, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, true, ">>", 2, "<<", 1, true };
            // startIndex
            yield return new object[] { ">> bla bla bla <<", str, 20, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, ">>", 1, "<<", 1, true };
            yield return new object[] { "", str, 60, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, false, ">>", 1, "<<", 1, true };
            yield return new object[] { "<</toing>>", str, 60, "tunga", StringComparison.CurrentCultureIgnoreCase, 1, true, ">>", 1, "<<", 1, true };
            yield return new object[] { "<<toing tunga=bla>>", str, 25, "la", StringComparison.CurrentCultureIgnoreCase, 1, true, ">>", 1, "<<", 1, true };
            // stringComparison
            yield return new object[] { ">> la la la <<", str, 0, "tunga", StringComparison.CurrentCulture, 1, false, ">>", 1, "<<", 1, true };
            yield return new object[] { "", str, 0, "TUNGA", StringComparison.CurrentCulture, 1, false, ">>", 1, "<<", 1, true };
            yield return new object[] { ">> la la la <<", str, 0, "TUNGA", StringComparison.CurrentCultureIgnoreCase, 1, false, ">>", 1, "<<", 1, true };
        }
        [Theory]
        [MemberData(nameof(TestData_SubstringBetweenStringsNextToString_RefOpenAndCloseOccurrence))]
        public void SubstringBetweenStringsNextToString_RefOpenAndCloseOccurrence_Tests(object expected, string str, int startIndex, string strReference, StringComparison strRefComparison, int refOccurrence, bool backwards, string openString, int openOccurrence, string closeString, int closeOccurrence, bool includeLimitStrings)
        {
            var sut = new SubstringExp();
            var result = sut.SubstringBetweenStringsNextToString(str, startIndex, strReference, strRefComparison, refOccurrence,backwards, openString, openOccurrence, closeString, closeOccurrence, includeLimitStrings);
            Assert.Equal(expected, result);
        }


        public static IEnumerable<object[]> TestData_SubstringAllBetweenStringsNextToString()
        {
            var str = "000 <<toing tunga=bla>> la la la <</toing>> 111 <<toing tunga=bla>> bla bla bla <</toing>> 222";

            // basic
            yield return new object[] { new string[] { ">> la la la <<", ">> bla bla bla <<" }, str, 0, "tunga", StringComparison.CurrentCultureIgnoreCase, false, ">>", "<<", true };
            // backwards
            yield return new object[] { new string[] { "<</toing>>" }, str, str.Length, "tunga", StringComparison.CurrentCultureIgnoreCase, true, ">>", "<<", true };
            // startIndex
            yield return new object[] { new string[] { ">> bla bla bla <<" }, str, 20, "tunga", StringComparison.CurrentCultureIgnoreCase, false, ">>", "<<", true };
            yield return new object[] { new string[] { }, str, 60, "tunga", StringComparison.CurrentCultureIgnoreCase, false, ">>", "<<", true };
            yield return new object[] { new string[] { "<</toing>>" }, str, 60, "tunga", StringComparison.CurrentCultureIgnoreCase, true, ">>", "<<", true };
            yield return new object[] { new string[] { "<<toing tunga=bla>>" }, str, 25, "la", StringComparison.CurrentCultureIgnoreCase, true, ">>", "<<", true };
            // stringComparison
            yield return new object[] { new string[] { ">> la la la <<", ">> bla bla bla <<" }, str, 0, "tunga", StringComparison.CurrentCulture, false, ">>", "<<", true };
            yield return new object[] { new string[] { }, str, 0, "TUNGA", StringComparison.CurrentCulture, false, ">>", "<<", true };
            yield return new object[] { new string[] { ">> la la la <<", ">> bla bla bla <<" }, str, 0, "TUNGA", StringComparison.CurrentCultureIgnoreCase, false, ">>", "<<", true };
        }
        [Theory]
        [MemberData(nameof(TestData_SubstringAllBetweenStringsNextToString))]
        public void SubstringAllBetweenStringsNextToString_Tests(object expected, string str, int startIndex, string strReference, StringComparison strRefComparison, bool backwards, string openString, string closeString, bool includeLimitStrings)
        {
            var sut = new SubstringExp();
            var result = sut.SubstringAllBetweenStringsNextToString(str, startIndex, strReference, strRefComparison, backwards, openString, closeString, includeLimitStrings);
            Assert.Equal(expected, result);
        }



    }
}
