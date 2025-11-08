using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringUtilities.Core.IndexOfExpanded
{
    public partial class IndexOfExp
    {
        public int IndexOfAny(string str, string[] values, int startIndex, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");


            int minIndex = -1;

            foreach (var value in values)
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(values), $"Parameter {nameof(values)} cannot contain nulls.");
                }

                int index = str.IndexOf(value, startIndex, stringComparison);
                if (index != -1 && (minIndex == -1 || index < minIndex))
                {
                    minIndex = index;
                }
            }

            return minIndex;
        }
        public int IndexOfAny(string str, string[] values, int startIndex, int count, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Value cannot be less than 0.");
            else if (startIndex + count > str.Length)
                throw new ArgumentOutOfRangeException(nameof(count), $"Sum of parameter {nameof(count)} with {nameof(startIndex)} cannot be greater than parameter {nameof(str)}'s Lenght.");


            int minIndex = -1;

            foreach (var value in values)
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(values), $"Parameter {nameof(values)} cannot contain nulls.");
                }

                int index = str.IndexOf(value, startIndex, count, stringComparison);
                if (index != -1 && (minIndex == -1 || index < minIndex))
                {
                    minIndex = index;
                    count = minIndex - startIndex;
                }
            }

            return minIndex;
        }
        public int LastIndexOfAny(string str, string[] values, int startIndex, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");


            int maxIndex = -1;

            foreach (var value in values)
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(values), $"Parameter {nameof(values)} cannot contain nulls.");
                }

                int index = str.LastIndexOf(value, startIndex, stringComparison);
                if (index != -1 && index > maxIndex)
                {
                    maxIndex = index;
                }
            }

            return maxIndex;
        }
        public int LastIndexOfAny(string str, string[] values, int startIndex, int count, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Value cannot be less than 0.");
            else if (startIndex + 1 - count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), $"The result of {nameof(startIndex)} + 1 - {nameof(count)} must be 0 or positive.");


            int maxIndex = -1;

            foreach (var value in values)
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(values), $"Parameter {nameof(values)} cannot contain nulls.");
                }

                int index = str.LastIndexOf(value, startIndex, count, stringComparison);
                if (index != -1 && index > maxIndex)
                {
                    maxIndex = index;
                    count = startIndex - maxIndex + value.Length - 1;
                }
            }

            return maxIndex;
        }



    }
}
