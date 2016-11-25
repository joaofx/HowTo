using HtmlTags.Conventions;

namespace HowShop.Web.Html.Conventions
{
    public static class ElementCategoryExpressionExtensions
    {
        public static ElementActionExpression IfPropertyNameEnds(this ElementCategoryExpression expression, string endsWith)
        {
            return expression.If(m => m.Accessor.Name.EndsWith(endsWith));
        }
    }
}