namespace SolidR.Domain
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }
}