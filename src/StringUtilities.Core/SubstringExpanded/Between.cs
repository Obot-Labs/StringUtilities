using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringUtilities.Core.SubstringExpanded
{
    public partial class SubstringExp
    {
        // SubstringOnStringLimits
        // not mandatory to find both limits
        // if only first is found, substrings from it to the end, if only the second, substrings from the startIndex to it, if none is found returns string.Empty
        // if both are found, checks and validates the lowest index before substringing 
        public string SubstringOnStringLimits(string str, int startIndex, string strLimit1, string strLimit2, bool requiresBoth, bool includeLimitStrings, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (strLimit1 == null)
                throw new ArgumentNullException(nameof(strLimit1));
            else if (strLimit2 == null)
                throw new ArgumentNullException(nameof(strLimit2));


            var limit1Index = str.IndexOf(strLimit1, startIndex, stringComparison);
            var limit2Index = str.IndexOf(strLimit2, startIndex, stringComparison);

            if ((requiresBoth && (limit1Index == -1 || limit2Index == -1)) ||
                (limit1Index == -1 && limit2Index == -1))
            {
                return string.Empty;
            }
            else if (limit1Index == limit2Index)
            {
                if (!includeLimitStrings)
                {
                    return string.Empty;
                }
                else
                {
                    // return smallest
                    return strLimit1.Length > strLimit2.Length ? strLimit2 : strLimit1;
                }
            }
            else if (limit1Index == -1 && limit2Index != -1)
            {
                return str.Substring(startIndex, (includeLimitStrings ? limit2Index + strLimit2.Length : limit2Index) - startIndex);
            }
            else if (limit1Index != -1 && limit2Index == -1)
            {
                return str.Substring(includeLimitStrings ? limit1Index : limit1Index + strLimit1.Length);
            }
            else
            {
                var swapped = false;

                if (limit1Index > limit2Index)
                {
                    //(openIndex, closeIndex) = (closeIndex, openIndex);
                    limit1Index = limit2Index + limit1Index;
                    limit2Index = limit1Index - limit2Index;
                    limit1Index = limit1Index - limit2Index;
                    swapped = true;
                }

                return str.Substring(includeLimitStrings ?
                                        limit1Index :
                                        limit1Index + (swapped ? strLimit2.Length : strLimit1.Length),
                                       includeLimitStrings ?
                                        (limit2Index + (swapped ? strLimit1.Length : strLimit2.Length)) - limit1Index :
                                        limit2Index - (limit1Index + (swapped ? strLimit2.Length : strLimit1.Length)));
            }
        }
        public string SubstringOnStringLimits(string str, int startIndex, string strLimit1, int limit1occurrence, string strLimit2, int limit2occurrence, bool requiresBoth, bool includeLimitStrings, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (strLimit1 == null)
                throw new ArgumentNullException(nameof(strLimit1));
            else if (strLimit2 == null)
                throw new ArgumentNullException(nameof(strLimit2));
            else if (limit1occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(limit1occurrence), "Value cannot be less than 1.");
            else if (limit2occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(limit2occurrence), "Value cannot be less than 1.");


            // find limit1Index of limit1occurrence
            int limit1Index = startIndex;
            do
            {
                limit1Index = str.IndexOf(strLimit1, limit1Index, stringComparison);

                if (limit1occurrence == 1 || limit1Index == -1)
                {
                    break;
                }
                else
                {
                    limit1occurrence--;
                    limit1Index++;
                }

            } while (true);

            // find limit2Index of limit2occurrence
            int limit2Index = startIndex;
            do
            {
                limit2Index = str.IndexOf(strLimit2, limit2Index, stringComparison);

                if (limit2occurrence == 1 || limit2Index == -1)
                {
                    break;
                }
                else
                {
                    limit2occurrence--;
                    limit2Index++;
                }

            } while (true);

            // substring accordingly
            if ((requiresBoth && (limit1Index == -1 || limit2Index == -1)) ||
                (limit1Index == -1 && limit2Index == -1))
            {
                return string.Empty;
            }
            else if (limit1Index == limit2Index)
            {
                if (!includeLimitStrings)
                {
                    return string.Empty;
                }
                else
                {
                    // return smallest
                    return strLimit1.Length > strLimit2.Length ? strLimit2 : strLimit1;
                }
            }
            else if (limit1Index == -1 && limit2Index != -1)
            {
                return str.Substring(startIndex, (includeLimitStrings ? limit2Index + strLimit2.Length : limit2Index) - startIndex);
            }
            else if (limit1Index != -1 && limit2Index == -1)
            {
                return str.Substring(includeLimitStrings ? limit1Index : limit1Index + strLimit1.Length);
            }
            else
            {
                var swapped = false;

                if (limit1Index > limit2Index)
                {
                    //(openIndex, closeIndex) = (closeIndex, openIndex);
                    limit1Index = limit2Index + limit1Index;
                    limit2Index = limit1Index - limit2Index;
                    limit1Index = limit1Index - limit2Index;
                    swapped = true;
                }

                return str.Substring(includeLimitStrings ?
                                        limit1Index :
                                        limit1Index + (swapped ? strLimit2.Length : strLimit1.Length),
                                       includeLimitStrings ?
                                        (limit2Index + (swapped ? strLimit1.Length : strLimit2.Length)) - limit1Index :
                                        limit2Index - (limit1Index + (swapped ? strLimit2.Length : strLimit1.Length)));
            }
        }


        // SubstringBetweenStrings
        // mandatory to find both, with openString in a lower index than closeString. If either is not found, returns string.Empty
        public string SubstringBetweenStrings(string str, int startIndex, string openString, string closeString, bool includeLimitStrings, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (openString == null)
                throw new ArgumentNullException(nameof(openString));
            else if (closeString == null)
                throw new ArgumentNullException(nameof(closeString));


            var openIndex = str.IndexOf(openString, startIndex, stringComparison);

            if (openIndex == -1)
            {
                return string.Empty;
            }

            var closeIndex = str.IndexOf(closeString, openIndex + 1, stringComparison);

            if (closeIndex == -1)
            {
                return string.Empty;
            }

            return str.Substring(includeLimitStrings ?
                           openIndex : openIndex + openString.Length,
                          includeLimitStrings ?
                           (closeIndex + closeString.Length) - openIndex :
                           closeIndex - (openIndex + openString.Length));
        }
        public string SubstringBetweenStrings(string str, int startIndex, string openString, string closeString, int occurrence, bool includeLimitStrings, bool considerNestedStructures, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (openString == null)
                throw new ArgumentNullException(nameof(openString));
            else if (closeString == null)
                throw new ArgumentNullException(nameof(closeString));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");


            // find openIndex of occurrence
            int openIndex = startIndex;
            do
            {
                openIndex = str.IndexOf(openString, openIndex, stringComparison);

                if (openIndex == -1)
                {
                    return string.Empty;
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


            // find closeIndex 
            var closeIndex = 0;
            if (!considerNestedStructures)
            {
                closeIndex = str.IndexOf(closeString, openIndex + 1, stringComparison);

                if (closeIndex == -1)
                {
                    return string.Empty;
                }

                return str.Substring(includeLimitStrings ?
                               openIndex : openIndex + openString.Length,
                              includeLimitStrings ?
                               (closeIndex + closeString.Length) - openIndex :
                               closeIndex - (openIndex + openString.Length));
            }
            else
            {
                int innerOpenIndex = 0;
                int innerOpenIndexAmount = 0;
                int currentIndex = openIndex + 1;

                do
                {
                    // find the next close index
                    closeIndex = str.IndexOf(closeString, currentIndex, stringComparison);

                    // safeguard
                    if (closeIndex == -1)
                    {
                        return string.Empty;
                    }

                    do
                    {
                        // find how many open indexes are before the close index
                        innerOpenIndex = str.IndexOf(openString, currentIndex, stringComparison);

                        if (closeIndex > innerOpenIndex && innerOpenIndex != -1)
                        {
                            innerOpenIndexAmount++;
                            currentIndex = innerOpenIndex + 1;
                        }

                    } while (closeIndex > innerOpenIndex && innerOpenIndex != -1);

                    // if there are open indexes, make another iteration to find the correct close index
                    if (innerOpenIndexAmount > 0)
                    {
                        innerOpenIndexAmount--;
                        currentIndex = closeIndex + 1;
                    }
                    else
                    {
                        break;
                    }

                } while (true);

                return str.Substring(includeLimitStrings ?
                                           openIndex : openIndex + openString.Length,
                                          includeLimitStrings ?
                                           (closeIndex + closeString.Length) - openIndex :
                                           closeIndex - (openIndex + openString.Length));
            }
        }
        public string SubstringBetweenStrings(string str, int startIndex, string openString, int openStringOccurrence, string closeString, int closeStringOccurrence, bool includeLimitStrings, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (openString == null)
                throw new ArgumentNullException(nameof(openString));
            else if (closeString == null)
                throw new ArgumentNullException(nameof(closeString));
            else if (openStringOccurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(openStringOccurrence), "Value cannot be less than 1.");
            else if (closeStringOccurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(closeStringOccurrence), "Value cannot be less than 1.");


            int openIndex = startIndex;
            do
            {
                openIndex = str.IndexOf(openString, openIndex, stringComparison);

                if (openIndex == -1)
                {
                    return string.Empty;
                }
                else if (openStringOccurrence == 1)
                {
                    break;
                }
                else
                {
                    openStringOccurrence--;
                    openIndex++;
                }
            } while (true);


            int closeIndex = openIndex + 1;
            do
            {
                closeIndex = str.IndexOf(closeString, closeIndex, stringComparison);

                if (closeIndex == -1)
                {
                    return string.Empty;
                }
                else if (closeStringOccurrence == 1)
                {
                    break;
                }
                else
                {
                    closeStringOccurrence--;
                    closeIndex++;
                }
            } while (true);

            return str.Substring(includeLimitStrings ?
                               openIndex : openIndex + openString.Length,
                              includeLimitStrings ?
                               (closeIndex + closeString.Length) - openIndex :
                               closeIndex - (openIndex + openString.Length));
        }
        public string SubstringBetweenStrings(string str, int startIndex, string startOpenString, string endOpenString, string startCloseString, string endCloseString, int occurrence, bool includeLimitStrings, bool considerNestedStructures, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            else if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            else if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Lenght.");
            else if (startOpenString == null)
                throw new ArgumentNullException(nameof(startOpenString));
            else if (endOpenString == null)
                throw new ArgumentNullException(nameof(endOpenString));
            else if (startCloseString == null)
                throw new ArgumentNullException(nameof(startCloseString));
            else if (endCloseString == null)
                throw new ArgumentNullException(nameof(endCloseString));
            else if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");


            // find startOpenIndex of occurrence
            int startOpenIndex = startIndex;
            do
            {
                startOpenIndex = str.IndexOf(startOpenString, startOpenIndex, stringComparison);

                if (startOpenIndex == -1)
                {
                    return string.Empty;
                }
                else if (occurrence == 1)
                {
                    break;
                }
                else
                {
                    occurrence--;
                    startOpenIndex++;
                }
            } while (true);


            // find endOpenIndex
            int endOpenIndex = str.IndexOf(endOpenString, startOpenIndex + 1, stringComparison);
            if (endOpenIndex == -1)
            {
                return string.Empty;
            }


            // find startCloseIndex 
            var startCloseIndex = 0;
            if (!considerNestedStructures)
            {
                startCloseIndex = str.IndexOf(startCloseString, endOpenIndex + 1, stringComparison);

                if (startCloseIndex == -1)
                {
                    return string.Empty;
                }
            }
            else
            {
                int innerOpenIndex = 0;
                int innerOpenIndexAmount = 0;
                int currentIndex = endOpenIndex + 1;

                do
                {
                    // find the next close index
                    startCloseIndex = str.IndexOf(startCloseString, currentIndex, stringComparison);

                    // safeguard
                    if (startCloseIndex == -1)
                    {
                        return string.Empty;
                    }

                    do
                    {
                        // find how many open indexes are before the close index
                        innerOpenIndex = str.IndexOf(startOpenString, currentIndex, stringComparison);

                        if (startCloseIndex > innerOpenIndex && innerOpenIndex != -1)
                        {
                            innerOpenIndexAmount++;
                            currentIndex = innerOpenIndex + 1;
                        }

                    } while (startCloseIndex > innerOpenIndex && innerOpenIndex != -1);

                    // if there are open indexes, make another iteration to find the correct close index
                    if (innerOpenIndexAmount > 0)
                    {
                        innerOpenIndexAmount--;
                        currentIndex = startCloseIndex + 1;
                    }
                    else
                    {
                        break;
                    }

                } while (true);
            }


            // find endCloseIndex 
            var endCloseIndex = str.IndexOf(endCloseString, startCloseIndex + 1, stringComparison);

            if (endCloseIndex == -1)
            {
                return string.Empty;
            }

            // startOpenIndex | endOpenIndex | startCloseIndex | endCloseIndex

            return includeLimitStrings ?
                str.Substring(startOpenIndex, endCloseIndex + endCloseString.Length - startOpenIndex) :
                str.Substring(endOpenIndex + endOpenString.Length, startCloseIndex - (endOpenIndex + endOpenString.Length));
        }




    }
}
