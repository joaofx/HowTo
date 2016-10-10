using System.Data.Entity.Migrations;
using SolidR.Migrators;

namespace HowToEntityFramework.Infra
{
    public class DatabaseMigrator : IDatabaseMigrator
    {
        public void UpdateSchema()
        {
            var migrator = new DbMigrator(new MigrationConfiguration());
            migrator.Update();
        }

        public class MigrationConfiguration : DbMigrationsConfiguration<DatabaseContext>
        {
            public MigrationConfiguration()
            {
                AutomaticMigrationsEnabled = true;
            }
        }
    }
}