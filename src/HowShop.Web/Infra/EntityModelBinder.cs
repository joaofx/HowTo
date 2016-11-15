using System.Web.Mvc;
using HowShop.Core.Infra;

namespace HowShop.Web.Infra
{
    public class EntityModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var db = DependencyResolver.Current.GetService<HowShopContext>();

            var attemptedValue = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).AttemptedValue;

            return string.IsNullOrWhiteSpace(attemptedValue)
                ? null
                : db.Set(bindingContext.ModelType).Find(int.Parse(attemptedValue));
        }
    }
}