
namespace StringUtilities.Core.Html
{
    public class StuffHtml
    {


        public string UpperCaseHtmlTagNames(string htmlContent)
        {
            var stringBuilder = new System.Text.StringBuilder(htmlContent.Length);
            var inName = false;

            for (int htmlContentIndex = 0; htmlContentIndex < htmlContent.Length; htmlContentIndex++)
            {
                switch (htmlContent[htmlContentIndex])
                {
                    case '<':
                        inName = true;
                        stringBuilder.Append(htmlContent[htmlContentIndex]);
                        break;

                    case ' ':
                        if (inName)
                        {
                            inName = false;
                        }
                        stringBuilder.Append(htmlContent[htmlContentIndex]);
                        break;

                    case '/':
                        stringBuilder.Append(htmlContent[htmlContentIndex]);
                        break;

                    default:
                        if (inName && char.IsLower(htmlContent[htmlContentIndex]))
                        {
                            stringBuilder.Append(char.ToUpper(htmlContent[htmlContentIndex]));
                        }
                        else
                        {
                            stringBuilder.Append(htmlContent[htmlContentIndex]);
                        }
                        break;
                }
            }

            return stringBuilder.ToString();
        }

        public string LowerCaseHtmlTagNames(string htmlContent)
        {
            var stringBuilder = new System.Text.StringBuilder(htmlContent.Length);
            var inName = false;

            for (int htmlContentIndex = 0; htmlContentIndex < htmlContent.Length; htmlContentIndex++)
            {
                switch (htmlContent[htmlContentIndex])
                {
                    case '<':
                        inName = true;
                        stringBuilder.Append(htmlContent[htmlContentIndex]);
                        break;

                    case ' ':
                        if (inName)
                        {
                            inName = false;
                        }
                        stringBuilder.Append(htmlContent[htmlContentIndex]);
                        break;

                    case '/':
                        stringBuilder.Append(htmlContent[htmlContentIndex]);
                        break;

                    default:
                        if (inName && char.IsUpper(htmlContent[htmlContentIndex]))
                        {
                            stringBuilder.Append(char.ToLower(htmlContent[htmlContentIndex]));
                        }
                        else
                        {
                            stringBuilder.Append(htmlContent[htmlContentIndex]);
                        }
                        break;
                }
            }

            return stringBuilder.ToString();
        }


        public string SetSelfColsingTagsWithSlashEnd(string htmlContent)
        {
            var selfClosingTags = new string[]
            {
                "area", "base", "br", "col", "embed", "hr", "img", "input", "link", "meta", "source", "track", "wbr"
            };

            for (var i = 0; i < selfClosingTags.Length; i++)
            {
                var currentIndex = 0;

                while (currentIndex < htmlContent.Length)
                {
                    currentIndex = htmlContent.IndexOf(selfClosingTags[i], currentIndex);

                    if (currentIndex == -1)
                    {
                        // no more of this tag at this index
                        break;
                    }

                    var closeSlashIndex = htmlContent.IndexOf('/', currentIndex);
                    var closeIndex = htmlContent.IndexOf('>', currentIndex);

                    if (closeIndex == -1)
                    {
                        // bad html
                        break;
                    }
                    else if (closeSlashIndex == -1 || closeSlashIndex > closeIndex)
                    {
                        // its <br>, transform it to <br />
                        if (htmlContent[closeIndex - 1] == ' ')
                        {
                            htmlContent = htmlContent.Insert(closeIndex, "/");
                            currentIndex++;
                        }
                        else
                        {
                            htmlContent = htmlContent.Insert(closeIndex, " /");
                            currentIndex += 2;
                        }
                    }

                    currentIndex++;
                }
            }

            return htmlContent;
        }


        public string SetSelfColsingTagsWithoutSlashEnd(string htmlContent)
        {
            var selfClosingTags = new string[]
            {
                "area", "base", "br", "col", "embed", "hr", "img", "input", "link", "meta", "source", "track", "wbr"
            };

            for (var i = 0; i < selfClosingTags.Length; i++)
            {
                var currentIndex = 0;

                while (currentIndex < htmlContent.Length)
                {
                    currentIndex = htmlContent.IndexOf(selfClosingTags[i], currentIndex);

                    if (currentIndex == -1)
                    {
                        // no more of this tag at this index
                        break;
                    }

                    var closeSlashIndex = htmlContent.IndexOf('/', currentIndex);
                    var closeIndex = htmlContent.IndexOf('>', currentIndex);

                    if (closeIndex == -1)
                    {
                        // bad html
                        break;
                    }
                    else if (closeSlashIndex != -1 && closeSlashIndex < closeIndex)
                    {
                        // its <br />, transform it to <br>
                        var removeCount = 0;

                        if (htmlContent[closeIndex - 1] == '/')
                        {
                            removeCount++;
                        }

                        var checkspaceIndex = 2;
                        while (htmlContent[closeIndex - checkspaceIndex] == ' ')
                        {
                            removeCount++;
                            checkspaceIndex++;

                            if (closeIndex - checkspaceIndex < 0)
                            {
                                break;
                            }
                        }

                        htmlContent = htmlContent.Remove(closeSlashIndex - (removeCount - 1), removeCount);
                    }

                    currentIndex++;
                }
            }

            return htmlContent;
        }



        public string NormalizeSelfClosingTags(string htmlContent)
        {
            var selfClosingTags = new[] { "area", "base", "br", "col", "embed", "hr", "img", "input", "link", "meta", "source", "track", "wbr" };

            var stringBuilder = new System.Text.StringBuilder(htmlContent.Length);
            int index = 0;

            while (index < htmlContent.Length)
            {
                int tagStart = htmlContent.IndexOf('<', index);

                // If no more tags, append the rest and exit
                if (tagStart == -1)
                {
                    stringBuilder.Append(htmlContent.Substring(index));
                    break;
                }

                // Append everything before the tag
                stringBuilder.Append(htmlContent.Substring(index, tagStart - index));

                // Look for the next space or '>' to determine the tag name
                int tagEnd = htmlContent.IndexOfAny(new[] { ' ', '>', '/' }, tagStart + 1);
                if (tagEnd == -1)
                {
                    // Malformed HTML, append the rest and exit
                    stringBuilder.Append(htmlContent.Substring(tagStart));
                    break;
                }

                // Extract the tag name
                string tagName = htmlContent.Substring(tagStart + 1, tagEnd - tagStart - 1).Trim();

                // Check if it's a self-closing tag
                bool isSelfClosing = Array.Exists(selfClosingTags, t => string.Equals(t, tagName, StringComparison.OrdinalIgnoreCase));

                if (isSelfClosing)
                {
                    // Remove trailing slash and spaces if it's self-closing
                    int closeSlashIndex = htmlContent.IndexOf('/', tagEnd);
                    int tagCloseIndex = htmlContent.IndexOf('>', tagEnd);

                    if (closeSlashIndex != -1 && closeSlashIndex < tagCloseIndex)
                    {
                        // Remove slash and preceding spaces
                        stringBuilder.Append('<').Append(tagName).Append('>');
                        index = tagCloseIndex + 1;
                        continue;
                    }
                }

                // If not self-closing or no trailing slash, append tag as-is
                int tagClose = htmlContent.IndexOf('>', tagEnd);
                if (tagClose == -1)
                {
                    // Malformed tag, append and exit
                    stringBuilder.Append(htmlContent.Substring(tagStart));
                    break;
                }

                stringBuilder.Append(htmlContent.Substring(tagStart, tagClose - tagStart + 1));
                index = tagClose + 1;
            }

            return stringBuilder.ToString();
        }
    }
}
