namespace SolidR.Core.Domain
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }
}