using System.Collections.Generic;
using System.Linq;

namespace HowShop.Core.Concerns
{
    public struct Culture
    {
        public Culture(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }

        public string Id { get; set; }

        public bool Equals(Culture other)
        {
            return string.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Culture && Equals((Culture)obj);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }

        public static IEnumerable<Culture> GetAll() => new[]
        {
            new Culture("en_US", "English (United States)"),
            new Culture("en_GB", "English (United Kingdom)"),
            new Culture("pt_BR", "Portuguese (Brazil)")
        };

        public static Culture FromId(string id) => GetAll().SingleOrDefault(x => x.Id == id);

        public static bool operator ==(Culture left, Culture right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Culture left, Culture right)
        {
            return (right == left) == false;
        }
    }
}