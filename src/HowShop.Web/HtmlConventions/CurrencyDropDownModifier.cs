using HowShop.Core.Concerns;
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
            request.ModifyWithDropDown(
                Currencies.GetAll(),
                x => x.Code,
                x => $"{x.Code} {x.Symbol} - {x.EnglishName}");

            //request.CurrentTag.RemoveAttr("type");
            //request.CurrentTag.TagName("select");

            //var value = request.Value<Currency>();

            //foreach (var currency in request.Get<Currencies>().GetAll())
            //{
            //    var optionTag = new HtmlTag("option")
            //        .Value(currency.Code)
            //        .Text();

            //    if (value == currency)
            //        optionTag.Attr("selected");

            //    request.CurrentTag.Append(optionTag);
            //}
        }
    }
}