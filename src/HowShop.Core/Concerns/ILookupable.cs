namespace HowShop.Core.Concerns
{
    /// <summary>
    /// TODO: Convert to Lookup<Entity>?
    /// </summary>
    public interface ILookupable
    {
        long Id { get; }

        string DisplayName { get; }
    }
}