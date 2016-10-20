namespace SolidR.Core.Domain
{
    public interface IAuditable
    {
        Audit Audit { get; }
    }
}