
namespace StringUtilities.Core.SubstringExpanded
{
    public partial class SubstringExp
    {
        public string GetStringAtIndexLimitedByChar(string str, int index, char limitChar, bool includeChar)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "Value cannot be less than 0.");
            else if (index > str.Length)
                throw new ArgumentOutOfRangeException(nameof(index), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");

            if (str[index] == limitChar)
            {
                return includeChar ? limitChar.ToString() : string.Empty;
            }


            var previousCharIndex = str.LastIndexOf(limitChar, index);

            var previous = previousCharIndex != -1 ?
                         str.Substring((includeChar ? previousCharIndex : previousCharIndex + 1), index - (includeChar ? previousCharIndex - 1 : previousCharIndex)) :
                         str.Substring(0, index + 1);

            var nextCharIndex = str.IndexOf(limitChar, index);

            var next = nextCharIndex != -1 ?
                 str.Substring(index + 1, nextCharIndex - (includeChar ? index : index + 1)) :
                 str.Substring(index + 1);

            return previous + next;
        }
        public string GetStringAtIndexLimitedByChar(string str, int index, char[] limitChars, bool includeChar)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            if (limitChars == null)
                throw new ArgumentNullException(nameof(limitChars));
            else if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "Value cannot be less than 0.");
            else if (index > str.Length)
                throw new ArgumentOutOfRangeException(nameof(index), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");


            if (limitChars.Contains(str[index]))
            {
                return includeChar ? str[index].ToString() : string.Empty;
            }

            var previousCharIndex = str.LastIndexOfAny(limitChars, index);

            var previous = previousCharIndex != -1 ?
                         str.Substring((includeChar ? previousCharIndex : previousCharIndex + 1), index - (includeChar ? previousCharIndex - 1 : previousCharIndex)) :
                         str.Substring(0, index + 1);

            var nextCharIndex = str.IndexOfAny(limitChars, index);

            var next = nextCharIndex != -1 ?
                 str.Substring(index + 1, nextCharIndex - (includeChar ? index : index + 1)) :
                 str.Substring(index + 1);

            return previous + next;
        }
        public string GetStringAtIndexLimitedByChar(string str, int index, char limitChar, bool includeChar, int offset, bool backwards)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "Value cannot be less than 0.");
            else if (index > str.Length)
                throw new ArgumentOutOfRangeException(nameof(index), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset), "Value cannot be less than 0.");

            if (offset == 0)
            {
                return GetStringAtIndexLimitedByChar(str, index, limitChar, includeChar);
            }


            var firstIndex = 0;
            var secondIndex = 0;

            while (offset-- > 0)
            {
                firstIndex = backwards ? str.LastIndexOf(limitChar, index) : str.IndexOf(limitChar, index);

                if (firstIndex == -1)
                {
                    return string.Empty;
                }

                secondIndex = backwards ? str.LastIndexOf(limitChar, firstIndex - 1) : str.IndexOf(limitChar, firstIndex + 1);

                if (secondIndex == -1 && offset > 0)
                {
                    return string.Empty;
                }

                index = secondIndex;
            }

            if (backwards)
            {
                if (secondIndex == -1)
                {
                    return str.Substring(0, includeChar ? firstIndex + 1 : firstIndex);
                }
                else
                {
                    return str.Substring(includeChar ? secondIndex : secondIndex + 1, includeChar ? firstIndex - (secondIndex - 1) : firstIndex - (secondIndex + 1));
                }
            }
            else
            {
                if (secondIndex == -1)
                {
                    return str.Substring(includeChar ? firstIndex : firstIndex + 1);
                }
                else
                {
                    return str.Substring(includeChar ? firstIndex : firstIndex + 1, includeChar ? secondIndex - (firstIndex - 1) : secondIndex - (firstIndex + 1));
                }
            }
        }
        public string GetStringAtIndexLimitedByChar(string str, int index, char[] limitChars, bool includeChar, int offset, bool backwards)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            if (limitChars == null)
                throw new ArgumentNullException(nameof(limitChars));
            else if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "Value cannot be less than 0.");
            else if (index > str.Length)
                throw new ArgumentOutOfRangeException(nameof(index), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset), "Value cannot be less than 0.");

            if (offset == 0)
            {
                return GetStringAtIndexLimitedByChar(str, index, limitChars, includeChar);
            }


            var firstIndex = 0;
            var secondIndex = 0;

            while (offset-- > 0)
            {
                firstIndex = backwards ? str.LastIndexOfAny(limitChars, index) : str.IndexOfAny(limitChars, index);

                if (firstIndex == -1)
                {
                    return string.Empty;
                }

                secondIndex = backwards ? str.LastIndexOfAny(limitChars, firstIndex - 1) : str.IndexOfAny(limitChars, firstIndex + 1);

                if (secondIndex == -1 && offset > 0)
                {
                    return string.Empty;
                }

                index = secondIndex;
            }

            if (backwards)
            {
                if (secondIndex == -1)
                {
                    return str.Substring(0, includeChar ? firstIndex + 1 : firstIndex);
                }
                else
                {
                    return str.Substring(includeChar ? secondIndex : secondIndex + 1, includeChar ? firstIndex - (secondIndex - 1) : firstIndex - (secondIndex + 1));
                }
            }
            else
            {
                if (secondIndex == -1)
                {
                    return str.Substring(includeChar ? firstIndex : firstIndex + 1);
                }
                else
                {
                    return str.Substring(includeChar ? firstIndex : firstIndex + 1, includeChar ? secondIndex - (firstIndex - 1) : secondIndex - (firstIndex + 1));
                }
            }
        }


        // simplified
        public string GetWordAtIndex(string str, int index) =>
            GetStringAtIndexLimitedByChar(str, index, ' ', false);
        public string GetNeighboringWord(string str, int index, int wordOffset, bool backwards) =>
            GetStringAtIndexLimitedByChar(str, index, ' ', false, wordOffset, backwards);




    }
}
