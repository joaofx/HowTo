using FluentValidation;
using FluentValidation.Validators;
using HtmlTags;
using HtmlTags.Conventions;
using HtmlTags.Conventions.Elements;
using SolidR.Core;
using SolidR.Core.Validation;

namespace HowShop.Web.Html.Conventions
{
    public class RequiredPropertyModifier : IElementModifier
    {
        private IValidator _validator;

        public bool Matches(ElementRequest elementRequest)
        {
            // TODO: Refactor this. Make it easier to get validator
            var container = App.Container;
            var validatorFactory = container.GetInstance<IValidatorFactory>();
            _validator = validatorFactory.GetValidator(elementRequest.HolderType());

            if (_validator == null)
                return false;

            return _validator.DescriptorFor(elementRequest.Accessor.Name).Has<NotEmptyValidator>();
        }

        public void Modify(ElementRequest request)
        {
            request.CurrentTag.Append(new HtmlTag("span").AddClass("required-label").Text(" *"));
        }
    }
}