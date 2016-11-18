using SolidR.Core.Domain;

namespace SolidR.Core
{
    public class SelectLookup : ILookupable
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
    }
}