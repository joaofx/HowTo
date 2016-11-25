using System;
using FluentValidation;

namespace SolidR.Core.Validation
{
    public class StructureMapValidatorFactory : ValidatorFactoryBase
    {
        public override IValidator CreateInstance(Type validatorType)
        {
            return App.Container.TryGetInstance(validatorType) as IValidator;
        }
    }
}
