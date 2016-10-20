using System.Collections.Generic;
using NodaMoney;

namespace HowShop.Core.Domain
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
