using HowShop.Core.Concerns;
using HtmlTags;
using HtmlTags.Conventions;
using HtmlTags.Conventions.Elements;

namespace HowShop.Web.HtmlConventions
{
    public class LanguageDropDownModifier : IElementModifier
    {
        public bool Matches(ElementRequest token)
        {
            return token.Accessor.PropertyType == typeof (Language);
        }

        public void Modify(ElementRequest request)
        {
            request.CurrentTag.RemoveAttr("type");
            request.CurrentTag.TagName("select");

            var value = request.Value<Language>();

            foreach (var language in Language.GetAll())
            {
                var optionTag = new HtmlTag("option")
                    .Value(language.Id)
                    .Text(language.Name);

                if (value == language)
                    optionTag.Attr("selected");

                request.CurrentTag.Append(optionTag);
            }
        }
    }
}