using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringUtilities.Core.IndexOfExpanded
{
    public partial class IndexOfExp
    {

        // -- char --

        public IEnumerable<int> AllIndexesOf(string str, char value, int startIndex, bool backwards, int count)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
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


            var indexes = new List<int>();
            var currentIndex = startIndex;
            var currentCount = count;

            while (currentIndex != -1)
            {
                currentIndex = backwards ?
                    str.LastIndexOf(value, currentIndex, currentCount) :
                    str.IndexOf(value, currentIndex, currentCount);

                if (currentIndex != -1)
                {
                    indexes.Add(currentIndex);
                    currentIndex = backwards ? --currentIndex : ++currentIndex;
                    currentCount = backwards ?
                        count - (startIndex - currentIndex) :
                        count - (currentIndex - startIndex);
                }
            }

            return indexes;
        }
        public IEnumerable<int> AllIndexesOf(string str, char value, int startIndex, bool backwards)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");


            var indexes = new List<int>();

            while (startIndex != -1)
            {
                startIndex = backwards ?
                    str.LastIndexOf(value, startIndex) :
                    str.IndexOf(value, startIndex);

                if (startIndex != -1)
                {
                    indexes.Add(startIndex);
                    startIndex = backwards ? --startIndex : ++startIndex;
                }
            }

            return indexes;
        }
        public IEnumerable<int> AllIndexesOf(string str, char value, int startIndex, int endIndex)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (endIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(endIndex), $"Value cannot be less than 0.");
            else if (endIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(endIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (endIndex < startIndex)
                throw new ArgumentException($"Parameter {nameof(startIndex)} cannot be greater than parameter {nameof(endIndex)}.");


            var indexes = new List<int>();

            while (startIndex != -1 && startIndex < str.Length)
            {
                startIndex = str.IndexOf(value, startIndex, endIndex + 1 - startIndex);

                if (startIndex != -1)
                {
                    indexes.Add(startIndex);
                    startIndex++;
                }
            }

            return indexes;
        }
        public IEnumerable<int> AllIndexesOf(string str, char[] values, int startIndex, bool backwards, int count)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (values == null)
                throw new ArgumentNullException(nameof(values));
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


            var indexes = new List<int>();
            var currentIndex = startIndex;
            var currentCount = count;

            while (currentIndex != -1)
            {
                currentIndex = backwards ?
                    str.LastIndexOfAny(values, currentIndex, currentCount) :
                    str.IndexOfAny(values, currentIndex, currentCount);

                if (currentIndex != -1)
                {
                    indexes.Add(currentIndex);
                    currentIndex = backwards ? --currentIndex : ++currentIndex;
                    currentCount = backwards ?
                        count - (startIndex - currentIndex) :
                        count - (currentIndex - startIndex);
                }
            }

            return indexes;
        }
        public IEnumerable<int> AllIndexesOf(string str, char[] values, int startIndex, bool backwards)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (values == null)
                throw new ArgumentNullException(nameof(values));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");


            var indexes = new List<int>();

            while (startIndex != -1)
            {
                startIndex = backwards ?
                    str.LastIndexOfAny(values, startIndex) :
                    str.IndexOfAny(values, startIndex);

                if (startIndex != -1)
                {
                    indexes.Add(startIndex);
                    startIndex = backwards ? --startIndex : ++startIndex;
                }
            }

            return indexes;
        }
        public IEnumerable<int> AllIndexesOf(string str, char[] values, int startIndex, int endIndex)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (values == null)
                throw new ArgumentNullException(nameof(values));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (endIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(endIndex), $"Value cannot be less than 0.");
            else if (endIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(endIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (endIndex < startIndex)
                throw new ArgumentException($"Parameter {nameof(startIndex)} cannot be greater than parameter {nameof(endIndex)}.");


            var indexes = new List<int>();

            while (startIndex != -1 && startIndex < str.Length)
            {
                startIndex = str.IndexOfAny(values, startIndex, endIndex + 1 - startIndex);

                if (startIndex != -1)
                {
                    indexes.Add(startIndex);
                    ++startIndex;
                }
            }

            return indexes;
        }

        // -- char -- simplified

        public IEnumerable<int> AllIndexesOf(string str, char value) =>
            AllIndexesOf(str, value, 0, false);
        public IEnumerable<int> AllIndexesOf(string str, char[] values) =>
            AllIndexesOf(str, values, 0, false);



        // -- string --

        public IEnumerable<int> AllIndexesOf(string str, string value, int startIndex, bool backwards, int count, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (value == null)
                throw new ArgumentNullException(nameof(value));
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


            var indexes = new List<int>();
            var currentIndex = startIndex;
            var currentCount = count;

            while (currentIndex != -1)
            {
                currentIndex = backwards ?
                    str.LastIndexOf(value, currentIndex, currentCount, stringComparison) :
                    str.IndexOf(value, currentIndex, currentCount, stringComparison);

                if (currentIndex != -1)
                {
                    indexes.Add(currentIndex);
                    currentIndex = backwards ? --currentIndex : ++currentIndex;
                    currentCount = backwards ?
                        count - (startIndex - currentIndex) :
                        count - (currentIndex - startIndex);
                }
            }

            return indexes;
        }
        public IEnumerable<int> AllIndexesOf(string str, string value, int startIndex, bool backwards, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (value == null)
                throw new ArgumentNullException(nameof(value));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");


            var indexes = new List<int>();

            while (startIndex != -1)
            {
                startIndex = backwards ?
                    str.LastIndexOf(value, startIndex, stringComparison) :
                    str.IndexOf(value, startIndex, stringComparison);

                if (startIndex != -1)
                {
                    indexes.Add(startIndex);
                    startIndex = backwards ? --startIndex : ++startIndex;
                }
            }

            return indexes;
        }
        public IEnumerable<int> AllIndexesOf(string str, string value, int startIndex, int endIndex, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (value == null)
                throw new ArgumentNullException(nameof(value));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (endIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(endIndex), "Value cannot be less than 0.");
            else if (endIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(endIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (endIndex < startIndex)
                throw new ArgumentException($"Parameter {nameof(startIndex)} cannot be greater than parameter {nameof(endIndex)}.");


            var indexes = new List<int>();

            while (startIndex != -1 && startIndex < str.Length)
            {
                startIndex = str.IndexOf(value, startIndex, endIndex + 1 - startIndex, stringComparison);

                if (startIndex != -1)
                {
                    indexes.Add(startIndex);
                    ++startIndex;
                }
            }

            return indexes;
        }
        public IEnumerable<int> AllIndexesOf(string str, string[] values, int startIndex, bool backwards, int count, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (values == null)
                throw new ArgumentNullException(nameof(values));
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


            var indexes = new List<int>();
            var currentIndex = startIndex;
            var currentCount = count;

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == null)
                {
                    throw new ArgumentNullException(nameof(values), $"Parameter {nameof(values)} cannot contain nulls.");
                }
                else if (values[i] == string.Empty)
                {
                    continue;
                }

                while (currentIndex != -1)
                {
                    currentIndex = backwards ?
                        str.LastIndexOf(values[i], currentIndex, currentCount, stringComparison) :
                        str.IndexOf(values[i], currentIndex, currentCount, stringComparison);

                    if (currentIndex != -1)
                    {
                        indexes.Add(currentIndex);
                        currentIndex = backwards ? --currentIndex : ++currentIndex;
                        currentCount = backwards ?
                            count - (startIndex - currentIndex) :
                            count - (currentIndex - startIndex);
                    }
                }

                currentIndex = startIndex;
                currentCount = count;
            }

            if (backwards)
            {
                indexes.Sort((x, y) => y.CompareTo(x));
            }
            else
            {
                indexes.Sort();
            }

            return indexes;
        }
        public IEnumerable<int> AllIndexesOf(string str, string[] values, int startIndex, bool backwards, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (values == null)
                throw new ArgumentNullException(nameof(values));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");


            var indexes = new List<int>();
            var currentIndex = startIndex;

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == null)
                {
                    throw new ArgumentNullException(nameof(values), $"Parameter {nameof(values)} cannot contain nulls.");
                }
                else if (values[i] == string.Empty)
                {
                    continue;
                }

                while (currentIndex != -1)
                {
                    currentIndex = backwards ?
                        str.LastIndexOf(values[i], currentIndex, stringComparison) :
                        str.IndexOf(values[i], currentIndex, stringComparison);

                    if (currentIndex != -1)
                    {
                        indexes.Add(currentIndex);
                        currentIndex = backwards ? --currentIndex : ++currentIndex;
                    }
                }

                currentIndex = startIndex;
            }

            if (backwards)
            {
                indexes.Sort((x, y) => y.CompareTo(x));
            }
            else
            {
                indexes.Sort();
            }

            return indexes;
        }
        public IEnumerable<int> AllIndexesOf(string str, string[] values, int startIndex, int endIndex, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (values == null)
                throw new ArgumentNullException(nameof(values));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (endIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(endIndex), "Value cannot be less than 0.");
            else if (endIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(endIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (endIndex < startIndex)
                throw new ArgumentException($"Parameter {nameof(startIndex)} cannot be greater than parameter {nameof(endIndex)}.");


            var indexes = new List<int>();
            var currentIndex = startIndex;

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == null)
                {
                    throw new ArgumentNullException(nameof(values), $"Parameter {nameof(values)} cannot contain nulls.");
                }
                else if (values[i] == string.Empty)
                {
                    continue;
                }

                while (currentIndex != -1 && currentIndex < str.Length)
                {
                    currentIndex = str.IndexOf(values[i], currentIndex, endIndex + 1 - currentIndex, stringComparison);

                    if (currentIndex != -1)
                    {
                        indexes.Add(currentIndex);
                        ++currentIndex;
                    }
                }

                currentIndex = startIndex;
            }

            indexes.Sort();

            return indexes;
        }

        // -- string -- simplified

        public IEnumerable<int> AllIndexesOf(string str, string value, StringComparison stringComparison) =>
            AllIndexesOf(str, value, 0, false, stringComparison);
        public IEnumerable<int> AllIndexesOf(string str, string[] values, StringComparison stringComparison) =>
            AllIndexesOf(str, values, 0, false, stringComparison);



    }
}
