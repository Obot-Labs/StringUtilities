using StringUtilities.Core.RemoveExpanded;
using Xunit;

namespace StringUtilities.UnitTests.RemoveStringTests
{
    public partial class RemoveExpTests
    {
        // TestData / Test _ Method Name _ Overload distinction

        public static IEnumerable<object[]> TestData_RemoveBetweenStrings()
        {
            var str = "a1 <O-- b12 -C> c123 <O-- d1234 -C> e12345";
            // startIndex
            yield return new object[] { "a1  c123  e12345", str, 0, "<O--", "-C>", false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a1 <O-- b12 -C> c123  e12345", str, 5, "<O--", "-C>", false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { str, str, 25, "<O--", "-C>", false, StringComparison.CurrentCultureIgnoreCase };
            // StringComparison
            yield return new object[] { "a1  c123  e12345", str, 0, "<O--", "-C>", false, StringComparison.CurrentCulture };
            yield return new object[] { str, str, 0, "<o--", "-C>", false, StringComparison.CurrentCulture };
            yield return new object[] { str, str, 0, "<O--", "-c>", false, StringComparison.CurrentCulture };
            // on the limits
            yield return new object[] { " c123 ", "<O-- b12 -C> c123 <O-- d1234 -C><O-- d1234 -C>", 0, "<O--", "-C>", false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "<O-- b12 -C><O-- d1234 -C><O-- d1234 -C>", 0, "<O--", "-C>", false, StringComparison.CurrentCultureIgnoreCase };
            // same open close
            yield return new object[] { " c123 ", "<O-- b12 <O-- c123 <O-- d1234 <O--<O-- d1234 <O--", 0, "<O--", "<O--", false, StringComparison.CurrentCultureIgnoreCase };
            // considerNestedStructures
            yield return new object[] { "a1  c123  -C> e12345", "a1 <O-- b12 -C> c123 <O-- d1234 <O-- d1234 -C> -C> e12345", 0, "<O--", "-C>", false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a1  c123  e12345", "a1 <O-- b12 -C> c123 <O-- d1234 <O-- d1234 -C> -C> e12345", 0, "<O--", "-C>", true, StringComparison.CurrentCultureIgnoreCase };
        }
        [Theory]
        [MemberData(nameof(TestData_RemoveBetweenStrings))]
        public void Test_RemoveBetweenStrings(object expected, string str, int startIndex, string openString, string closeString, bool considerNestedStructures, StringComparison stringComparison)
        {
            var sut = new RemoveExp();
            var result = sut.RemoveBetweenStrings(str, startIndex, openString, closeString, considerNestedStructures, stringComparison);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_RemoveBetweenStrings_Func()
        {
            var str = "a1 <O-- b12 -C> c123 <O-- d1234 -C> e12345";
            // startIndex
            yield return new object[] { "a1  c123  e12345", str, 0, "<O--", "-C>", false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a1 <O-- b12 -C> c123  e12345", str, 5, "<O--", "-C>", false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { str, str, 25, "<O--", "-C>", false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            // StringComparison
            yield return new object[] { "a1  c123  e12345", str, 0, "<O--", "-C>", false, (string strToRemove) => true, StringComparison.CurrentCulture };
            yield return new object[] { str, str, 0, "<o--", "-C>", false, (string strToRemove) => true, StringComparison.CurrentCulture };
            yield return new object[] { str, str, 0, "<O--", "-c>", false, (string strToRemove) => true, StringComparison.CurrentCulture };
            // on the limits
            yield return new object[] { " c123 ", "<O-- b12 -C> c123 <O-- d1234 -C><O-- d1234 -C>", 0, "<O--", "-C>", false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "<O-- b12 -C><O-- d1234 -C><O-- d1234 -C>", 0, "<O--", "-C>", false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            // same open close
            yield return new object[] { " c123 ", "<O-- b12 <O-- c123 <O-- d1234 <O--<O-- d1234 <O--", 0, "<O--", "<O--", false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            // considerNestedStructures
            yield return new object[] { "a1  c123  -C> e12345", "a1 <O-- b12 -C> c123 <O-- d1234 <O-- d1234 -C> -C> e12345", 0, "<O--", "-C>", false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a1  c123  e12345", "a1 <O-- b12 -C> c123 <O-- d1234 <O-- d1234 -C> -C> e12345", 0, "<O--", "-C>", true, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            // substringConditionToRemove
            yield return new object[] { "a1  c123  e12345", str, 0, "<O--", "-C>", false, (string strToRemove) => strToRemove.EndsWith("-C>"), StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a1  c123  e12345", str, 0, "<O--", "-C>", false, (string strToRemove) => strToRemove.StartsWith("<O--"), StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a1  c123 <O-- d1234 -C> e12345", str, 0, "<O--", "-C>", false, (string strToRemove) => strToRemove.Contains("b12"), StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a1 <O-- b12 -C> c123  e12345", str, 0, "<O--", "-C>", false, (string strToRemove) => strToRemove.Contains("d1234"), StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { str, str, 0, "<O--", "-C>", false, (string strToRemove) => strToRemove.Length > 200, StringComparison.CurrentCultureIgnoreCase };
        }
        [Theory]
        [MemberData(nameof(TestData_RemoveBetweenStrings_Func))]
        public void Test_RemoveBetweenStrings_Func(object expected, string str, int startIndex, string openString, string closeString, bool considerNestedStructures, Func<string, bool> substringConditionToRemove, StringComparison stringComparison)
        {
            var sut = new RemoveExp();
            var result = sut.RemoveBetweenStrings(str, startIndex, openString, closeString, considerNestedStructures, substringConditionToRemove, stringComparison);
            Assert.Equal(expected, result);
        }


        public static IEnumerable<object[]> TestData_RemoveBetweenStrings_Occurrence()
        {
            var str = "a1 <O-- b12 -C> c123 <O-- d1234 -C> e12345";
            // occurrence
            yield return new object[] { "a1  c123 <O-- d1234 -C> e12345", str, 0, "<O--", "-C>", 1, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a1 <O-- b12 -C> c123  e12345", str, 0, "<O--", "-C>", 2, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { str, str, 0, "<O--", "-C>", 3, false, StringComparison.CurrentCultureIgnoreCase };
            // startIndex
            yield return new object[] { "a1 <O-- b12 -C> c123  e12345", str, 5, "<O--", "-C>", 1, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { str, str, 25, "<O--", "-C>", 1, false, StringComparison.CurrentCultureIgnoreCase };
            // StringComparison
            yield return new object[] { "a1  c123 <O-- d1234 -C> e12345", str, 0, "<O--", "-C>", 1, false, StringComparison.CurrentCulture };
            yield return new object[] { str, str, 0, "<o--", "-C>", 1, false, StringComparison.CurrentCulture };
            yield return new object[] { str, str, 0, "<O--", "-c>", 1, false, StringComparison.CurrentCulture };
            // on the limits
            yield return new object[] { " c123 <O-- d1234 -C>", "<O-- b12 -C> c123 <O-- d1234 -C>", 0, "<O--", "-C>", 1, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "<O-- b12 -C> c123 ", "<O-- b12 -C> c123 <O-- d1234 -C>", 0, "<O--", "-C>", 2, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "<O-- d1234 -C>", 0, "<O--", "-C>", 1, false, StringComparison.CurrentCultureIgnoreCase };
            // same open close
            yield return new object[] { "a1  c123 <O-- d1234 <O-- e12345", "a1 <O-- b12 <O-- c123 <O-- d1234 <O-- e12345", 0, "<O--", "<O--", 1, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a1 <O-- b12  d1234 <O-- e12345", "a1 <O-- b12 <O-- c123 <O-- d1234 <O-- e12345", 0, "<O--", "<O--", 2, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a1 <O-- b12 <O-- c123  e12345", "a1 <O-- b12 <O-- c123 <O-- d1234 <O-- e12345", 0, "<O--", "<O--", 3, false, StringComparison.CurrentCultureIgnoreCase };
            // considerNestedStructures
            str = "a1  c123 <O-- d12 <O-- d1234 -C> 34 -C> e12345";
            yield return new object[] { "a1  c123  34 -C> e12345", str, 0, "<O--", "-C>", 1, false, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a1  c123  e12345", str, 0, "<O--", "-C>", 1, true, StringComparison.CurrentCultureIgnoreCase };
            str = "0123456789 <!-- 0123456789 <!-- 0123456789 --> bla --> 0123456789";
            yield return new object[] { "0123456789  0123456789", str, 0, "<!--", "-->", 1, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "0123456789 <!-- 0123456789  bla --> 0123456789", str, 0, "<!--", "-->", 2, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { " 0123456789", "<!-- 0123456789 <!-- 0123456789 --> bla --> 0123456789", 0, "<!--", "-->", 1, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "0123456789 ", "0123456789 <!-- 0123456789 <!-- 0123456789 --> bla -->", 0, "<!--", "-->", 1, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "0123456789  bla -->", "0123456789 <!-- 0123456789 <!-- 0123456789 --> bla -->", 0, "<!--", "-->", 1, false, StringComparison.CurrentCultureIgnoreCase };
        }
        [Theory]
        [MemberData(nameof(TestData_RemoveBetweenStrings_Occurrence))]
        public void Test_RemoveBetweenStrings_Occurrence(object expected, string str, int startIndex, string openString, string closeString, int occurrence, bool considerNestedStructures, StringComparison stringComparison)
        {
            var sut = new RemoveExp();
            var result = sut.RemoveBetweenStrings(str, startIndex, openString, closeString, occurrence, considerNestedStructures, stringComparison);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_RemoveBetweenStrings_OccurrenceFunc()
        {
            var str = "a1 <O-- b12 -C> c123 <O-- d1234 -C> e12345";
            // occurrence
            yield return new object[] { "a1  c123 <O-- d1234 -C> e12345", str, 0, "<O--", "-C>", 1, false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a1 <O-- b12 -C> c123  e12345", str, 0, "<O--", "-C>", 2, false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { str, str, 0, "<O--", "-C>", 3, false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            // startIndex
            yield return new object[] { "a1 <O-- b12 -C> c123  e12345", str, 5, "<O--", "-C>", 1, false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { str, str, 25, "<O--", "-C>", 1, false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            // StringComparison
            yield return new object[] { "a1  c123 <O-- d1234 -C> e12345", str, 0, "<O--", "-C>", 1, false, (string strToRemove) => true, StringComparison.CurrentCulture };
            yield return new object[] { str, str, 0, "<o--", "-C>", 1, false, (string strToRemove) => true, StringComparison.CurrentCulture };
            yield return new object[] { str, str, 0, "<O--", "-c>", 1, false, (string strToRemove) => true, StringComparison.CurrentCulture };
            // on the limits
            yield return new object[] { " c123 <O-- d1234 -C>", "<O-- b12 -C> c123 <O-- d1234 -C>", 0, "<O--", "-C>", 1, false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "<O-- b12 -C> c123 ", "<O-- b12 -C> c123 <O-- d1234 -C>", 0, "<O--", "-C>", 2, false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "<O-- d1234 -C>", 0, "<O--", "-C>", 1, false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            // same open close
            yield return new object[] { "a1  c123 <O-- d1234 <O-- e12345", "a1 <O-- b12 <O-- c123 <O-- d1234 <O-- e12345", 0, "<O--", "<O--", 1, false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a1 <O-- b12  d1234 <O-- e12345", "a1 <O-- b12 <O-- c123 <O-- d1234 <O-- e12345", 0, "<O--", "<O--", 2, false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a1 <O-- b12 <O-- c123  e12345", "a1 <O-- b12 <O-- c123 <O-- d1234 <O-- e12345", 0, "<O--", "<O--", 3, false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            // considerNestedStructures
            str = "a1  c123 <O-- d12 <O-- d1234 -C> 34 -C> e12345";
            yield return new object[] { "a1  c123  34 -C> e12345", str, 0, "<O--", "-C>", 1, false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "a1  c123  e12345", str, 0, "<O--", "-C>", 1, true, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            str = "0123456789 <!-- 0123456789 <!-- 0123456789 --> bla --> 0123456789";
            yield return new object[] { "0123456789  0123456789", str, 0, "<!--", "-->", 1, true, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "0123456789 <!-- 0123456789  bla --> 0123456789", str, 0, "<!--", "-->", 2, true, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { " 0123456789", "<!-- 0123456789 <!-- 0123456789 --> bla --> 0123456789", 0, "<!--", "-->", 1, true, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "0123456789 ", "0123456789 <!-- 0123456789 <!-- 0123456789 --> bla -->", 0, "<!--", "-->", 1, true, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "0123456789  bla -->", "0123456789 <!-- 0123456789 <!-- 0123456789 --> bla -->", 0, "<!--", "-->", 1, false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            //// substringConditionToRemove
            str = "0123456789 <!-- 0123456789 <!-- 0123456789 --> bla --> 0123456789";
            yield return new object[] { "0123456789  0123456789", str, 0, "<!--", "-->", 1, true, (string toRemove) => toRemove.Contains("bla"), StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { str, str, 0, "<!--", "-->", 1, true, (string toRemove) => toRemove.Contains("unx"), StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "0123456789  0123456789", str, 0, "<!--", "-->", 1, true, (string toRemove) => toRemove.Length > 5, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { str, str, 0, "<!--", "-->", 1, true, (string toRemove) => toRemove.Length > 200, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "0123456789  0123456789", str, 0, "<!--", "-->", 1, true, (string toRemove) => toRemove.StartsWith("<!--"), StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "0123456789  0123456789", str, 0, "<!--", "-->", 1, true, (string toRemove) => toRemove.EndsWith("-->"), StringComparison.CurrentCultureIgnoreCase };
        }
        [Theory]
        [MemberData(nameof(TestData_RemoveBetweenStrings_OccurrenceFunc))]
        public void Test_RemoveBetweenStrings_OccurrenceFunc(object expected, string str, int startIndex, string openString, string closeString, int occurrence, bool considerNestedStructures, Func<string, bool> substringConditionToRemove, StringComparison stringComparison)
        {
            var sut = new RemoveExp();
            var result = sut.RemoveBetweenStrings(str, startIndex, openString, closeString, occurrence, considerNestedStructures, substringConditionToRemove, stringComparison);
            
            Assert.Equal(expected, result);
        }


        public static IEnumerable<object[]> TestData_RemoveBetweenStrings_StartEndOccurrence()
        {
            // pretty str:
            //    "starting " +
            //    "<div attribute='bla:tunga'>" +
            //        "<p style='color:white'> This is a paragraph </p> " +
            //        "<div class='bla'> tunga" +
            //            "<div id='unx'>" +
            //                "<img src='tunga' />" +
            //            "</div> 1234" +
            //        "</div> 567" +
            //        "<div>" +
            //            "<p style='color:white'> This is another paragraph </p> " +
            //        "</div>" +
            //    "</div>" +
            //    " ending";

            var str = "starting <div attribute='bla:tunga'><p style='color:white'> This is a paragraph </p> <div class='bla'> tunga<div id='unx'><img src='tunga' /></div> 1234</div> 567<div><p style='color:white'> This is another paragraph </p> </div></div> ending";

            // occurrence | considerNestedStructures true
            var expected = "starting  ending";
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 1, true, StringComparison.CurrentCultureIgnoreCase };
            expected = "starting <div attribute='bla:tunga'><p style='color:white'> This is a paragraph </p>  567<div><p style='color:white'> This is another paragraph </p> </div></div> ending";
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 2, true, StringComparison.CurrentCultureIgnoreCase };
            expected = "starting <div attribute='bla:tunga'><p style='color:white'> This is a paragraph </p> <div class='bla'> tunga 1234</div> 567<div><p style='color:white'> This is another paragraph </p> </div></div> ending";
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 3, true, StringComparison.CurrentCultureIgnoreCase };
            expected = "starting <div attribute='bla:tunga'><p style='color:white'> This is a paragraph </p> <div class='bla'> tunga<div id='unx'><img src='tunga' /></div> 1234</div> 567</div> ending";
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 4, true, StringComparison.CurrentCultureIgnoreCase };
            expected = str;
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 5, true, StringComparison.CurrentCultureIgnoreCase };
            // occurrence | considerNestedStructures false
            expected = "starting  1234</div> 567<div><p style='color:white'> This is another paragraph </p> </div></div> ending";
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 1, false, StringComparison.CurrentCultureIgnoreCase };
            expected = "starting <div attribute='bla:tunga'><p style='color:white'> This is a paragraph </p>  1234</div> 567<div><p style='color:white'> This is another paragraph </p> </div></div> ending";
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 2, false, StringComparison.CurrentCultureIgnoreCase };
            expected = "starting <div attribute='bla:tunga'><p style='color:white'> This is a paragraph </p> <div class='bla'> tunga 1234</div> 567<div><p style='color:white'> This is another paragraph </p> </div></div> ending";
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 3, false, StringComparison.CurrentCultureIgnoreCase };
            expected = "starting <div attribute='bla:tunga'><p style='color:white'> This is a paragraph </p> <div class='bla'> tunga<div id='unx'><img src='tunga' /></div> 1234</div> 567</div> ending";
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 4, false, StringComparison.CurrentCultureIgnoreCase };
            expected = str;
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 5, false, StringComparison.CurrentCultureIgnoreCase };
            //startIndex
            expected = "starting <div attribute='bla:tunga'><p style='color:white'> This is a paragraph </p>  567<div><p style='color:white'> This is another paragraph </p> </div></div> ending";
            yield return new object[] { expected, str, 10, "<div", ">", "</div", ">", 1, true, StringComparison.CurrentCultureIgnoreCase };
            expected = "starting <div attribute='bla:tunga'><p style='color:white'> This is a paragraph </p>  1234</div> 567<div><p style='color:white'> This is another paragraph </p> </div></div> ending";
            yield return new object[] { expected, str, 10, "<div", ">", "</div", ">", 1, false, StringComparison.CurrentCultureIgnoreCase };
            expected = str;
            yield return new object[] { expected, str, str.Length, "<div", ">", "</div", ">", 1, true, StringComparison.CurrentCultureIgnoreCase };
            // StringComparison
            expected = "starting  ending";
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 1, true, StringComparison.CurrentCulture };
            expected = "starting  ending";
            yield return new object[] { expected, str, 0, "<DIV", ">", "</DIV", ">", 1, true, StringComparison.CurrentCultureIgnoreCase };
            expected = str;
            yield return new object[] { expected, str, 0, "<DIV", ">", "</DIV", ">", 1, true, StringComparison.CurrentCulture };
            
            // on the limits
            yield return new object[] { "", "bla 123 toing 456 lala 789 unxunx", 0, "bla", "toing", "lala", "unxunx", 1, true, StringComparison.CurrentCultureIgnoreCase };
            // same open close
            yield return new object[] { "aaa  bbb bla 123 toing 456 bla 789 toing ccc", "aaa bla 123 toing 456 bla 789 toing bbb bla 123 toing 456 bla 789 toing ccc", 0, "bla", "toing", "bla", "toing", 1, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "aaa bla 123 toing 456  456 bla 789 toing ccc", "aaa bla 123 toing 456 bla 789 toing bbb bla 123 toing 456 bla 789 toing ccc", 0, "bla", "toing", "bla", "toing", 2, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "aaa  bbb bla 123 bla 456 bla 789 bla ccc", "aaa bla 123 bla 456 bla 789 bla bbb bla 123 bla 456 bla 789 bla ccc", 0, "bla", "bla", "bla", "bla", 1, true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "aaa bla 123  123 bla 456 bla 789 bla ccc", "aaa bla 123 bla 456 bla 789 bla bbb bla 123 bla 456 bla 789 bla ccc", 0, "bla", "bla", "bla", "bla", 2, true, StringComparison.CurrentCultureIgnoreCase };
        }
        [Theory]
        [MemberData(nameof(TestData_RemoveBetweenStrings_StartEndOccurrence))]
        public void Test_RemoveBetweenStrings_StartEndOccurrence(object expected, string str, int startIndex, string startOpenString, string endOpenString, string startCloseString, string endCloseString, int occurrence, bool considerNestedStructures, StringComparison stringComparison)
        {
            var sut = new RemoveExp();
            var result = sut.RemoveBetweenStrings(str, startIndex, startOpenString, endOpenString, startCloseString, endCloseString, occurrence, considerNestedStructures, stringComparison);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData_RemoveBetweenStrings_StartEndOccurrenceNestedFunc()
        {
            // pretty str:
            //    "starting " +
            //    "<div attribute='bla:tunga'>" +
            //        "<p style='color:white'> This is a paragraph </p> " +
            //        "<div class='bla'> tunga" +
            //            "<div id='unx'>" +
            //                "<img src='tunga' />" +
            //            "</div> 1234" +
            //        "</div> 567" +
            //        "<div>" +
            //            "<p style='color:white'> This is another paragraph </p> " +
            //        "</div>" +
            //    "</div>" +
            //    " ending";

            var str = "starting <div attribute='bla:tunga'><p style='color:white'> This is a paragraph </p> <div class='bla'> tunga<div id='unx'><img src='tunga' /></div> 1234</div> 567<div><p style='color:white'> This is another paragraph </p> </div></div> ending";

            // occurrence | considerNestedStructures true
            var expected = "starting  ending";
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 1, true, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            expected = "starting <div attribute='bla:tunga'><p style='color:white'> This is a paragraph </p>  567<div><p style='color:white'> This is another paragraph </p> </div></div> ending";
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 2, true, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            expected = "starting <div attribute='bla:tunga'><p style='color:white'> This is a paragraph </p> <div class='bla'> tunga 1234</div> 567<div><p style='color:white'> This is another paragraph </p> </div></div> ending";
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 3, true, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            expected = "starting <div attribute='bla:tunga'><p style='color:white'> This is a paragraph </p> <div class='bla'> tunga<div id='unx'><img src='tunga' /></div> 1234</div> 567</div> ending";
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 4, true, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            expected = str;
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 5, true, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            // occurrence | considerNestedStructures false
            expected = "starting  1234</div> 567<div><p style='color:white'> This is another paragraph </p> </div></div> ending";
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 1, false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            expected = "starting <div attribute='bla:tunga'><p style='color:white'> This is a paragraph </p>  1234</div> 567<div><p style='color:white'> This is another paragraph </p> </div></div> ending";
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 2, false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            expected = "starting <div attribute='bla:tunga'><p style='color:white'> This is a paragraph </p> <div class='bla'> tunga 1234</div> 567<div><p style='color:white'> This is another paragraph </p> </div></div> ending";
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 3, false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            expected = "starting <div attribute='bla:tunga'><p style='color:white'> This is a paragraph </p> <div class='bla'> tunga<div id='unx'><img src='tunga' /></div> 1234</div> 567</div> ending";
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 4, false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            expected = str;
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 5, false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            //startIndex
            expected = "starting <div attribute='bla:tunga'><p style='color:white'> This is a paragraph </p>  567<div><p style='color:white'> This is another paragraph </p> </div></div> ending";
            yield return new object[] { expected, str, 10, "<div", ">", "</div", ">", 1, true, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            expected = "starting <div attribute='bla:tunga'><p style='color:white'> This is a paragraph </p>  1234</div> 567<div><p style='color:white'> This is another paragraph </p> </div></div> ending";
            yield return new object[] { expected, str, 10, "<div", ">", "</div", ">", 1, false, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            expected = str;
            yield return new object[] { expected, str, str.Length, "<div", ">", "</div", ">", 1, true, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            // StringComparison
            expected = "starting  ending";
            yield return new object[] { expected, str, 0, "<div", ">", "</div", ">", 1, true, (string strToRemove) => true, StringComparison.CurrentCulture };
            expected = "starting  ending";
            yield return new object[] { expected, str, 0, "<DIV", ">", "</DIV", ">", 1, true, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            expected = str;
            yield return new object[] { expected, str, 0, "<DIV", ">", "</DIV", ">", 1, true, (string strToRemove) => true, StringComparison.CurrentCulture };
            // on the limits
            yield return new object[] { "", "bla 123 toing 456 lala 789 unxunx", 0, "bla", "toing", "lala", "unxunx", 1, true, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            // same open close
            yield return new object[] { "aaa  bbb bla 123 toing 456 bla 789 toing ccc", "aaa bla 123 toing 456 bla 789 toing bbb bla 123 toing 456 bla 789 toing ccc", 0, "bla", "toing", "bla", "toing", 1, true, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "aaa bla 123 toing 456  456 bla 789 toing ccc", "aaa bla 123 toing 456 bla 789 toing bbb bla 123 toing 456 bla 789 toing ccc", 0, "bla", "toing", "bla", "toing", 2, true, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "aaa  bbb bla 123 bla 456 bla 789 bla ccc", "aaa bla 123 bla 456 bla 789 bla bbb bla 123 bla 456 bla 789 bla ccc", 0, "bla", "bla", "bla", "bla", 1, true, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "aaa bla 123  123 bla 456 bla 789 bla ccc", "aaa bla 123 bla 456 bla 789 bla bbb bla 123 bla 456 bla 789 bla ccc", 0, "bla", "bla", "bla", "bla", 2, true, (string strToRemove) => true, StringComparison.CurrentCultureIgnoreCase };
            // substringConditionToRemove
            yield return new object[] { "", "bla 123 toing 456 lala 789 unxunx", 0, "bla", "toing", "lala", "unxunx", 1, true, (string strToRemove) => strToRemove.StartsWith("bla"), StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "", "bla 123 toing 456 lala 789 unxunx", 0, "bla", "toing", "lala", "unxunx", 1, true, (string strToRemove) => strToRemove.EndsWith("unxunx"), StringComparison.CurrentCultureIgnoreCase };
            yield return new object[] { "bla 123 toing 456 lala 789 unxunx", "bla 123 toing 456 lala 789 unxunx", 0, "bla", "toing", "lala", "unxunx", 1, true, (string strToRemove) => strToRemove.Length > 200, StringComparison.CurrentCultureIgnoreCase };
        }
        [Theory]
        [MemberData(nameof(TestData_RemoveBetweenStrings_StartEndOccurrenceNestedFunc))]
        public void Test_RemoveBetweenStrings_StartEndOccurrenceNestedFunc(object expected, string str, int startIndex, string startOpenString, string endOpenString, string startCloseString, string endCloseString, int occurrence, bool considerNestedStructures, Func<string, bool> substringConditionToRemove, StringComparison stringComparison)
        {
            var sut = new RemoveExp();
            var result = sut.RemoveBetweenStrings(str, startIndex, startOpenString, endOpenString, startCloseString, endCloseString, occurrence, considerNestedStructures, substringConditionToRemove, stringComparison);
            Assert.Equal(expected, result);
        }





    }
}
