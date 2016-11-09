using System;
using System.Data.Entity;
using System.Linq;
using HowShop.Core.Concerns;
using HowShop.Core.Domain;
using HowShop.Core.Infra;
using HtmlTags.Conventions;
using HtmlTags.Conventions.Elements;
using SolidR.Core.Domain;

namespace HowShop.Web.Html.Conventions
{
    public class LookupDropDownModifier : IElementModifier
    {
        public bool Matches(ElementRequest token)
        {
            return typeof(ILookupable).IsAssignableFrom(token.Accessor.PropertyType);
        }

        public void Modify(ElementRequest request)
        {
            var db = request.Get<HowShopContext>();

            //var method = db
            //    .GetType()
            //    .GetMethod("Set", new Type[0])
            //    .MakeGenericMethod(request.Accessor.PropertyType);

            //var genericItem = method.Invoke(db, new object[0]);

            var entities = db.Set(request.Accessor.PropertyType)
                .Cast<Category>()
                .ToList();

            request.ModifyWithDropDown(
                entities,
                x => x.Id.ToString(),
                x => x.DisplayName);
        }
    }
}