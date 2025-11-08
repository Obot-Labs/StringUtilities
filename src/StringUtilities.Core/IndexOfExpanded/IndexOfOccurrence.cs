
namespace StringUtilities.Core.IndexOfExpanded
{
    public partial class IndexOfExp
    {
        // -- char --

        public int IndexOfOccurrence(string str, char value, int occurrence, int startIndex, bool backwards, int count)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Value cannot be less than 0.");
            else if (!backwards && startIndex + count > str.Length)
                throw new ArgumentOutOfRangeException(nameof(count), $"If parameter {nameof(backwards)} is false, the sum of parameter {nameof(count)} with {nameof(startIndex)} cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (backwards && startIndex + 1 - count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), $"If parameter {nameof(backwards)} is true, the result of {nameof(startIndex)} + 1 - {nameof(count)} must be 0 or positive.");


            var currentIndex = startIndex;
            var currentCount = count;

            do
            {
                if (backwards)
                {
                    currentIndex = str.LastIndexOf(value, currentIndex, currentCount);
                }
                else
                {
                    currentIndex = str.IndexOf(value, currentIndex, currentCount);
                }

                if (currentIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return currentIndex;
                }
                else
                {
                    occurrence--;
                    currentIndex = backwards ? --currentIndex : ++currentIndex;
                    currentCount = backwards ?
                        count - (startIndex - currentIndex) :
                        count - (currentIndex - startIndex);
                }
            } while (true);
        }
        public int IndexOfOccurrence(string str, char value, int occurrence, int startIndex, bool backwards)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");


            do
            {
                if (backwards)
                {
                    startIndex = str.LastIndexOf(value, startIndex);
                }
                else
                {
                    startIndex = str.IndexOf(value, startIndex);
                }

                if (startIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return startIndex;
                }
                else
                {
                    occurrence--;
                    startIndex = backwards ? --startIndex : ++startIndex;
                }
            } while (true);
        }
        public int IndexOfOccurrence(string str, char value, int occurrence, bool backwards)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");

            var currentIndex = 0;
            do
            {
                if (backwards)
                {
                    currentIndex = str.LastIndexOf(value, currentIndex);
                }
                else
                {
                    currentIndex = str.IndexOf(value, currentIndex);
                }

                if (currentIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return currentIndex;
                }
                else
                {
                    occurrence--;
                    currentIndex = backwards ? --currentIndex : ++currentIndex;
                }
            } while (true);
        }
        public int IndexOfOccurrence(string str, char value, int occurrence, int startIndex, int endIndex)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (endIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (endIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");

            do
            {
                startIndex = str.IndexOf(value, startIndex, endIndex + 1 - startIndex);

                if (startIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return startIndex;
                }
                else
                {
                    occurrence--;
                    startIndex++;
                }
            } while (true);
        }
        public int IndexOfOccurrence(string str, char value, int occurrence, int startIndex)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");

            do
            {
                startIndex = str.IndexOf(value, startIndex);

                if (startIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return startIndex;
                }
                else
                {
                    occurrence--;
                    startIndex++;
                }
            } while (true);
        }
        public int IndexOfOccurrence(string str, char value, int occurrence)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");

            var currentIndex = 0;
            do
            {
                currentIndex = str.IndexOf(value, currentIndex);

                if (currentIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return currentIndex;
                }
                else
                {
                    occurrence--;
                    currentIndex++;
                }
            } while (true);
        }

        // -- char[] --
        public int IndexOfOccurrence(string str, char[] values, int occurrence, int startIndex, bool backwards, int count)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (values == null)
                throw new ArgumentNullException(nameof(values));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Value cannot be less than 0.");
            else if (!backwards && startIndex + count > str.Length)
                throw new ArgumentOutOfRangeException(nameof(count), $"If parameter {nameof(backwards)} is false, the sum of parameter {nameof(count)} with {nameof(startIndex)} cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (backwards && startIndex + 1 - count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), $"If parameter {nameof(backwards)} is true, the result of {nameof(startIndex)} + 1 - {nameof(count)} must be 0 or positive.");


            var currentIndex = startIndex;
            var currentCount = count;

            do
            {
                if (backwards)
                {
                    currentIndex = str.LastIndexOfAny(values, currentIndex, currentCount);
                }
                else
                {
                    currentIndex = str.IndexOfAny(values, currentIndex, currentCount);
                }

                if (currentIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return currentIndex;
                }
                else
                {
                    occurrence--;
                    currentIndex = backwards ? --currentIndex : ++currentIndex;
                    currentCount = backwards ?
                        count - (startIndex - currentIndex) :
                        count - (currentIndex - startIndex);

                    if (currentIndex == -1)
                    {
                        return -1;
                    }
                }
            } while (true);
        }
        public int IndexOfOccurrence(string str, char[] values, int occurrence, int startIndex, bool backwards)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (values == null)
                throw new ArgumentNullException(nameof(values));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");


            do
            {
                if (backwards)
                {
                    startIndex = str.LastIndexOfAny(values, startIndex);
                }
                else
                {
                    startIndex = str.IndexOfAny(values, startIndex);
                }

                if (startIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return startIndex;
                }
                else
                {
                    occurrence--;
                    startIndex = backwards ? --startIndex : ++startIndex;

                    if (startIndex == -1)
                    {
                        return -1;
                    }
                }
            } while (true);
        }
        public int IndexOfOccurrence(string str, char[] values, int occurrence, bool backwards)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (values == null)
                throw new ArgumentNullException(nameof(values));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");

            var currentIndex = 0;
            do
            {
                if (backwards)
                {
                    currentIndex = str.LastIndexOfAny(values, currentIndex);
                }
                else
                {
                    currentIndex = str.IndexOfAny(values, currentIndex);
                }

                if (currentIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return currentIndex;
                }
                else
                {
                    occurrence--;
                    currentIndex = backwards ? --currentIndex : ++currentIndex;

                    if (currentIndex == -1)
                    {
                        return -1;
                    }
                }
            } while (true);
        }
        public int IndexOfOccurrence(string str, char[] values, int occurrence, int startIndex, int endIndex)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (values == null)
                throw new ArgumentNullException(nameof(values));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (endIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (endIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");

            do
            {
                startIndex = str.IndexOfAny(values, startIndex, endIndex + 1 - startIndex);

                if (startIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return startIndex;
                }
                else
                {
                    occurrence--;
                    startIndex++;
                }
            } while (true);
        }
        public int IndexOfOccurrence(string str, char[] values, int occurrence, int startIndex)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (values == null)
                throw new ArgumentNullException(nameof(values));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");


            do
            {
                startIndex = str.IndexOfAny(values, startIndex);

                if (startIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return startIndex;
                }
                else
                {
                    occurrence--;
                    startIndex++;
                }
            } while (true);
        }
        public int IndexOfOccurrence(string str, char[] values, int occurrence)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (values == null)
                throw new ArgumentNullException(nameof(values));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");

            var currentIndex = 0;
            do
            {
                currentIndex = str.IndexOfAny(values);

                if (currentIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return currentIndex;
                }
                else
                {
                    occurrence--;
                    currentIndex++;
                }
            } while (true);
        }


        // -- char -- simplified
        public int LastIndexOfOccurrence(string str, char value, int occurrence, int startIndex, int count) =>
            IndexOfOccurrence(str, value, occurrence, startIndex, true, count);
        public int LastIndexOfOccurrence(string str, char value, int occurrence, int startIndex) =>
            IndexOfOccurrence(str, value, occurrence, startIndex, true);
        public int LastIndexOfOccurrence(string str, char value, int occurrence) =>
            IndexOfOccurrence(str, value, occurrence, true);

        // -- char[] -- simplified
        public int LastIndexOfOccurrence(string str, char[] values, int occurrence, int startIndex, int count) =>
            IndexOfOccurrence(str, values, occurrence, startIndex, true, count);
        public int LastIndexOfOccurrence(string str, char[] values, int occurrence, int startIndex) =>
            IndexOfOccurrence(str, values, occurrence, startIndex, true);
        public int LastIndexOfOccurrence(string str, char[] values, int occurrence) =>
            IndexOfOccurrence(str, values, occurrence, true);



        // -- string --

        public int IndexOfOccurrence(string str, string value, int occurrence, int startIndex, bool backwards, int count, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (value == null)
                throw new ArgumentNullException(nameof(value));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Value cannot be less than 0.");
            else if (!backwards && startIndex + count > str.Length)
                throw new ArgumentOutOfRangeException(nameof(count), $"If parameter {nameof(backwards)} is false, the sum of parameter {nameof(count)} with {nameof(startIndex)} cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (backwards && startIndex + 1 - count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), $"If parameter {nameof(backwards)} is true, the result of {nameof(startIndex)} + 1 - {nameof(count)} must be 0 or positive.");


            var currentIndex = startIndex;
            var currentCount = count;

            do
            {
                if (backwards)
                {
                    currentIndex = str.LastIndexOf(value, currentIndex, currentCount, stringComparison);
                }
                else
                {
                    currentIndex = str.IndexOf(value, currentIndex, currentCount, stringComparison);
                }

                if (currentIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return currentIndex;
                }
                else
                {
                    occurrence--;
                    currentIndex = backwards ? --currentIndex : ++currentIndex;
                    currentCount = backwards ?
                        count - (startIndex - currentIndex) :
                        count - (currentIndex - startIndex);
                }
            } while (true);
        }
        public int IndexOfOccurrence(string str, string value, int occurrence, int startIndex, bool backwards, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (value == null)
                throw new ArgumentNullException(nameof(value));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");

            do
            {
                if (backwards)
                {
                    startIndex = str.LastIndexOf(value, startIndex, stringComparison);
                }
                else
                {
                    startIndex = str.IndexOf(value, startIndex, stringComparison);
                }

                if (startIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return startIndex;
                }
                else
                {
                    occurrence--;
                    startIndex = backwards ? --startIndex : ++startIndex;
                }
            } while (true);
        }
        public int IndexOfOccurrence(string str, string value, int occurrence, bool backwards, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (value == null)
                throw new ArgumentNullException(nameof(value));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");

            var currentIndex = 0;
            do
            {
                if (backwards)
                {
                    currentIndex = str.LastIndexOf(value, currentIndex, stringComparison);
                }
                else
                {
                    currentIndex = str.IndexOf(value, currentIndex, stringComparison);
                }

                if (currentIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return currentIndex;
                }
                else
                {
                    occurrence--;
                    currentIndex = backwards ? --currentIndex : ++currentIndex;
                }
            } while (true);
        }
        public int IndexOfOccurrence(string str, string value, int occurrence, int startIndex, int endIndex, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");

            do
            {
                startIndex = str.IndexOf(value, startIndex, endIndex + 1 - startIndex, stringComparison);

                if (startIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return startIndex;
                }
                else
                {
                    occurrence--;
                    startIndex++;
                }
            } while (true);
        }
        public int IndexOfOccurrence(string str, string value, int occurrence, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");

            var currentIndex = 0;
            do
            {
                currentIndex = str.IndexOf(value, currentIndex, stringComparison);

                if (currentIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return currentIndex;
                }
                else
                {
                    occurrence--;
                    currentIndex++;
                }
            } while (true);
        }

        // -- string[] --

        public int IndexOfOccurrence(string str, string[] values, int occurrence, int startIndex, bool backwards, int count, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (values == null)
                throw new ArgumentNullException(nameof(values));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Value cannot be less than 0.");
            else if (!backwards && startIndex + count > str.Length)
                throw new ArgumentOutOfRangeException(nameof(count), $"If parameter {nameof(backwards)} is false, the sum of parameter {nameof(count)} with {nameof(startIndex)} cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (backwards && startIndex + 1 - count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), $"If parameter {nameof(backwards)} is true, the result of {nameof(startIndex)} + 1 - {nameof(count)} must be 0 or positive.");


            var currentIndex = startIndex;
            var currentCount = count;

            do
            {
                if (backwards)
                {
                    currentIndex = LastIndexOfAny(str, values, currentIndex, currentCount, stringComparison);
                }
                else
                {
                    currentIndex = IndexOfAny(str, values, currentIndex, currentCount, stringComparison);
                }

                if (currentIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return currentIndex;
                }
                else
                {
                    occurrence--;
                    currentIndex = backwards ? --currentIndex : ++currentIndex;
                    currentCount = backwards ?
                        count - (startIndex - currentIndex) :
                        count - (currentIndex - startIndex);

                    if (currentIndex == -1)
                    {
                        return -1;
                    }
                }
            } while (true);
        } // needs: IndexOfAny and LastIndexOfAny
        public int IndexOfOccurrence(string str, string[] values, int occurrence, int startIndex, bool backwards, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (values == null)
                throw new ArgumentNullException(nameof(values));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");


            do
            {
                if (backwards)
                {
                    startIndex = LastIndexOfAny(str, values, startIndex, stringComparison);
                }
                else
                {
                    startIndex = IndexOfAny(str, values, startIndex, stringComparison);
                }

                if (startIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return startIndex;
                }
                else
                {
                    occurrence--;
                    startIndex = backwards ? --startIndex : ++startIndex;

                    if (startIndex == -1)
                    {
                        return -1;
                    }
                }
            } while (true);
        } // needs: IndexOfAny and LastIndexOfAny
        public int IndexOfOccurrence(string str, string[] values, int occurrence, bool backwards, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (values == null)
                throw new ArgumentNullException(nameof(values));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");
        
            var currentIndex = 0;
            do
            {
                if (backwards)
                {
                    currentIndex = LastIndexOfAny(str, values, currentIndex, stringComparison);
                }
                else
                {
                    currentIndex = IndexOfAny(str, values, currentIndex, stringComparison);
                }

                if (currentIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return currentIndex;
                }
                else
                {
                    occurrence--;
                    currentIndex = backwards ? --currentIndex : ++currentIndex;

                    if (currentIndex == -1)
                    {
                        return -1;
                    }
                }
            } while (true);
        } // needs: IndexOfAny and LastIndexOfAny
        public int IndexOfOccurrence(string str, string[] values, int occurrence, int startIndex, int endIndex, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (values == null)
                throw new ArgumentNullException(nameof(values));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");

            do
            {
                startIndex = IndexOfAny(str, values, startIndex, endIndex + 1 - startIndex, stringComparison);

                if (startIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return startIndex;
                }
                else
                {
                    occurrence--;
                    startIndex++;
                }
            } while (true);
        } // needs: IndexOfAny
        public int IndexOfOccurrence(string str, string[] values, int occurrence, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (values == null)
                throw new ArgumentNullException(nameof(values));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");

            var currentIndex = 0;
            do
            {
                currentIndex = IndexOfAny(str, values, currentIndex, stringComparison);

                if (currentIndex == -1)
                {
                    return -1;
                }
                else if (occurrence == 1)
                {
                    return currentIndex;
                }
                else
                {
                    occurrence--;
                    currentIndex++;
                }
            } while (true);
        } // needs: IndexOfAny


        // -- string -- simplified
        public int LastIndexOfOccurrence(string str, string value, int occurrence, int startIndex, int count, StringComparison stringComparison) =>
            IndexOfOccurrence(str, value, occurrence, startIndex, true, count, stringComparison);
        public int LastIndexOfOccurrence(string str, string value, int occurrence, int startIndex, StringComparison stringComparison) =>
            IndexOfOccurrence(str, value, occurrence, startIndex, true, stringComparison);
        public int LastIndexOfOccurrence(string str, string value, int occurrence, StringComparison stringComparison) =>
            IndexOfOccurrence(str, value, occurrence, true, stringComparison);

        // -- string[] -- simplified
        public int LastIndexOfOccurrence(string str, string[] values, int occurrence, int startIndex, int count, StringComparison stringComparison) =>
            IndexOfOccurrence(str, values, occurrence, startIndex, true, count, stringComparison);
        public int LastIndexOfOccurrence(string str, string[] values, int occurrence, int startIndex, StringComparison stringComparison) =>
            IndexOfOccurrence(str, values, occurrence, startIndex, true, stringComparison);
        public int LastIndexOfOccurrence(string str, string[] values, int occurrence, StringComparison stringComparison) =>
            IndexOfOccurrence(str, values, occurrence, true, stringComparison);


    }
}



