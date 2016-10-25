using System;

namespace SolidR.Core
{
    public class BusinessRulesException : Exception
    {
        public BusinessRulesException(string message) : base(message)
        {
        }
    }
}