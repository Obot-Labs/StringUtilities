using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringUtilities.Core.RemoveExpanded
{
    public partial class RemoveExp
    {
        public string RemoveBetweenStrings(string str, int startIndex, string openString, string closeString, bool considerNestedStructures, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Length.");
            if (openString == null)
                throw new ArgumentNullException(nameof(openString));
            if (closeString == null)
                throw new ArgumentNullException(nameof(closeString));

            do
            {
                // find openIndex
                var openIndex = str.IndexOf(openString, startIndex, stringComparison);
                if (openIndex == -1)
                {
                    return str;
                }

                // find closeIndex 
                var closeIndex = 0;
                if (!considerNestedStructures)
                {
                    closeIndex = str.IndexOf(closeString, openIndex + openString.Length, stringComparison);

                    if (closeIndex == -1)
                    {
                        return str;
                    }
                }
                else
                {
                    int innerOpenIndex = 0;
                    int innerOpenIndexAmount = 0;
                    int currentIndex = openIndex + openString.Length;

                    do
                    {
                        // find the next close index
                        closeIndex = str.IndexOf(closeString, currentIndex, stringComparison);

                        // safeguard
                        if (closeIndex == -1)
                        {
                            return str;
                        }

                        do
                        {
                            // find how many open indexes are before the close index
                            innerOpenIndex = str.IndexOf(openString, currentIndex, stringComparison);

                            if (closeIndex > innerOpenIndex && innerOpenIndex != -1)
                            {
                                innerOpenIndexAmount++;
                                currentIndex = innerOpenIndex + openString.Length;
                            }

                        } while (closeIndex > innerOpenIndex && innerOpenIndex != -1);

                        // if there are open indexes, make another iteration to find the correct close index
                        if (innerOpenIndexAmount > 0)
                        {
                            innerOpenIndexAmount--;
                            currentIndex = closeIndex + closeString.Length;
                        }
                        else
                        {
                            break;
                        }

                    } while (true);
                }

                str = str.Substring(0, openIndex) + str.Substring(closeIndex + closeString.Length);

            } while (true); // remove all
        } // removes all occurrences
        public string RemoveBetweenStrings(string str, int startIndex, string openString, string closeString, bool considerNestedStructures, Func<string, bool> substringConditionToRemove, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Length.");
            if (openString == null)
                throw new ArgumentNullException(nameof(openString));
            if (closeString == null)
                throw new ArgumentNullException(nameof(closeString));
            if (substringConditionToRemove == null)
                throw new ArgumentNullException(nameof(substringConditionToRemove));

            var openIndex = startIndex;
            do
            {
                // find openIndex
                openIndex = str.IndexOf(openString, openIndex, stringComparison);
                if (openIndex == -1)
                {
                    return str;
                }

                // find closeIndex 
                var closeIndex = 0;
                if (!considerNestedStructures)
                {
                    closeIndex = str.IndexOf(closeString, openIndex + openString.Length, stringComparison);

                    if (closeIndex == -1)
                    {
                        return str;
                    }
                }
                else
                {
                    int innerOpenIndex = 0;
                    int innerOpenIndexAmount = 0;
                    int currentIndex = openIndex + openString.Length;

                    do
                    {
                        // find the next close index
                        closeIndex = str.IndexOf(closeString, currentIndex, stringComparison);

                        // safeguard
                        if (closeIndex == -1)
                        {
                            return str;
                        }

                        do
                        {
                            // find how many open indexes are before the close index
                            innerOpenIndex = str.IndexOf(openString, currentIndex, stringComparison);

                            if (closeIndex > innerOpenIndex && innerOpenIndex != -1)
                            {
                                innerOpenIndexAmount++;
                                currentIndex = innerOpenIndex + openString.Length;
                            }

                        } while (closeIndex > innerOpenIndex && innerOpenIndex != -1);

                        // if there are open indexes, make another iteration to find the correct close index
                        if (innerOpenIndexAmount > 0)
                        {
                            innerOpenIndexAmount--;
                            currentIndex = closeIndex + closeString.Length;
                        }
                        else
                        {
                            break;
                        }

                    } while (true);
                }

                // check substringConditionToRemove delegate with the substring to remove to see if it is indeed to remove
                if (substringConditionToRemove(str.Substring(openIndex, (closeIndex + closeString.Length) - openIndex)))
                {
                    str = str.Substring(0, openIndex) + str.Substring(closeIndex + closeString.Length);
                }
                else
                {
                    openIndex += openString.Length;
                }

            } while (true); // remove all
        } // removes all occurrences

        public string RemoveBetweenStrings(string str, int startIndex, string openString, string closeString, int occurrence, bool considerNestedStructures, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Length.");
            if (openString == null)
                throw new ArgumentNullException(nameof(openString));
            if (closeString == null)
                throw new ArgumentNullException(nameof(closeString));
            if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");

            // find openIndex of occurrence
            int openIndex = startIndex;
            do
            {
                openIndex = str.IndexOf(openString, openIndex, stringComparison);

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
                    openIndex += openString.Length;
                }
            } while (true);

            // find closeIndex 
            var closeIndex = 0;
            if (!considerNestedStructures)
            {
                closeIndex = str.IndexOf(closeString, openIndex + openString.Length, stringComparison);

                if (closeIndex == -1)
                {
                    return str;
                }
            }
            else
            {
                int innerOpenIndex = 0;
                int innerOpenIndexAmount = 0;
                int currentIndex = openIndex + openString.Length;

                do
                {
                    // find the next close index
                    closeIndex = str.IndexOf(closeString, currentIndex, stringComparison);

                    // safeguard
                    if (closeIndex == -1)
                    {
                        return str;
                    }

                    do
                    {
                        // find how many open indexes are before the close index
                        innerOpenIndex = str.IndexOf(openString, currentIndex, stringComparison);

                        if (closeIndex > innerOpenIndex && innerOpenIndex != -1)
                        {
                            innerOpenIndexAmount++;
                            currentIndex = innerOpenIndex + openString.Length;
                        }

                    } while (closeIndex > innerOpenIndex && innerOpenIndex != -1);

                    // if there are open indexes, make another iteration to find the correct close index
                    if (innerOpenIndexAmount > 0)
                    {
                        innerOpenIndexAmount--;
                        currentIndex = closeIndex + closeString.Length;
                    }
                    else
                    {
                        break;
                    }

                } while (true);
            }

            return str.Substring(0, openIndex) + str.Substring(closeIndex + closeString.Length);
        }
        public string RemoveBetweenStrings(string str, int startIndex, string openString, string closeString, int occurrence, bool considerNestedStructures, Func<string, bool> substringConditionToRemove, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Length.");
            if (openString == null)
                throw new ArgumentNullException(nameof(openString));
            if (closeString == null)
                throw new ArgumentNullException(nameof(closeString));
            if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");
            if (substringConditionToRemove == null)
                throw new ArgumentNullException(nameof(substringConditionToRemove));

            // find openIndex of occurrence
            int openIndex = startIndex;

            do
            {
                openIndex = str.IndexOf(openString, openIndex, stringComparison);

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
                    openIndex += openString.Length;
                }
            } while (true);

            // find closeIndex 
            var closeIndex = 0;
            if (!considerNestedStructures)
            {
                closeIndex = str.IndexOf(closeString, openIndex + openString.Length, stringComparison);

                if (closeIndex == -1)
                {
                    return str;
                }
            }
            else
            {
                int innerOpenIndex = 0;
                int innerOpenIndexAmount = 0;
                int currentIndex = openIndex + openString.Length;

                do
                {
                    // find the next close index
                    closeIndex = str.IndexOf(closeString, currentIndex, stringComparison);

                    // safeguard
                    if (closeIndex == -1)
                    {
                        return str;
                    }

                    do
                    {
                        // find how many open indexes are before the close index
                        innerOpenIndex = str.IndexOf(openString, currentIndex, stringComparison);

                        if (closeIndex > innerOpenIndex && innerOpenIndex != -1)
                        {
                            innerOpenIndexAmount++;
                            currentIndex = innerOpenIndex + openString.Length;
                        }

                    } while (closeIndex > innerOpenIndex && innerOpenIndex != -1);

                    // if there are open indexes, make another iteration to find the correct close index
                    if (innerOpenIndexAmount > 0)
                    {
                        innerOpenIndexAmount--;
                        currentIndex = closeIndex + closeString.Length;
                    }
                    else
                    {
                        break;
                    }

                } while (true);
            }

            // check substringConditionToRemove delegate to see if it is indeed to remove
            if (substringConditionToRemove(str.Substring(openIndex, (closeIndex + closeString.Length) - openIndex)))
            {
                return str.Substring(0, openIndex) + str.Substring(closeIndex + closeString.Length);
            }
            else
            {
                return str;
            }
        }

        public string RemoveBetweenStrings(string str, int startIndex, string startOpenString, string endOpenString, string startCloseString, string endCloseString, int occurrence, bool considerNestedStructures, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Length.");
            if (startOpenString == null)
                throw new ArgumentNullException(nameof(startOpenString));
            if (endOpenString == null)
                throw new ArgumentNullException(nameof(endOpenString));
            if (startCloseString == null)
                throw new ArgumentNullException(nameof(startCloseString));
            if (endCloseString == null)
                throw new ArgumentNullException(nameof(endCloseString));
            if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");

            // find startOpenIndex of the specified occurrence
            int startOpenIndex = startIndex;
            do
            {
                startOpenIndex = str.IndexOf(startOpenString, startOpenIndex, stringComparison);

                if (startOpenIndex == -1)
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
                    startOpenIndex += startOpenString.Length;
                }
            } while (true);

            // find endOpenIndex
            int endOpenIndex = str.IndexOf(endOpenString, startOpenIndex + startOpenString.Length, stringComparison);
            if (endOpenIndex == -1)
            {
                return str;
            }

            // find startCloseIndex 
            int startCloseIndex = 0;
            if (!considerNestedStructures)
            {
                startCloseIndex = str.IndexOf(startCloseString, endOpenIndex + endOpenString.Length, stringComparison);
                if (startCloseIndex == -1)
                {
                    return str;
                }
            }
            else
            {
                int innerOpenIndex;
                int innerOpenIndexAmount = 0;
                int currentIndex = endOpenIndex + endOpenString.Length;

                do
                {
                    // find the next close index
                    startCloseIndex = str.IndexOf(startCloseString, currentIndex, stringComparison);

                    // safeguard
                    if (startCloseIndex == -1)
                    {
                        return str;
                    }

                    do
                    {
                        // find how many open indexes are before the close index
                        innerOpenIndex = str.IndexOf(startOpenString, currentIndex, stringComparison);

                        if (startCloseIndex > innerOpenIndex && innerOpenIndex != -1)
                        {
                            innerOpenIndexAmount++;
                            currentIndex = innerOpenIndex + startOpenString.Length;
                        }

                    } while (startCloseIndex > innerOpenIndex && innerOpenIndex != -1);

                    // if there are open indexes, make another iteration to find the correct close index
                    if (innerOpenIndexAmount > 0)
                    {
                        innerOpenIndexAmount--;
                        currentIndex = startCloseIndex + startCloseString.Length;
                    }
                    else
                    {
                        break;
                    }

                } while (true);
            }

            // find endCloseIndex 
            int endCloseIndex = str.IndexOf(endCloseString, startCloseIndex + startCloseString.Length, stringComparison);
            if (endCloseIndex == -1)
            {
                return str;
            }

            // remove the substring between startOpenIndex and endCloseIndex
            return str.Substring(0, startOpenIndex) + str.Substring(endCloseIndex + endCloseString.Length);
        }
        public string RemoveBetweenStrings(string str, int startIndex, string startOpenString, string endOpenString, string startCloseString, string endCloseString, int occurrence, bool considerNestedStructures, Func<string, bool> substringConditionToRemove, StringComparison stringComparison)
        {
            // validation
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Value cannot be less than 0.");
            if (startIndex > str.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Value cannot be greater than parameter {nameof(str)}'s Length.");
            if (startOpenString == null)
                throw new ArgumentNullException(nameof(startOpenString));
            if (endOpenString == null)
                throw new ArgumentNullException(nameof(endOpenString));
            if (startCloseString == null)
                throw new ArgumentNullException(nameof(startCloseString));
            if (endCloseString == null)
                throw new ArgumentNullException(nameof(endCloseString));
            if (occurrence < 1)
                throw new ArgumentOutOfRangeException(nameof(occurrence), "Value cannot be less than 1.");
            if (substringConditionToRemove == null)
                throw new ArgumentNullException(nameof(substringConditionToRemove));

            // find startOpenIndex of occurrence
            int startOpenIndex = startIndex;
            do
            {
                startOpenIndex = str.IndexOf(startOpenString, startOpenIndex, stringComparison);

                if (startOpenIndex == -1)
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
                    startOpenIndex += startOpenString.Length;
                }
            } while (true);

            // find endOpenIndex
            int endOpenIndex = str.IndexOf(endOpenString, startOpenIndex + startOpenString.Length, stringComparison);
            if (endOpenIndex == -1)
            {
                return str;
            }

            // find startCloseIndex 
            int startCloseIndex = 0;
            if (!considerNestedStructures)
            {
                startCloseIndex = str.IndexOf(startCloseString, endOpenIndex + endOpenString.Length, stringComparison);
                if (startCloseIndex == -1)
                {
                    return str;
                }
            }
            else
            {
                int innerOpenIndex;
                int innerOpenIndexAmount = 0;
                int currentIndex = endOpenIndex + endOpenString.Length;

                do
                {
                    // find the next close index
                    startCloseIndex = str.IndexOf(startCloseString, currentIndex, stringComparison);

                    // safeguard
                    if (startCloseIndex == -1)
                    {
                        return str;
                    }

                    do
                    {
                        // find how many open indexes are before the close index
                        innerOpenIndex = str.IndexOf(startOpenString, currentIndex, stringComparison);

                        if (startCloseIndex > innerOpenIndex && innerOpenIndex != -1)
                        {
                            innerOpenIndexAmount++;
                            currentIndex = innerOpenIndex + startOpenString.Length;
                        }

                    } while (startCloseIndex > innerOpenIndex && innerOpenIndex != -1);

                    // if there are open indexes, make another iteration to find the correct close index
                    if (innerOpenIndexAmount > 0)
                    {
                        innerOpenIndexAmount--;
                        currentIndex = startCloseIndex + startCloseString.Length;
                    }
                    else
                    {
                        break;
                    }

                } while (true);
            }

            // find endCloseIndex 
            int endCloseIndex = str.IndexOf(endCloseString, startCloseIndex + startCloseString.Length, stringComparison);
            if (endCloseIndex == -1)
            {
                return str;
            }

            // check substringConditionToRemove delegate to see if it is indeed to remove
            if (substringConditionToRemove(str.Substring(startOpenIndex, endCloseIndex - startOpenIndex + endCloseString.Length)))
            {
                return str.Substring(0, startOpenIndex) + str.Substring(endCloseIndex + endCloseString.Length);
            }
            else
            {
                return str;
            }
        }





    }
}
