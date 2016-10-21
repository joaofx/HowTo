using System.Collections.Generic;
using NodaMoney;

namespace HowShop.Core.Concerns
{
    public class Currencies
    {
        public IEnumerable<Currency> GetAll() => new[]
        {
            Currency.FromCode("USD"),
            Currency.FromCode("EUR"),
            Currency.FromCode("GBP"),
            Currency.FromCode("BRL")
        };
    }
}
