
namespace StringUtilities.Core.SubstringExpanded
{
    public partial class SubstringExp
    {
        // what: methods made to substring - between 2 chars or 2 strings - next to (after or before) a 'reference' string (refString)
        // how:  finds the index of the refString - finds the index of the openChar/openString - finds the index of the closeChar/closeString - substrings between 'open' and 'close' - returns string.Empty if any of the indexes is not found
        //
        // params:
        // - str:   .   .   .   .   .   .   .   .   .   the string to substring from
        // - startIndex:    .   .   .   .   .   .   .   the index where it starts looking for the refString in the str
        // - strReference:  .   .   .   .   .   .   .   the refString to search for
        // - strRefComparison:  .   .   .   .   .   .   the StringComparison for the refString
        // - strRefOccurrence:  .   .   .   .   .   .   the occurence of the 'referece' string, i.e. the amount of times it needs to be found before start searching for the 2 chars/strings to substring between
        // - backwards:     .   .   .   .   .   .   .   defines if it substrings before or after the refString
        // - openChar | closeChar:  .   .   .   .   .   the chars where it substrings between
        // - openString | closeString:  .   .   .   .   the strings where it substrings between
        // - openOccurrence | closeOccurrence:  .   .   same as strRefOccurrence but for the 2 chars/strings where it substring between
        // - includeLimitChars | includeLimitStrings:   true to include in the resulting substring the 2 chars/strings, false to exclude them
        //
        // param exceptions:
        // - str:   .   .   .   .   .   .   .   .   .   .   .   .   ArgumentNullException   .   .   When null
        // - strReference   .   .   .   .   .   .   .   .   .   .   ArgumentNullException   .   .   When null
        // - openString/closeString .   .   .   .   .   .   .   .   ArgumentNullException   .   .   When null
        // - startIndex:    .   .   .   .   .   .   .   .   .   .   ArgumentOutOfRangeException .   When less than 0
        // - startIndex:    .   .   .   .   .   .   .   .   .   .   ArgumentOutOfRangeException .   When greater than str.Length
        // - strRefOccurrence/openOccurrence/closeOccurrence    .   ArgumentOutOfRangeException .   When less than 1
        //
        // operation steps:
        // - 1st) Finds the refString considering its occurrence and StringComparison.
        //        Starts the search from the startIndex and looks before or after it depending on the 'backwards' param (true: looks before startIndex, false: looks after).
        //        If none is found returns string.Empty;
        // - 2nd) Finds the openChar/openString considering its occurrence.
        //        Starts the search from the refString index plus the refString.Length and looks before or after it depending on the 'backwards' param.
        //        In case of the openString, the same StringComparison that was used to find refString is also used here;
        //        If none is found returns string.Empty.
        // - 3rd) Finds the closeChar/closeString considering its occurrence.
        //        Starts the search from the openChar/openString index plus the openChar/openString.Length and looks before or after it depending on the 'backwards' param.
        //        In case of the closeString, the same StringComparison that was used to find refString is also used here;
        //        If none is found returns string.Empty.
        // - 4th) Substrings with the found indexes of the openChar/closeChar or openString/closeString.
        //
        // usage example:
        // - 1) in an html string, find the id of the tag (refString) and substring between '>' and '<' to get the tag value
        //      may not work well if an unescaped '>' is found inside the tag attributes - <div data-example="100 > 50">Content</div>
        //      '<' and '>' should be escaped to &lt; and &gt;. Using '<' without escaping will break the html structure, but an unescaped '>' is allowed! 
        // - 2) in a xml string, substring the value of a tag of a given name


        #region Between Chars

        public string SubstringBetweenCharsNextToString(string str, string strReference, bool backwards, char openChar, char closeChar, bool includeLimitChars)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (strReference == null)
                throw new ArgumentNullException(nameof(strReference));


            // find refIndex of stringReference
            int refIndex = backwards ?
                str.LastIndexOf(strReference) :
                str.IndexOf(strReference);

            if (refIndex == -1)
            {
                return string.Empty;
            }


            // find openIndex of openChar
            int openIndex = backwards ?
                str.LastIndexOf(openChar, refIndex - strReference.Length) :
                str.IndexOf(openChar, refIndex + strReference.Length);

            if (openIndex == -1)
            {
                return string.Empty;
            }


            // find closeIndex of closeChar
            int closeIndex = backwards ?
                str.LastIndexOf(closeChar, openIndex - 1) :
                str.IndexOf(closeChar, openIndex + 1);

            if (closeIndex == -1)
            {
                return string.Empty;
            }


            // Calculate and return the substring
            if (backwards)
            {
                return includeLimitChars ?
                    str.Substring(closeIndex, openIndex - closeIndex + 1) :
                    str.Substring(closeIndex + 1, openIndex - closeIndex - 1);
            }
            else
            {
                return includeLimitChars ?
                    str.Substring(openIndex, closeIndex - openIndex + 1) :
                    str.Substring(openIndex + 1, closeIndex - openIndex - 1);
            }
        }
        public string SubstringBetweenCharsNextToString(string str, string strReference, StringComparison strRefComparison, bool backwards, char openChar, char closeChar, bool includeLimitChars)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (strReference == null)
                throw new ArgumentNullException(nameof(strReference));


            // find refIndex of stringReference
            int refIndex = backwards ?
                str.LastIndexOf(strReference, strRefComparison) :
                str.IndexOf(strReference, strRefComparison);

            if (refIndex == -1)
            {
                return string.Empty;
            }


            // find openIndex of openChar
            int openIndex = backwards ?
                str.LastIndexOf(openChar, refIndex - strReference.Length) :
                str.IndexOf(openChar, refIndex + strReference.Length);

            if (openIndex == -1)
            {
                return string.Empty;
            }


            // find closeIndex of closeChar
            int closeIndex = backwards ?
                str.LastIndexOf(closeChar, openIndex - 1) :
                str.IndexOf(closeChar, openIndex + 1);

            if (closeIndex == -1)
            {
                return string.Empty;
            }


            // Calculate and return the substring
            if (backwards)
            {
                return includeLimitChars ?
                    str.Substring(closeIndex, openIndex - closeIndex + 1) :
                    str.Substring(closeIndex + 1, openIndex - closeIndex - 1);
            }
            else
            {
                return includeLimitChars ?
                    str.Substring(openIndex, closeIndex - openIndex + 1) :
                    str.Substring(openIndex + 1, closeIndex - openIndex - 1);
            }
        }
        public string SubstringBetweenCharsNextToString(string str, int startIndex, string strReference, StringComparison strRefComparison, bool backwards, char openChar, char closeChar, bool includeLimitChars)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (strReference == null)
                throw new ArgumentNullException(nameof(strReference));


            // find refIndex of stringReference
            int refIndex = backwards ?
                str.LastIndexOf(strReference, startIndex, strRefComparison) :
                str.IndexOf(strReference, startIndex, strRefComparison);

            if (refIndex == -1)
            {
                return string.Empty;
            }


            // find openIndex of openChar
            int openIndex = backwards ?
                str.LastIndexOf(openChar, refIndex - strReference.Length) :
                str.IndexOf(openChar, refIndex + strReference.Length);

            if (openIndex == -1)
            {
                return string.Empty;
            }


            // find closeIndex of closeChar
            int closeIndex = backwards ?
                str.LastIndexOf(closeChar, openIndex - 1) :
                str.IndexOf(closeChar, openIndex + 1);

            if (closeIndex == -1)
            {
                return string.Empty;
            }


            // Calculate and return the substring
            if (backwards)
            {
                return includeLimitChars ?
                    str.Substring(closeIndex, openIndex - closeIndex + 1) :
                    str.Substring(closeIndex + 1, openIndex - closeIndex - 1);
            }
            else
            {
                return includeLimitChars ?
                    str.Substring(openIndex, closeIndex - openIndex + 1) :
                    str.Substring(openIndex + 1, closeIndex - openIndex - 1);
            }
        }
        public string SubstringBetweenCharsNextToString(string str, int startIndex, string strReference, StringComparison strRefComparison, int strRefOccurrence, bool backwards, char openChar, char closeChar, int limitsOccurrence, bool includeLimitChars)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (strReference == null)
                throw new ArgumentNullException(nameof(strReference));
            else if (strRefOccurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(strRefOccurrence), "Value cannot be less than 1.");
            else if (limitsOccurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(limitsOccurrence), "Value cannot be less than 1.");


            // find refIndex of stringReference of refOccurrence
            int refIndex = startIndex;
            do
            {
                refIndex = backwards ?
                    str.LastIndexOf(strReference, refIndex, strRefComparison) :
                    str.IndexOf(strReference, refIndex, strRefComparison);

                if (refIndex == -1)
                {
                    return string.Empty;
                }
                else if (strRefOccurrence == 1)
                {
                    break;
                }
                else
                {
                    strRefOccurrence--;
                    refIndex = backwards ?
                        refIndex - strReference.Length :
                        refIndex + strReference.Length;
                }
            } while (true);


            // find openIndex of openChar of limitsOccurrence
            int openIndex = backwards ? refIndex - 1 : refIndex + strReference.Length;
            do
            {
                openIndex = backwards ?
                    str.LastIndexOf(openChar, openIndex) :
                    str.IndexOf(openChar, openIndex);

                if (openIndex == -1)
                {
                    return string.Empty;
                }
                else if (limitsOccurrence == 1)
                {
                    break;
                }
                else
                {
                    limitsOccurrence--;
                    openIndex = backwards ? openIndex - 1 : openIndex + 1;
                }
            } while (true);


            // find closeIndex 
            int closeIndex = backwards ?
                str.LastIndexOf(closeChar, openIndex - 1) :
                str.IndexOf(closeChar, openIndex + 1);

            if (closeIndex == -1)
            {
                return string.Empty;
            }


            // Calculate and return the substring
            if (backwards)
            {
                if (includeLimitChars)
                {
                    return str.Substring(closeIndex, openIndex - closeIndex + 1);
                }
                else
                {
                    return str.Substring(closeIndex + 1, openIndex - closeIndex - 1);
                }
            }
            else
            {
                if (includeLimitChars)
                {
                    return str.Substring(openIndex, closeIndex - openIndex + 1);
                }
                else
                {
                    return str.Substring(openIndex + 1, closeIndex - openIndex - 1);
                }
            }

        }
        public string SubstringBetweenCharsNextToString(string str, int startIndex, string strReference, StringComparison strRefComparison, int strRefOccurrence, bool backwards, char openChar, int openOccurrence, char closeChar, int closeOccurrence, bool includeLimitChars)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (strReference == null)
                throw new ArgumentNullException(nameof(strReference));
            else if (strRefOccurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(strRefOccurrence), "Value cannot be less than 1.");
            else if (openOccurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(openOccurrence), "Value cannot be less than 1.");
            else if (closeOccurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(closeOccurrence), "Value cannot be less than 1.");


            // find refIndex of stringReference of refOccurrence
            int refIndex = startIndex;
            do
            {
                refIndex = backwards ?
                    str.LastIndexOf(strReference, refIndex, strRefComparison) :
                    str.IndexOf(strReference, refIndex, strRefComparison);

                if (refIndex == -1)
                {
                    return string.Empty;
                }
                else if (strRefOccurrence == 1)
                {
                    break;
                }
                else
                {
                    strRefOccurrence--;
                    refIndex = backwards ?
                        refIndex - strReference.Length :
                        refIndex + strReference.Length;
                }
            } while (true);


            // find openIndex of openChar of openOccurrence
            int openIndex = backwards ? refIndex - 1 : refIndex + strReference.Length;
            do
            {
                openIndex = backwards ?
                    str.LastIndexOf(openChar, openIndex) :
                    str.IndexOf(openChar, openIndex);

                if (openIndex == -1)
                {
                    return string.Empty;
                }
                else if (openOccurrence == 1)
                {
                    break;
                }
                else
                {
                    openOccurrence--;
                    openIndex = backwards ? openIndex - 1 : openIndex + 1;
                }
            } while (true);


            // find closeIndex of closeChar of closeOccurrence
            int closeIndex = backwards ? openIndex - 1 : openIndex + 1;
            do
            {
                closeIndex = backwards ?
                    str.LastIndexOf(closeChar, closeIndex) :
                    str.IndexOf(closeChar, closeIndex);

                if (closeIndex == -1)
                {
                    return string.Empty;
                }
                else if (closeOccurrence == 1)
                {
                    break;
                }
                else
                {
                    closeOccurrence--;
                    closeIndex = backwards ? closeIndex - 1 : closeIndex + 1;
                }
            } while (true);


            // Calculate and return the substring
            if (backwards)
            {
                return includeLimitChars ?
                    str.Substring(closeIndex, openIndex - closeIndex + 1) :
                    str.Substring(closeIndex + 1, openIndex - closeIndex - 1);
            }
            else
            {
                return includeLimitChars ?
                    str.Substring(openIndex, closeIndex - openIndex + 1) :
                    str.Substring(openIndex + 1, closeIndex - openIndex - 1);
            }

        }

        public IEnumerable<string> SubstringAllBetweenCharsNextToString(string str, string strReference, bool backwards, char openChar, char closeChar, bool includeLimitChars)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (strReference == null)
                throw new ArgumentNullException(nameof(strReference));

            var substrings = new List<string>();
            var refIndex = -1;

            while (true)
            {
                // find refIndex of stringReference
                refIndex = backwards ?
                    str.LastIndexOf(strReference, refIndex) :
                    str.IndexOf(strReference, refIndex);

                if (refIndex == -1)
                {
                    return substrings;
                }


                // find openIndex of openChar
                int openIndex = backwards ?
                    str.LastIndexOf(openChar, refIndex - strReference.Length) :
                    str.IndexOf(openChar, refIndex + strReference.Length);

                if (openIndex == -1)
                {
                    return substrings;
                }


                // find closeIndex of closeChar
                int closeIndex = backwards ?
                    str.LastIndexOf(closeChar, openIndex - 1) :
                    str.IndexOf(closeChar, openIndex + 1);

                if (closeIndex == -1)
                {
                    return substrings;
                }


                // substrings add
                if (backwards)
                {
                    substrings.Add(includeLimitChars ?
                        str.Substring(closeIndex, openIndex - closeIndex + 1) :
                        str.Substring(closeIndex + 1, openIndex - closeIndex - 1));
                }
                else
                {
                    substrings.Add(includeLimitChars ?
                        str.Substring(openIndex, closeIndex - openIndex + 1) :
                        str.Substring(openIndex + 1, closeIndex - openIndex - 1));
                }

                refIndex = backwards ?
                    closeIndex - 1 :
                    closeIndex + 1;
            }
        }
        public IEnumerable<string> SubstringAllBetweenCharsNextToString(string str, string strReference, StringComparison strRefComparison, bool backwards, char openChar, char closeChar, bool includeLimitChars)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (strReference == null)
                throw new ArgumentNullException(nameof(strReference));

            var substrings = new List<string>();
            var refIndex = -1;

            while (true)
            {
                // find refIndex of stringReference
                refIndex = backwards ?
                    str.LastIndexOf(strReference, refIndex, strRefComparison) :
                    str.IndexOf(strReference, refIndex, strRefComparison);

                if (refIndex == -1)
                {
                    return substrings;
                }


                // find openIndex of openChar
                int openIndex = backwards ?
                    str.LastIndexOf(openChar, refIndex - strReference.Length) :
                    str.IndexOf(openChar, refIndex + strReference.Length);

                if (openIndex == -1)
                {
                    return substrings;
                }


                // find closeIndex of closeChar
                int closeIndex = backwards ?
                    str.LastIndexOf(closeChar, openIndex - 1) :
                    str.IndexOf(closeChar, openIndex + 1);

                if (closeIndex == -1)
                {
                    return substrings;
                }


                // substrings add
                if (backwards)
                {
                    substrings.Add(includeLimitChars ?
                        str.Substring(closeIndex, openIndex - closeIndex + 1) :
                        str.Substring(closeIndex + 1, openIndex - closeIndex - 1));
                }
                else
                {
                    substrings.Add(includeLimitChars ?
                        str.Substring(openIndex, closeIndex - openIndex + 1) :
                        str.Substring(openIndex + 1, closeIndex - openIndex - 1));
                }

                refIndex = backwards ?
                    closeIndex - 1 :
                    closeIndex + 1;
            }
        }
        public IEnumerable<string> SubstringAllBetweenCharsNextToString(string str, int startIndex, string strReference, StringComparison strRefComparison, bool backwards, char openChar, char closeChar, bool includeLimitChars)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (strReference == null)
                throw new ArgumentNullException(nameof(strReference));

            var substrings = new List<string>();
            var refIndex = startIndex;

            while (true)
            {
                // find refIndex of stringReference
                refIndex = backwards ?
                    str.LastIndexOf(strReference, refIndex, strRefComparison) :
                    str.IndexOf(strReference, refIndex, strRefComparison);

                if (refIndex == -1)
                {
                    return substrings;
                }


                // find openIndex of openChar
                int openIndex = backwards ?
                    str.LastIndexOf(openChar, refIndex - strReference.Length) :
                    str.IndexOf(openChar, refIndex + strReference.Length);

                if (openIndex == -1)
                {
                    return substrings;
                }


                // find closeIndex of closeChar
                int closeIndex = backwards ?
                    str.LastIndexOf(closeChar, openIndex - 1) :
                    str.IndexOf(closeChar, openIndex + 1);

                if (closeIndex == -1)
                {
                    return substrings;
                }


                // substrings add
                if (backwards)
                {
                    substrings.Add(includeLimitChars ?
                        str.Substring(closeIndex, openIndex - closeIndex + 1) :
                        str.Substring(closeIndex + 1, openIndex - closeIndex - 1));
                }
                else
                {
                    substrings.Add(includeLimitChars ?
                        str.Substring(openIndex, closeIndex - openIndex + 1) :
                        str.Substring(openIndex + 1, closeIndex - openIndex - 1));
                }

                refIndex = backwards ?
                    closeIndex - 1 :
                    closeIndex + 1;
            }
        }

        #endregion


        #region Between Strings

        public string SubstringBetweenStringsNextToString(string str, string strReference, bool backwards, string openString, string closeString, bool includeLimitStrings)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (strReference == null)
                throw new ArgumentNullException(nameof(strReference));
            else if (openString == null)
                throw new ArgumentNullException(nameof(openString));
            else if (closeString == null)
                throw new ArgumentNullException(nameof(closeString));


            // find refIndex of stringReference
            int refIndex = backwards ?
                    str.LastIndexOf(strReference) :
                    str.IndexOf(strReference);

            if (refIndex == -1)
            {
                return string.Empty;
            }


            // find openIndex of openString
            int openIndex = backwards ?
                    str.LastIndexOf(openString, refIndex - 1) :
                    str.IndexOf(openString, refIndex + strReference.Length);

            if (openIndex == -1)
            {
                return string.Empty;
            }


            // find closeIndex of closeString
            int closeIndex = backwards ?
                str.LastIndexOf(closeString, openIndex - openString.Length) :
                str.IndexOf(closeString, openIndex + openString.Length);

            if (closeIndex == -1)
            {
                return string.Empty;
            }


            // Calculate and return the substring
            if (backwards)
            {
                return includeLimitStrings ?
                    str.Substring(closeIndex, openIndex - closeIndex + closeString.Length) :
                    str.Substring(closeIndex + closeString.Length, openIndex - closeIndex - closeString.Length);
            }
            else
            {
                return includeLimitStrings ?
                    str.Substring(openIndex, closeIndex - openIndex + openString.Length) :
                    str.Substring(openIndex + openString.Length, closeIndex - openIndex - openString.Length);
            }
        }
        public string SubstringBetweenStringsNextToString(string str, string strReference, StringComparison strRefComparison, bool backwards, string openString, string closeString, bool includeLimitStrings)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (strReference == null)
                throw new ArgumentNullException(nameof(strReference));
            else if (openString == null)
                throw new ArgumentNullException(nameof(openString));
            else if (closeString == null)
                throw new ArgumentNullException(nameof(closeString));


            // find refIndex of stringReference
            int refIndex = backwards ?
                    str.LastIndexOf(strReference, strRefComparison) :
                    str.IndexOf(strReference, strRefComparison);

            if (refIndex == -1)
            {
                return string.Empty;
            }


            // find openIndex of openString
            int openIndex = backwards ?
                    str.LastIndexOf(openString, refIndex - 1, strRefComparison) :
                    str.IndexOf(openString, refIndex + strReference.Length, strRefComparison);

            if (openIndex == -1)
            {
                return string.Empty;
            }


            // find closeIndex of closeString
            int closeIndex = backwards ?
                str.LastIndexOf(closeString, openIndex - openString.Length, strRefComparison) :
                str.IndexOf(closeString, openIndex + openString.Length, strRefComparison);

            if (closeIndex == -1)
            {
                return string.Empty;
            }


            // Calculate and return the substring
            if (backwards)
            {
                return includeLimitStrings ?
                    str.Substring(closeIndex, openIndex - closeIndex + closeString.Length) :
                    str.Substring(closeIndex + closeString.Length, openIndex - closeIndex - closeString.Length);
            }
            else
            {
                return includeLimitStrings ?
                    str.Substring(openIndex, closeIndex - openIndex + openString.Length) :
                    str.Substring(openIndex + openString.Length, closeIndex - openIndex - openString.Length);
            }
        }
        public string SubstringBetweenStringsNextToString(string str, int startIndex, string strReference, StringComparison strRefComparison, bool backwards, string openString, string closeString, bool includeLimitStrings)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (strReference == null)
                throw new ArgumentNullException(nameof(strReference));
            else if (openString == null)
                throw new ArgumentNullException(nameof(openString));
            else if (closeString == null)
                throw new ArgumentNullException(nameof(closeString));


            // find refIndex of stringReference
            int refIndex = backwards ?
                    str.LastIndexOf(strReference, startIndex, strRefComparison) :
                    str.IndexOf(strReference, startIndex, strRefComparison);

            if (refIndex == -1)
            {
                return string.Empty;
            }


            // find openIndex of openString
            int openIndex = backwards ?
                    str.LastIndexOf(openString, refIndex - 1, strRefComparison) :
                    str.IndexOf(openString, refIndex + strReference.Length, strRefComparison);

            if (openIndex == -1)
            {
                return string.Empty;
            }


            // find closeIndex of closeString
            int closeIndex = backwards ?
                str.LastIndexOf(closeString, openIndex - openString.Length, strRefComparison) :
                str.IndexOf(closeString, openIndex + openString.Length, strRefComparison);

            if (closeIndex == -1)
            {
                return string.Empty;
            }


            // Calculate and return the substring
            if (backwards)
            {
                return includeLimitStrings ?
                    str.Substring(closeIndex, openIndex - closeIndex + closeString.Length) :
                    str.Substring(closeIndex + closeString.Length, openIndex - closeIndex - closeString.Length);
            }
            else
            {
                return includeLimitStrings ?
                    str.Substring(openIndex, closeIndex - openIndex + openString.Length) :
                    str.Substring(openIndex + openString.Length, closeIndex - openIndex - openString.Length);
            }
        }
        public string SubstringBetweenStringsNextToString(string str, int startIndex, string strReference, StringComparison strRefComparison, int refOccurrence, bool backwards, string openString, string closeString, int limitsOccurrence, bool includeLimitStrings)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (strReference == null)
                throw new ArgumentNullException(nameof(strReference));
            else if (refOccurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(refOccurrence), "Value cannot be less than 1.");
            else if (openString == null)
                throw new ArgumentNullException(nameof(openString));
            else if (closeString == null)
                throw new ArgumentNullException(nameof(closeString));
            else if (limitsOccurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(limitsOccurrence), "Value cannot be less than 1.");


            // find refIndex of stringReference of refOccurrence
            int refIndex = startIndex;
            do
            {
                refIndex = backwards ?
                    str.LastIndexOf(strReference, refIndex, strRefComparison) :
                    str.IndexOf(strReference, refIndex, strRefComparison);

                if (refIndex == -1)
                {
                    return string.Empty;
                }
                else if (refOccurrence == 1)
                {
                    break;
                }
                else
                {
                    refOccurrence--;
                    refIndex = backwards ?
                        refIndex - strReference.Length :
                        refIndex + strReference.Length;
                }
            } while (true);


            // find openIndex of openString of limitsOccurrence
            int openIndex = backwards ? refIndex - 1 : refIndex + strReference.Length;
            do
            {
                openIndex = backwards ?
                    str.LastIndexOf(openString, openIndex, strRefComparison) :
                    str.IndexOf(openString, openIndex, strRefComparison);

                if (openIndex == -1)
                {
                    return string.Empty;
                }
                else if (limitsOccurrence == 1)
                {
                    break;
                }
                else
                {
                    limitsOccurrence--;
                    openIndex = backwards ?
                        openIndex - openString.Length :
                        openIndex + openString.Length;
                }
            } while (true);


            // find closeIndex 
            int closeIndex = backwards ?
                str.LastIndexOf(closeString, openIndex - openString.Length, strRefComparison) :
                str.IndexOf(closeString, openIndex + openString.Length, strRefComparison);

            if (closeIndex == -1)
            {
                return string.Empty;
            }


            // Calculate and return the substring
            if (backwards)
            {
                return includeLimitStrings ?
                    str.Substring(closeIndex, openIndex - closeIndex + closeString.Length) :
                    str.Substring(closeIndex + closeString.Length, openIndex - closeIndex - closeString.Length);
            }
            else
            {
                return includeLimitStrings ?
                    str.Substring(openIndex, closeIndex - openIndex + openString.Length) :
                    str.Substring(openIndex + openString.Length, closeIndex - openIndex - openString.Length);
            }
        }
        public string SubstringBetweenStringsNextToString(string str, int startIndex, string strReference, StringComparison strRefComparison, int refOccurrence, bool backwards, string openString, int openOccurrence, string closeString, int closeOccurrence, bool includeLimitStrings)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (strReference == null)
                throw new ArgumentNullException(nameof(strReference));
            else if (refOccurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(refOccurrence), "Value cannot be less than 1.");
            else if (openString == null)
                throw new ArgumentNullException(nameof(openString));
            else if (openOccurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(openOccurrence), "Value cannot be less than 1.");
            else if (closeString == null)
                throw new ArgumentNullException(nameof(closeString));
            else if (closeOccurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(closeOccurrence), "Value cannot be less than 1.");


            // find refIndex of stringReference of refOccurrence
            int refIndex = startIndex;
            do
            {
                refIndex = backwards ?
                    str.LastIndexOf(strReference, refIndex, strRefComparison) :
                    str.IndexOf(strReference, refIndex, strRefComparison);

                if (refIndex == -1)
                {
                    return string.Empty;
                }
                else if (refOccurrence == 1)
                {
                    break;
                }
                else
                {
                    refOccurrence--;
                    refIndex = backwards ?
                        refIndex - strReference.Length :
                        refIndex + strReference.Length;
                }
            } while (true);


            // find openIndex of openString of openOccurrence
            int openIndex = backwards ? refIndex - 1 : refIndex + strReference.Length;
            do
            {
                openIndex = backwards ?
                    str.LastIndexOf(openString, openIndex, strRefComparison) :
                    str.IndexOf(openString, openIndex, strRefComparison);

                if (openIndex == -1)
                {
                    return string.Empty;
                }
                else if (openOccurrence == 1)
                {
                    break;
                }
                else
                {
                    openOccurrence--;
                    openIndex = backwards ?
                        openIndex - openString.Length :
                        openIndex + openString.Length;
                }
            } while (true);


            // find closeIndex of closeString of closeOccurrence
            int closeIndex = backwards ? openIndex - 1 : openIndex + openString.Length;
            do
            {
                closeIndex = backwards ?
                    str.LastIndexOf(closeString, closeIndex, strRefComparison) :
                    str.IndexOf(closeString, closeIndex, strRefComparison);

                if (closeIndex == -1)
                {
                    return string.Empty;
                }
                else if (closeOccurrence == 1)
                {
                    break;
                }
                else
                {
                    closeOccurrence--;
                    closeIndex = backwards ?
                        closeIndex - closeString.Length :
                        closeIndex + closeString.Length;
                }
            } while (true);


            // Calculate and return the substring
            if (backwards)
            {
                return includeLimitStrings ?
                    str.Substring(closeIndex, openIndex - closeIndex + closeString.Length) :
                    str.Substring(closeIndex + closeString.Length, openIndex - closeIndex - closeString.Length);
            }
            else
            {
                return includeLimitStrings ?
                    str.Substring(openIndex, closeIndex - openIndex + openString.Length) :
                    str.Substring(openIndex + openString.Length, closeIndex - openIndex - openString.Length);
            }
        }

        public IEnumerable<string> SubstringAllBetweenStringsNextToString(string str, string strReference, bool backwards, string openString, string closeString, bool includeLimitStrings)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (strReference == null)
                throw new ArgumentNullException(nameof(strReference));
            else if (openString == null)
                throw new ArgumentNullException(nameof(openString));
            else if (closeString == null)
                throw new ArgumentNullException(nameof(closeString));

            var substrings = new List<string>();
            var refIndex = -1;

            while (true)
            {
                // find refIndex of stringReference
                refIndex = backwards ?
                        str.LastIndexOf(strReference, refIndex) :
                        str.IndexOf(strReference, refIndex);

                if (refIndex == -1)
                {
                    return substrings;
                }


                // find openIndex of openString
                int openIndex = backwards ?
                        str.LastIndexOf(openString, refIndex - 1) :
                        str.IndexOf(openString, refIndex + strReference.Length);

                if (openIndex == -1)
                {
                    return substrings;
                }


                // find closeIndex of closeString
                int closeIndex = backwards ?
                    str.LastIndexOf(closeString, openIndex - openString.Length) :
                    str.IndexOf(closeString, openIndex + openString.Length);

                if (closeIndex == -1)
                {
                    return substrings;
                }


                // substring add
                if (backwards)
                {
                    substrings.Add(includeLimitStrings ?
                        str.Substring(closeIndex, openIndex - closeIndex + closeString.Length) :
                        str.Substring(closeIndex + closeString.Length, openIndex - closeIndex - closeString.Length));
                }
                else
                {
                    substrings.Add(includeLimitStrings ?
                        str.Substring(openIndex, closeIndex - openIndex + openString.Length) :
                        str.Substring(openIndex + openString.Length, closeIndex - openIndex - openString.Length));
                }

                refIndex = backwards ?
                    closeIndex - 1 :
                    closeIndex + 1;
            }
        }
        public IEnumerable<string> SubstringAllBetweenStringsNextToString(string str, string strReference, StringComparison strRefComparison, bool backwards, string openString, string closeString, bool includeLimitStrings)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (strReference == null)
                throw new ArgumentNullException(nameof(strReference));
            else if (openString == null)
                throw new ArgumentNullException(nameof(openString));
            else if (closeString == null)
                throw new ArgumentNullException(nameof(closeString));

            var substrings = new List<string>();
            var refIndex = -1;

            while (true)
            {
                // find refIndex of stringReference
                refIndex = backwards ?
                        str.LastIndexOf(strReference, refIndex, strRefComparison) :
                        str.IndexOf(strReference, refIndex, strRefComparison);

                if (refIndex == -1)
                {
                    return substrings;
                }


                // find openIndex of openString
                int openIndex = backwards ?
                        str.LastIndexOf(openString, refIndex - 1, strRefComparison) :
                        str.IndexOf(openString, refIndex + strReference.Length, strRefComparison);

                if (openIndex == -1)
                {
                    return substrings;
                }


                // find closeIndex of closeString
                int closeIndex = backwards ?
                    str.LastIndexOf(closeString, openIndex - openString.Length, strRefComparison) :
                    str.IndexOf(closeString, openIndex + openString.Length, strRefComparison);

                if (closeIndex == -1)
                {
                    return substrings;
                }


                // substring add
                if (backwards)
                {
                    substrings.Add(includeLimitStrings ?
                        str.Substring(closeIndex, openIndex - closeIndex + closeString.Length) :
                        str.Substring(closeIndex + closeString.Length, openIndex - closeIndex - closeString.Length));
                }
                else
                {
                    substrings.Add(includeLimitStrings ?
                        str.Substring(openIndex, closeIndex - openIndex + openString.Length) :
                        str.Substring(openIndex + openString.Length, closeIndex - openIndex - openString.Length));
                }

                refIndex = backwards ?
                    closeIndex - 1 :
                    closeIndex + 1;
            }
        }
        public IEnumerable<string> SubstringAllBetweenStringsNextToString(string str, int startIndex, string strReference, StringComparison strRefComparison, bool backwards, string openString, string closeString, bool includeLimitStrings)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (strReference == null)
                throw new ArgumentNullException(nameof(strReference));
            else if (openString == null)
                throw new ArgumentNullException(nameof(openString));
            else if (closeString == null)
                throw new ArgumentNullException(nameof(closeString));

            var substrings = new List<string>();
            var refIndex = startIndex;

            while (true)
            {
                // find refIndex of stringReference
                refIndex = backwards ?
                        str.LastIndexOf(strReference, refIndex, strRefComparison) :
                        str.IndexOf(strReference, refIndex, strRefComparison);

                if (refIndex == -1)
                {
                    return substrings;
                }


                // find openIndex of openString
                int openIndex = backwards ?
                        str.LastIndexOf(openString, refIndex - 1, strRefComparison) :
                        str.IndexOf(openString, refIndex + strReference.Length, strRefComparison);

                if (openIndex == -1)
                {
                    return substrings;
                }


                // find closeIndex of closeString
                int closeIndex = backwards ?
                    str.LastIndexOf(closeString, openIndex - openString.Length, strRefComparison) :
                    str.IndexOf(closeString, openIndex + openString.Length, strRefComparison);

                if (closeIndex == -1)
                {
                    return substrings;
                }


                // substring add
                if (backwards)
                {
                    substrings.Add(includeLimitStrings ?
                        str.Substring(closeIndex, openIndex - closeIndex + closeString.Length) :
                        str.Substring(closeIndex + closeString.Length, openIndex - closeIndex - closeString.Length));
                }
                else
                {
                    substrings.Add(includeLimitStrings ?
                        str.Substring(openIndex, closeIndex - openIndex + openString.Length) :
                        str.Substring(openIndex + openString.Length, closeIndex - openIndex - openString.Length));
                }

                refIndex = backwards ?
                    closeIndex - 1 :
                    closeIndex + 1;
            }
        }
        
        #endregion

    }
}
