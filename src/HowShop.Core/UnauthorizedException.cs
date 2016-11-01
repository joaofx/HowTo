using System;
using HowShop.Core.Concerns;

namespace HowShop.Core
{
    public class UnauthorizedException : Exception
    {
        // TODO: better message
        public UnauthorizedException(Feature feature) : base($"No authorization for {feature}")
        {
        }
    }
}