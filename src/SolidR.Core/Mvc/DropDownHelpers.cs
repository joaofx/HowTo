using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using HtmlTags;

namespace SolidR.Core.Mvc
{
    public static class DropDownHelpers
    {
        public static HtmlTag DropDownFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IDictionary<TProperty, string> options)
        {
            var currentValue = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).Model;
            var select = new SelectTag();

            select.Id(htmlHelper.IdFor(expression).ToString());
            select.Name(htmlHelper.IdFor(expression).ToString());

            foreach (var option in options)
            {
                select.Option(option.Key.ToString(), option.Key);
            }
            
            if (currentValue != null)
            {
                select.SelectByValue(currentValue);
            }

            return select;
        }
    }
}
