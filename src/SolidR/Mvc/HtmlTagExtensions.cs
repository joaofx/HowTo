using HtmlTags;

namespace SolidR.Mvc
{
    public static class HtmlTagExtensions
    {
        public static HtmlTag AddPlaceholder(this HtmlTag tag, string placeholder)
        {
            return tag.Attr("placeholder", placeholder);
        }

        public static HtmlTag AddPattern(this HtmlTag tag, string pattern)
        {
            return tag.Data("pattern", pattern);
        }

        public static HtmlTag AutoCapitalize(this HtmlTag tag)
        {
            return tag.Data("autocapitalize", "true");
        }
    }
}
