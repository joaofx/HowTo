namespace HowToEntityFramework.Infra
{
    public interface IDatabaseCleaner
    {
        void CleanAllTables(string connectionString);
    }
}