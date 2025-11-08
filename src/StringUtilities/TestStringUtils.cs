using StringUtilities.Core.IndexOfExpanded;
using StringUtilities.Core.RemoveExpanded;
using StringUtilities.Core.ReplaceExpanded;
using StringUtilities.Core.SubstringExpanded;

namespace StringUtilities
{
    internal class TestStringUtils
    {
        public IndexOfExp IndexOfExp { get; private set; } = new IndexOfExp();
        public RemoveExp RemoveExp { get; private set; } = new RemoveExp();
        public ReplaceExp ReplaceExp { get; private set; } = new ReplaceExp();
        public SubstringExp SubstringExp { get; private set; } = new SubstringExp();

    }
}
