using StringUtilities.Core.SubstringExpanded;
using Xunit;

namespace StringUtilities.UnitTests.SubstringExpandedTests
{
    public partial class SubstringExpTests
    {
        //SubstringOnStringLimits

        public static IEnumerable<object[]> TestData_SubstringOnStringLimits()
        {
            yield return new object[] { "blaa11111unx", "000blaa11111unx22222", 0, "blaa", "unx", true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "11111", "000blaa11111unx22222", 0, "blaa", "unx", true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "11111", "000blaa11111unx22222", 0, "blaa", "unx", true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "11111", "000blaa11111unx22222", 0, "blaa", "unx", false, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "blaa11111unx", "000blaa11111unx22222", 0, "BLAA", "UNX", true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "000blaa11111unx22222", 0, "BLAA", "UNX", true, true, StringComparison.CurrentCulture };
            yield return new object[] { "", "000blaa11111unx22222", 0, "BLAA", "UNX", false, true, StringComparison.CurrentCulture };
            yield return new object[] { "", "000blaa11111unx22222", 0, "blaa", "xxxx", true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "000blaa11111unx22222", 0, "xxxx", "unx", true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "blaa11111unx22222", "000blaa11111unx22222", 0, "blaa", "xxxx", false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "11111unx22222", "000blaa11111unx22222", 0, "blaa", "xxxx", false, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "000blaa11111unx", "000blaa11111unx22222", 0, "xxxx", "unx", false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "000blaa11111", "000blaa11111unx22222", 0, "xxxx", "unx", false, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "blaa11111unx", "blaa11111unx", 0, "blaa", "unx", true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "11111", "blaa11111unx", 0, "blaa", "unx", true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "blaaunx", "blaaunx", 0, "blaa", "unx", true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "blaaunx", 0, "blaa", "unx", true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bu", "bu", 0, "b", "u", true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "bu", 0, "b", "u", true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "b", "bb", 0, "b", "b", true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "bb", 0, "b", "b", true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "b", "b", 0, "b", "b", true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "b", 0, "b", "b", true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "b", "b", 0, "b", "b", false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "b", 0, "b", "b", false, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "bb", 0, "bb", "bb", false, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "unx11111blaa", "000unx11111blaa22222", 0, "blaa", "unx", true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "11111", "000unx11111blaa22222", 0, "blaa", "unx", true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "blaa", "000blaa11111blaa22222", 0, "blaa", "blaa", true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "000blaa11111blaa22222", 0, "blaa", "blaa", true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "000blaa11111blaa22222", 0, "blaa", "bla", true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bla", "000blaa11111blaa22222", 0, "blaa", "bla", true, true, StringComparison.CurrentCultureIgnoreCase };
            // startIndex
            yield return new object[] { "aa111bb", "0aa111bb3333aa55bb666bb77", 0, "aa", "bb", true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bb3333aa", "0aa111bb3333aa55bb666bb77", 2, "aa", "bb", true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "aa55bb", "0aa111bb3333aa55bb666bb77", 8, "aa", "bb", true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "6bb", "0aa111bb3333aa55bb666bb77", 20, "aa", "bb", false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "aa55bb666bb77", "0aa111bb3333aa55bb666bb77", 12, "aa", "dd", false, true, StringComparison.CurrentCultureIgnoreCase };
        }
        [Theory]
        [MemberData(nameof(TestData_SubstringOnStringLimits))]
        public void SubstringOnStringLimits_Tests(object expected, string str, int startIndex, string strLimit1, string strLimit2, bool requiresBoth, bool includeLimitStrings, StringComparison stringComparison)
        {
            var sut = new SubstringExp();
            var result = sut.SubstringOnStringLimits(str, startIndex, strLimit1, strLimit2, requiresBoth, includeLimitStrings, stringComparison);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_SubstringOnStringLimits_Occurrence()
        {
            yield return new object[] { "1234bbbbbb56", "aaa1234bbbbbb56cc", 0, "1234", 1, "56", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "1234eeeeee56", "aaa1234bbbbbb56cc ddd1234eeeeee56ff", 0, "1234", 2, "56", 2, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "56cc ddd1234", "aaa1234bbbbbb56cc ddd1234eeeeee56ff", 0, "1234", 2, "56", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "1234bbbbbb56cc ddd1234eeeeee56", "aaa1234bbbbbb56cc ddd1234eeeeee56ff", 0, "1234", 1, "56", 2, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "1234bbbbbb56cc ddd1234eeeeee56", "aaa1234bbbbbb56cc ddd1234eeeeee56ff", 0, "1234", 1, "56", 2, false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "1234eeeeee56ff", "aaa1234bbbbbb56cc ddd1234eeeeee56ff", 0, "1234", 2, "56", 3, false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "aaa1234bbbbbb56cc ddd1234eeeeee56ff", 0, "1234", 2, "56", 3, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "aaa1234bbbbbb56cc ddd1234eeeeee56ff", 0, "1234", 2, "567", 2, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "aaa1234bbbbbb56", "aaa1234bbbbbb56cc ddd1234eeeeee56ff", 0, "1234", 5, "56", 1, false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "aaa1234bbbbbb56cc ddd1234eeeeee56ff", 0, "1234", 5, "56", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bbbbbb", "aaa1234bbbbbb56cc", 0, "1234", 1, "56", 1, true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bbbbbb56cc", "aaa1234bbbbbb56cc", 0, "1234", 1, "56", 2, false, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bbbbbb", "bbbbbb", 0, "b", 1, "b", 6, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bbbb", "bbbbbb", 0, "b", 1, "b", 6, true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "bbbbbb", 0, "B", 1, "b", 6, true, false, StringComparison.CurrentCulture };
            yield return new object[] { "bbbbb", "bbbbbb", 0, "B", 1, "b", 6, false, false, StringComparison.CurrentCulture };
            yield return new object[] { "bbbb", "bbbbbb", 0, "B", 1, "B", 6, true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "ab", "ab", 0, "a", 1, "b", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "ab", 0, "a", 1, "b", 1, true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "123", "a123c", 0, "a", 1, "c", 1, true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "c123a", 0, "a", 1, "d", 1, true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "c123a", 0, "a", 1, "d", 1, false, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a", "c123a", 0, "a", 1, "d", 1, false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a123b", "a123b", 0, "a", 1, "d", 1, false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "a123b", 0, "a", 1, "d", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "123b", "a123b", 0, "a", 1, "d", 1, false, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a", "b123a", 0, "a", 1, "d", 1, false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "b123a", 0, "a", 1, "d", 1, false, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "b123a", 0, "e", 1, "d", 1, false, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "b", "bbbbb", 0, "b", 1, "b", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "bbbbb", 0, "b", 1, "b", 1, true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "aaabbbbbaaa", 0, "bb", 1, "bb", 1, true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "123blaa4567bla89", 0, "blaa", 1, "bla", 1, true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bla", "123blaa4567bla89", 0, "blaa", 1, "bla", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            // startIndex
            yield return new object[] { "bb3333aa", "0aa111bb3333aa55bb666bb77", 5, "aa", 1, "bb", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bb3333aa", "0aa111bb3333aa55bb666bb77", 5, "aa", 1, "bb", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "6bb", "0aa111bb3333aa55bb666bb77", 20, "aa", 1, "bb", 1, false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "0aa111bb3333aa55bb666bb77", 20, "aa", 1, "bb", 2, false, true, StringComparison.CurrentCultureIgnoreCase };
        }
        [Theory]
        [MemberData(nameof(TestData_SubstringOnStringLimits_Occurrence))]
        public void SubstringOnStringLimits_Occurrence_Tests(object expected, string str, int startIndex, string strLimit1, int limit1occurrence, string strLimit2, int limit2occurrence, bool requiresBoth, bool includeLimitStrings, StringComparison stringComparison)
        {
            var sut = new SubstringExp();
            var result = sut.SubstringOnStringLimits(str, startIndex, strLimit1, limit1occurrence, strLimit2, limit2occurrence, requiresBoth, includeLimitStrings, stringComparison);
            Assert.Equal(expected, result);
        }



        //SubstringBetweenStrings

        public static IEnumerable<object[]> TestData_SubstringBetweenStrings()
        {
            yield return new object[] { "blaa11111unx", "000blaa11111unx22222", 0, "blaa", "unx", true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "11111", "000blaa11111unx22222", 0, "blaa", "unx", false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "000blaa11111unx22222", 0, "xxxx", "unx", false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "000blaa11111unx22222", 0, "blaa", "xxxx", false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "blaa11111unx", "000blaa11111unx22222", 0, "BLAA", "UNX", true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "000blaa11111unx22222", 0, "BLAA", "UNX", true, StringComparison.CurrentCulture };
            yield return new object[] { "blaa11111unx", "000blaa11111unx22222", 0, "BLa", "unx", true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "000blaa11111unx22222", 0, "BLa", "unx", true, StringComparison.CurrentCulture };
            yield return new object[] { "blaa11111unx", "blaa11111unx", 0, "blaa", "unx", true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "11111", "blaa11111unx", 0, "blaa", "unx", false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "laa11111un", "blaa11111unx", 0, "b", "x", false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "blaaunx", "blaaunx", 0, "blaa", "unx", true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "blaaunx", 0, "blaa", "unx", false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bla11111bla", "000bla11111bla22222", 0, "bla", "bla", true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "b11111b", "000b11111b22222", 0, "b", "b", true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "b11111b", "b11111b", 0, "b", "b", true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bb", "bb", 0, "b", "b", true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "bb", 0, "b", "b", false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "b", 0, "b", "b", false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "b", 0, "b", "b", true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "blaa33333unx", "000blaa11111unx22222555blaa33333unx66666", 4, "blaa", "unx", true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "000blaa11111unx22222555blaa33333unx66666", 24, "blaa", "unx", true, StringComparison.CurrentCultureIgnoreCase };
        }
        [Theory]
        [MemberData(nameof(TestData_SubstringBetweenStrings))]
        public void SubstringBetweenStrings_Tests(object expected, string str, int startIndex, string openString, string closeString, bool includeLimitStrings, StringComparison stringComparison)
        {
            var sut = new SubstringExp();
            var result = sut.SubstringBetweenStrings(str, startIndex, openString, closeString, includeLimitStrings, stringComparison);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_SubstringBetweenStrings_OccurrenceConsiderNestedStructure()
        {
            /*
            "0<d>1" +
                "<d>2" +
                    "<d>3</d>4" +
                    "<d>5</d>6" +
                "</d>7" +
                "<d>8</d>9" +
            "</d>0"
            */

            // considerNestedStructures / occurrence
            yield return new object[] { "<d>2<d>3</d>", "0<d>1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9</d>0", 0, "<d>", "</d>", 2, true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "<d>2<d>3</d>4<d>5</d>6</d>", "0<d>1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9</d>0", 0, "<d>", "</d>", 2, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "<d>3</d>", "0<d>1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9</d>0", 0, "<d>", "</d>", 3, true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "<d>3</d>", "0<d>1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9</d>0", 0, "<d>", "</d>", 3, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "<d>1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9</d>", "0<d>1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9</d>0", 0, "<d>", "</d>", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            // return empty
            yield return new object[] { "", "0<d>1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9</d>0", 0, "<d>", "</d>", 6, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "0<d>1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9</d>0", 0, "bla", "</d>", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "0<d>1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9</d>0", 0, "<d>", "bla", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "0<d>1</d>2", 0, "</d>", "<d>", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            // StringComparison
            yield return new object[] { "<d>8</d>", "0<d>1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9</d>0", 0, "<D>", "</D>", 5, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "0<d>1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9</d>0", 0, "<D>", "</D>", 5, true, true, StringComparison.CurrentCulture };
            // includeLimitStrings
            yield return new object[] { "<d>8</d>", "0<d>1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9</d>0", 0, "<d>", "</d>", 5, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "8", "0<d>1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9</d>0", 0, "<d>", "</d>", 5, false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "2<d>3</d>4<d>5</d>6", "0<d>1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9</d>0", 0, "<d>", "</d>", 2, false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "2<d>3", "0<d>1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9</d>0", 0, "<d>", "</d>", 2, false, false, StringComparison.CurrentCultureIgnoreCase };
            // test at the string limits
            yield return new object[] { "<d>1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9</d>", "<d>1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9</d>", 0, "<d>", "</d>", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9", "<d>1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9</d>", 0, "<d>", "</d>", 1, false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "<d>1</d>", "<d>1</d>", 0, "<d>", "</d>", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "1", "<d>1</d>", 0, "<d>", "</d>", 1, false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "<d></d>", "<d></d>", 0, "<d>", "</d>", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "<d></d>", 0, "<d>", "</d>", 1, false, true, StringComparison.CurrentCultureIgnoreCase };
            // test same open and close
            yield return new object[] { "<d>1<d>", "0<d>1<d>2<d>3", 0, "<d>", "<d>", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "1", "0<d>1<d>2<d>3", 0, "<d>", "<d>", 1, false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bb", "bb", 0, "b", "b", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "bb", 0, "b", "b", 1, false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "<d>1<d>", "0<d>1<d>2<d>3<d>4<d>5<d>6<d>7<d>8<d>9<d>0", 0, "<d>", "<d>", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "<d>2<d>", "0<d>1<d>2<d>3<d>4<d>5<d>6<d>7<d>8<d>9<d>0", 0, "<d>", "<d>", 2, true, true, StringComparison.CurrentCultureIgnoreCase };
            // startindex
            yield return new object[] { "<d>5</d>", "0<d>1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9</d>0", 7, "<d>", "</d>", 2, true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "<d>2<d>3</d>", "0<d>1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9</d>0", 3, "<d>", "</d>", 1, true, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "<d>2<d>3</d>4<d>5</d>6</d>", "0<d>1<d>2<d>3</d>4<d>5</d>6</d>7<d>8</d>9</d>0", 3, "<d>", "</d>", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
        }
        [Theory]
        [MemberData(nameof(TestData_SubstringBetweenStrings_OccurrenceConsiderNestedStructure))]
        public void SubstringBetweenStrings_OccurrenceConsiderNestedStructure_Tests(object expected, string str, int startIndex, string openString, string closeString, int occurrence, bool includeLimitStrings, bool considerNestedStructures, StringComparison stringComparison)
        {
            var sut = new SubstringExp();
            var result = sut.SubstringBetweenStrings(str, startIndex, openString, closeString, occurrence, includeLimitStrings, considerNestedStructures, stringComparison);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_SubstringBetweenStrings_OpenCloseOccurrences()
        {
            // occurrence
            yield return new object[] { "bla111bla2222toing", "00bla111bla2222toing11bla222toing3333toing000", 0, "bla", 1, "toing", 1, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bla2222toing", "00bla111bla2222toing11bla222toing3333toing000", 0, "bla", 2, "toing", 1, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bla222toing", "00bla111bla2222toing11bla222toing3333toing000", 0, "bla", 3, "toing", 1, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bla222toing3333toing", "00bla111bla2222toing11bla222toing3333toing000", 0, "bla", 3, "toing", 2, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bla111bla2222toing11bla222toing3333toing", "00bla111bla2222toing11bla222toing3333toing000", 0, "bla", 1, "toing", 3, true, StringComparison.CurrentCultureIgnoreCase };
            // includeLimitStrings
            yield return new object[] { "111bla2222", "00bla111bla2222toing11bla222toing3333toing000", 0, "bla", 1, "toing", 1, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "2222", "00bla111bla2222toing11bla222toing3333toing000", 0, "bla", 2, "toing", 1, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "222", "00bla111bla2222toing11bla222toing3333toing000", 0, "bla", 3, "toing", 1, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "222toing3333", "00bla111bla2222toing11bla222toing3333toing000", 0, "bla", 3, "toing", 2, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "111bla2222toing11bla222toing3333", "00bla111bla2222toing11bla222toing3333toing000", 0, "bla", 1, "toing", 3, false, StringComparison.CurrentCultureIgnoreCase };
            // stringComparison
            yield return new object[] { "bla111bla2222toing", "00bla111bla2222toing11bla222toing3333toing000", 0, "BLA", 1, "Toing", 1, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "00bla111bla2222toing11bla222toing3333toing000", 0, "BLA", 1, "Toing", 1, true, StringComparison.CurrentCulture };
            // return empty
            yield return new object[] { "", "00bla111bla2222toing11bla222toing3333toing000", 0, "bla", 1, "unx", 1, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "00bla111bla2222toing11bla222toing3333toing000", 0, "unx", 1, "toing", 1, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "00bla111bla2222toing11bla222toing3333toing000", 0, "bla", 4, "toing", 1, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "00bla111bla2222toing11bla222toing3333toing000", 0, "bla", 1, "toing", 4, true, StringComparison.CurrentCultureIgnoreCase };
            // same open/close
            yield return new object[] { "bla111bla", "00bla111bla2222bla11bla222bla3333bla000", 0, "bla", 1, "bla", 1, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bla2222bla", "00bla111bla2222bla11bla222bla3333bla000", 0, "bla", 2, "bla", 1, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bla2222bla11bla", "00bla111bla2222bla11bla222bla3333bla000", 0, "bla", 2, "bla", 2, true, StringComparison.CurrentCultureIgnoreCase };
            // on the limits
            yield return new object[] { "bb", "bb", 0, "b", 1, "b", 1, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "bb", 0, "b", 1, "b", 1, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "bb", 0, "b", 2, "b", 1, true, StringComparison.CurrentCultureIgnoreCase };
            // startIndex
            yield return new object[] { "bla2222toing", "00bla111bla2222toing11bla222toing3333toing000", 5, "bla", 1, "toing", 1, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bla222toing", "00bla111bla2222toing11bla222toing3333toing000", 15, "bla", 1, "toing", 1, true, StringComparison.CurrentCultureIgnoreCase };
        }
        [Theory]
        [MemberData(nameof(TestData_SubstringBetweenStrings_OpenCloseOccurrences))]
        public void SubstringBetweenStrings_OpenCloseOccurrences_Tests(object expected, string str, int startIndex, string openString, int openStringOccurrence, string closeString, int closeStringOccurrence, bool includeLimitStrings, StringComparison stringComparison)
        {
            var sut = new SubstringExp();
            var result = sut.SubstringBetweenStrings(str, startIndex, openString, openStringOccurrence, closeString, closeStringOccurrence, includeLimitStrings, stringComparison);
            Assert.Equal(expected, result);
        }



        public static IEnumerable<object[]> TestData_SubstringBetweenStrings_OpenCloseStartEnd()
        {
            // 
            //yield return new object[] { "<p style='color:blue'> Blabla </p>", "01<p style='color:blue'> Blabla </p>12", 0, "<p", ">", "</p", ">", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            //yield return new object[] { "<div attribute='bla:tunga'> 234<div> 52</div>  4367</div>", "01<div attribute='bla:tunga'> 234<div> 52</div>  4367</div>2233", 0, "<div", ">", "</div", ">", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            //yield return new object[] { "<div> 52</div>", "01<div attribute='bla:tunga'> 234<div> 52</div>  4367</div>2233", 0, "<div", ">", "</div", ">", 2, true, true, StringComparison.CurrentCultureIgnoreCase };
            //yield return new object[] { "<div attribute='bla:tunga'> 234<div> 52</div>", "01<div attribute='bla:tunga'> 234<div> 52</div>  4367</div>2233", 0, "<div", ">", "</div", ">", 1, true, false, StringComparison.CurrentCultureIgnoreCase };
            //yield return new object[] { "111aaa552222233bbbbb777", "000111aaa552222233bbbbb777666666", 0, "111", "55", "bbbbb", "777", 1, true, false, StringComparison.CurrentCultureIgnoreCase };
            //yield return new object[] { "111aaa552222233bbbbb7776", "000111aaa552222233bbbbb777666666", 0, "111", "55", "bbbbb", "7776", 1, true, false, StringComparison.CurrentCultureIgnoreCase };
            //yield return new object[] { "<p blabla /p> xx <pp tunga /pp>", "aa<p blabla /p> xx <pp tunga /pp> bbb <p blabla /p> <pp tunga /pp> ccc", 0, "<p", "/p>", "<pp", "/pp>", 1, true, false, StringComparison.CurrentCultureIgnoreCase };
            //yield return new object[] { "<p blabla /p> xx <p blabla /p> yy <pp tunga /pp> <pp tunga /pp>", "aa<p blabla /p> xx <p blabla /p> yy <pp tunga /pp> <pp tunga /pp> bbb <p blabla /p> <pp tunga /pp> ccc", 0, "<p", "/p>", "<pp", "/pp>", 1, true, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "<p blabla /p> xx <p blabla /p>", "aa<p blabla /p> xx <p blabla /p> yy <p tunga /p> <p tunga /p> bbb <p blabla /p> <p tunga /p> ccc", 0, "<p", "/p>", "<p", "/p>", 1, true, true, StringComparison.CurrentCultureIgnoreCase };

            // includeLimitStrings
            //yield return new object[] { " Blabla ", "01<p style='color:blue'> Blabla </p>12", 0, "<p", ">", "</p", ">", 1, false, true, StringComparison.CurrentCultureIgnoreCase };
            //yield return new object[] { " 234<div> 52</div>  4367", "01<div attribute='bla:tunga'> 234<div> 52</div>  4367</div>2233", 0, "<div", ">", "</div", ">", 1, false, true, StringComparison.CurrentCultureIgnoreCase };
            //yield return new object[] { " 52", "01<div attribute='bla:tunga'> 234<div> 52</div>  4367</div>2233", 0, "<div", ">", "</div", ">", 2, false, true, StringComparison.CurrentCultureIgnoreCase };
            //yield return new object[] { " 234<div> 52", "01<div attribute='bla:tunga'> 234<div> 52</div>  4367</div>2233", 0, "<div", ">", "</div", ">", 1, false, false, StringComparison.CurrentCultureIgnoreCase };
            //yield return new object[] { "2222233", "000111aaa552222233bbbbb777666666", 0, "111", "55", "bbbbb", "777", 1, false, false, StringComparison.CurrentCultureIgnoreCase };
            //yield return new object[] { "2222233", "000111aaa552222233bbbbb777666666", 0, "111", "55", "bbbbb", "7776", 1, false, false, StringComparison.CurrentCultureIgnoreCase };
            //yield return new object[] { " xx ", "aa<p blabla /p> xx <pp tunga /pp> bbb <p blabla /p> <pp tunga /pp> ccc", 0, "<p", "/p>", "<pp", "/pp>", 1, false, false, StringComparison.CurrentCultureIgnoreCase };
            //yield return new object[] { " xx <p blabla /p> yy <pp tunga /pp> ", "aa<p blabla /p> xx <p blabla /p> yy <pp tunga /pp> <pp tunga /pp> bbb <p blabla /p> <pp tunga /pp> ccc", 0, "<p", "/p>", "<pp", "/pp>", 1, false, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { " xx ", "aa<p blabla /p> xx <p blabla /p> yy <p tunga /p> <p tunga /p> bbb <p blabla /p> <p tunga /p> ccc", 0, "<p", "/p>", "<p", "/p>", 1, false, true, StringComparison.CurrentCultureIgnoreCase };

        }
        [Theory]
        [MemberData(nameof(TestData_SubstringBetweenStrings_OpenCloseStartEnd))]
        public void SubstringBetweenStrings_OpenCloseStartEnd_Tests(object expected, string str, int startIndex, string openStartString, string closeStartString, string openEndString, string closeEndString, int occurrence, bool includeLimitStrings, bool considerNestedStructures, StringComparison stringComparison)
        {
            var sut = new SubstringExp();
            var result = sut.SubstringBetweenStrings(str, startIndex, openStartString, closeStartString, openEndString, closeEndString, occurrence, includeLimitStrings, considerNestedStructures, stringComparison);
            Assert.Equal(expected, result);
        }


    }
}
