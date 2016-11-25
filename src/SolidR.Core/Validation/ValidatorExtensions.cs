using System;
using System.Linq.Expressions;
using FluentValidation;
using FubuCore.Reflection;

namespace SolidR.Core.Validation
{
    public static class ValidatorExtensions
    {
        public static DescriptorBuilder DescriptorFor(this IValidator validator, string propertyName)
        {
            return GetDescriptorBuilder(validator, propertyName);
        }
        
        public static DescriptorBuilder DescriptorFor<T, TProperty>(this IValidator<T> validator, Expression<Func<T, TProperty>> expression)
        {
            var property = ReflectionHelper.GetProperty(expression);
            return GetDescriptorBuilder(validator, property.Name);
        }

        private static DescriptorBuilder GetDescriptorBuilder(IValidator validator, string propertyName)
        {
            var descriptor = validator.CreateDescriptor();
            var validators = descriptor.GetValidatorsForMember(propertyName);

            return new DescriptorBuilder(validators);
        }
    }
}