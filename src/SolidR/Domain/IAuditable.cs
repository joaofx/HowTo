namespace SolidR.Domain
{
    public interface IAuditable
    {
        Audit Audit { get; }
    }
}