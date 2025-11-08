using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringUtilities.Core.SubstringExpanded
{
    public partial class SubstringExp
    {

        public string SubstringToChar(string str, int startIndex, char toChar, bool includeChar, bool backwards)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");

            if (str[startIndex] == toChar)
            {
                return includeChar ? str[startIndex].ToString() : string.Empty;
            }


            if (backwards)
            {
                var charIndex = str.LastIndexOf(toChar, startIndex);

                return charIndex != -1 ?
                     str.Substring(includeChar ? charIndex : charIndex + 1, startIndex - (includeChar ? charIndex - 1 : charIndex)) :
                     str.Substring(0, startIndex + 1);
            }
            else
            {
                var charIndex = str.IndexOf(toChar, startIndex);

                return charIndex != -1 ?
                     str.Substring(startIndex, charIndex - (includeChar ? startIndex - 1 : startIndex)) :
                     str.Substring(startIndex);
            }
        }
        public string SubstringToChar(string str, int startIndex, char toChar, int toCharOccurrence, bool includeChar, bool backwards)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (toCharOccurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(toCharOccurrence), "Value cannot be less than 1.");

            if (str[startIndex] == toChar && toCharOccurrence == 1)
            {
                return includeChar ? str[startIndex].ToString() : string.Empty;
            }

            // find toCharIndex of toChar of toCharOccurrence
            int toCharIndex = startIndex;
            do
            {
                toCharIndex = backwards ?
                    str.LastIndexOf(toChar, toCharIndex) :
                    str.IndexOf(toChar, toCharIndex);

                if (toCharIndex == -1)
                {
                    // if not found, break loop to substring from startIndex to end/start of str
                    break; 
                }
                else if (toCharOccurrence == 1)
                {
                    break;
                }
                else
                {
                    toCharOccurrence--;
                    toCharIndex = backwards ? toCharIndex - 1 : toCharIndex + 1;
                }
            } while (true);


            if (backwards)
            {
                return toCharIndex != -1 ?
                     str.Substring(includeChar ? toCharIndex : toCharIndex + 1, startIndex - (includeChar ? toCharIndex - 1 : toCharIndex)) :
                     str.Substring(0, startIndex + 1);
            }
            else
            {
                return toCharIndex != -1 ?
                     str.Substring(startIndex, toCharIndex - (includeChar ? startIndex - 1 : startIndex)) :
                     str.Substring(startIndex);
            }
        }
        public string SubstringToString(string str, int startIndex, string toString, bool includeString, bool backwards, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (toString == null)
                throw new ArgumentNullException(nameof(toString));
      

            if (backwards)
            {
                var stringIndex = str.LastIndexOf(toString, startIndex, stringComparison);

                return stringIndex != -1 ?
                            includeString ?
                                 str.Substring(stringIndex, startIndex - (stringIndex - 1)) :
                                 str.Substring(stringIndex + toString.Length, startIndex - (stringIndex + toString.Length - 1)) :
                            str.Substring(0, startIndex + 1);
            }
            else
            {
                var stringIndex = str.IndexOf(toString, startIndex, stringComparison);

                return stringIndex != -1 ?
                     str.Substring(startIndex, stringIndex - (includeString ? startIndex - toString.Length : startIndex)) :
                     str.Substring(startIndex);
            }
        }
        public string SubstringToString(string str, int startIndex, string toString, int toStringOccurrence, bool includeString, bool backwards, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (toString == null)
                throw new ArgumentNullException(nameof(toString));
            else if (toStringOccurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(toStringOccurrence), "Value cannot be less than 1.");


            // find toStringIndex of toString of toStringOccurrence
            int toStringIndex = startIndex;
            do
            {
                toStringIndex = backwards ?
                    str.LastIndexOf(toString, toStringIndex, stringComparison) :
                    str.IndexOf(toString, toStringIndex, stringComparison);

                if (toStringIndex == -1)
                {
                    // if not found, break loop to substring from startIndex to end/start of str
                    break;
                }
                else if (toStringOccurrence == 1)
                {
                    break;
                }
                else
                {
                    toStringOccurrence--;
                    toStringIndex = backwards ? toStringIndex - 1 : toStringIndex + 1;
                }
            } while (true);


            if (backwards)
            {
                return toStringIndex != -1 ?
                            includeString ?
                                 str.Substring(toStringIndex, startIndex - (toStringIndex - 1)) :
                                 str.Substring(toStringIndex + toString.Length, startIndex - (toStringIndex + toString.Length - 1)) :
                            str.Substring(0, startIndex + 1);
            }
            else
            {
                return toStringIndex != -1 ?
                     str.Substring(startIndex, toStringIndex - (includeString ? startIndex - toString.Length : startIndex)) :
                     str.Substring(startIndex);
            }
        }



    }
}
