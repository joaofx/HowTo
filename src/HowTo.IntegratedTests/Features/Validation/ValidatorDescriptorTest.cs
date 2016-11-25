using FluentValidation;
using FluentValidation.Validators;
using NUnit.Framework;
using Shouldly;
using SolidR.Core.Validation;

namespace HowTo.IntegratedTests.Features.Validation
{
    [TestFixture]
    public class ValidatorDescriptorTest
    {
        public class Model
        {
            public string Name { get; set; }
            public int Number { get; set; }
        }

        public class Validator : AbstractValidator<Model>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Number).InclusiveBetween(1, 50);
            }
        }

        [Test]
        public void Should_return_if_a_rule_exist_in_a_property()
        {
            var validator = new Validator();
            validator.DescriptorFor(x => x.Name).Has<NotEmptyValidator>().ShouldBeTrue();
            validator.DescriptorFor(x => x.Name).Has<InclusiveBetweenValidator>().ShouldBeFalse();
        }

        [Test]
        public void Should_return_instance_of_property_rule()
        {
            var validator = new Validator();
            var propertyValidator = validator.DescriptorFor(x => x.Number).Get<InclusiveBetweenValidator>();
            propertyValidator.From.ShouldBe(1);
            propertyValidator.To.ShouldBe(50);
        }

        [Test]
        public void Should_return_descriptor_by_property_name()
        {
            var validator = new Validator();
            validator.DescriptorFor("Name").Has<NotEmptyValidator>().ShouldBeTrue();
            validator.DescriptorFor("Number").Has<InclusiveBetweenValidator>().ShouldBeTrue();
        }
    }
}
