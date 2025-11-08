using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StringUtilities.Core.ReplaceExpanded
{
    public partial class ReplaceExp
    {

        public string ReplaceAtOccurrence(string str, char oldValue, char newValue, int occurrence)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");

            int openIndex = 0;
            do
            {
                openIndex = str.IndexOf(oldValue, openIndex);

                if (openIndex == -1)
                {
                    return str;
                }
                else if (occurrence == 1)
                {
                    break;
                }
                else
                {
                    occurrence--;
                    openIndex++;
                }
            } while (true);

            str = str.Remove(openIndex, 1);
            str = str.Insert(openIndex, newValue.ToString());

            return str;
        }
        public string ReplaceAtOccurrence(string str, char oldValue, char newValue, int occurrence, int replaceCount)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");
            else if (replaceCount < 1)
                throw new ArgumentOutOfRangeException(nameof(replaceCount), "Value cannot be less than 1.");

            do
            {
                int openIndex = 0;
                do
                {
                    openIndex = str.IndexOf(oldValue, openIndex);

                    if (openIndex == -1)
                    {
                        return str;
                    }
                    else if (occurrence == 1)
                    {
                        break;
                    }
                    else
                    {
                        occurrence--;
                        openIndex++;
                    }
                } while (true);

                str = str.Remove(openIndex, 1);
                str = str.Insert(openIndex, newValue.ToString());

                replaceCount--;

            } while (replaceCount != 0);

            return str;
        }

        public string ReplaceAtOccurrence(string str, string oldValue, string newValue, int occurrence, StringComparison stringComparison)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (oldValue == null)
                throw new ArgumentNullException(nameof(oldValue));
            else if (newValue == null)
                throw new ArgumentNullException(nameof(newValue));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");

            int openIndex = 0;
            do
            {
                openIndex = str.IndexOf(oldValue, openIndex, stringComparison);

                if (openIndex == -1)
                {
                    return str;
                }
                else if (occurrence == 1)
                {
                    break;
                }
                else
                {
                    occurrence--;
                    openIndex++;
                }
            } while (true);

            str = str.Remove(openIndex, oldValue.Length);
            str = str.Insert(openIndex, newValue);

            return str;
        }
        public string ReplaceAtOccurrence(string str, string oldValue, string newValue, int occurrence, int replaceCount, StringComparison stringComparison)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (oldValue == null)
                throw new ArgumentNullException(nameof(oldValue));
            else if (newValue == null)
                throw new ArgumentNullException(nameof(newValue));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");
            else if (replaceCount < 1)
                throw new ArgumentOutOfRangeException(nameof(replaceCount), "Value cannot be less than 1.");

            do
            {
                int openIndex = 0;
                do
                {
                    openIndex = str.IndexOf(oldValue, openIndex, stringComparison);

                    if (openIndex == -1)
                    {
                        return str;
                    }
                    else if (occurrence == 1)
                    {
                        break;
                    }
                    else
                    {
                        occurrence--;
                        openIndex++;
                    }
                } while (true);

                str = str.Remove(openIndex, oldValue.Length);
                str = str.Insert(openIndex, newValue);

                replaceCount--;

            } while (replaceCount != 0);

            return str;
        }




    }
}
