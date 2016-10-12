namespace SolidR.TestFx
{
    public interface IDatabaseCleaner
    {
        void CleanAllTables(string connectionString);
    }
}