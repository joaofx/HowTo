using HowShop.Core.Concerns;
using HowShop.Core.Domain;
using HtmlTags;
using HtmlTags.Conventions;
using HtmlTags.Conventions.Elements;
using NodaMoney;

namespace HowShop.Web.HtmlConventions
{
    public class CurrencyDropDownModifier : IElementModifier
    {
        public bool Matches(ElementRequest token)
        {
            return token.Accessor.PropertyType == typeof (Currency);
        }

        public void Modify(ElementRequest request)
        {
            request.CurrentTag.RemoveAttr("type");
            request.CurrentTag.TagName("select");

            var value = request.Value<Currency>();

            foreach (var currency in request.Get<Currencies>().GetAll())
            {
                var optionTag = new HtmlTag("option")
                    .Value(currency.Code)
                    .Text($"{currency.Code} {currency.Symbol} - {currency.EnglishName}");

                if (value == currency)
                    optionTag.Attr("selected");

                request.CurrentTag.Append(optionTag);
            }
        }
    }
}