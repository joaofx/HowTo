using System.Web.Mvc;
using HowShop.Core.Concerns;

namespace HowShop.Core.Infra
{
    public class MustHaveAccessToAttribute : AuthorizeAttribute
    {
        public MustHaveAccessToAttribute(Feature feature)
        {
        }
    }
}