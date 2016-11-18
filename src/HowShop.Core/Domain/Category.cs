using HowShop.Core.Concerns;
using SolidR.Core.Domain;

namespace HowShop.Core.Domain
{
    public class Category : Entity
    {
        public string Name { get; private set; }

        private Category()
        {
        }

        public Category(string name)
        {
            Name = name;
        }
    }
}