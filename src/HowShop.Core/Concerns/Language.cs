using System.Collections.Generic;
using System.Linq;

namespace HowShop.Core.Concerns
{
    public struct Language
    {
        public Language(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }

        public string Id { get; set; }

        public bool Equals(Language other)
        {
            return string.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Language && Equals((Language)obj);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }

        public static IEnumerable<Language> GetAll() => new[]
        {
            new Language("en_US", "English U.S."),
            new Language("en_GB", "English U.K."),
            new Language("pt_BR", "Portuguese Brazilian")
        };

        public static Language FromId(string id) => GetAll().SingleOrDefault(x => x.Id == id);

        public static bool operator ==(Language left, Language right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Language left, Language right)
        {
            return (right == left) == false;
        }
    }
}