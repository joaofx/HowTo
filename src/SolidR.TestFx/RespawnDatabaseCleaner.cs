using Respawn;

namespace HowToEntityFramework.Infra
{
    public class RespawnDatabaseCleaner : IDatabaseCleaner
    {
        private static readonly Checkpoint Checkpoint = new Checkpoint
        {
            TablesToIgnore = new[]
            {
                "sysdiagrams",
                "tblUser",
                "tblObjectType",
                "__MigrationHistory",
                "VersionInfo"
            },
            SchemasToExclude = new string[] { }
        };

        public void CleanAllTables(string connectionString)
        {
            Checkpoint.Reset(connectionString);
        }
    }
}