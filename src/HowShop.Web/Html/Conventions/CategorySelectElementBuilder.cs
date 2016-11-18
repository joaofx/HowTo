using System.Linq;
using HowShop.Core.Concerns;
using HowShop.Core.Domain;

namespace HowShop.Web.Html.Conventions
{
    public class CategorySelectElementBuilder : EntitySelectElementBuilder<Category>
    {
        protected override long GetValue(Category instance) => instance.Id;
        protected override string GetDisplayValue(Category instance) => instance.Name;
    }
}