using HowShop.Core.Concerns;
using SolidR.Core.Domain;

namespace HowShop.Core.Domain
{
    public class Category : Entity, ILookupable
    {
        public string Name { get; private set; }

        private Category()
        {
        }

        public Category(string name)
        {
            Name = name;
        }

        public string DisplayName => Name;
    }
}