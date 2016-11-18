namespace SolidR.Core.Domain
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