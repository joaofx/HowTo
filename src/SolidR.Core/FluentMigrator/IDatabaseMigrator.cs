namespace SolidR.Core.FluentMigrator
{
    public interface IDatabaseMigrator
    {
        void UpdateSchema();
        void DowngradeSchema();
        void RecreateSchema();
    }
}