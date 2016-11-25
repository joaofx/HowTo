﻿using System.Linq;
using System.Text.RegularExpressions;
using HtmlTags;
using HtmlTags.Conventions;
using HtmlTags.Conventions.Elements;
using StructureMap;

namespace SolidR.Core.Mvc
{
    public class DefaultDisplayLabelBuilder : IElementBuilder
    {
        public bool Matches(ElementRequest subject)
        {
            return true;
        }

        public HtmlTag Build(ElementRequest request)
        {
            var container = request.Get<IContainer>();
            return new HtmlTag(string.Empty).NoTag().Text(BreakUpCamelCase(request.Accessor.Name));
        }

        public static string BreakUpCamelCase(string fieldName)
        {
            var patterns = new[]
            {
                "([a-z])([A-Z])",
                "([0-9])([a-zA-Z])",
                "([a-zA-Z])([0-9])"
            };
            var output = patterns.Aggregate(fieldName,
                (current, pattern) => Regex.Replace(current, pattern, "$1 $2", RegexOptions.IgnorePatternWhitespace));
            return output.Replace('_', ' ');
        }
    }
}
