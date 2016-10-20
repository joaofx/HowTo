using FubuCore.CommandLine;
using Import;
using SolidR.Core;
using SolidR.Core.FluentMigrator;

namespace SolidR
{
    [CommandDescription("Update database schema", Name = "db:migrate")]
    public class DbMigrateCommand : FubuCommand<DbMigrateInput>
    {
        private readonly IDatabaseMigrator _databaseMigrator;

        public DbMigrateCommand()
        {
            _databaseMigrator = App.Container.GetInstance<IDatabaseMigrator>();
        }

        public override bool Execute(DbMigrateInput input)
        {
            if (input.Update)
            {
                Console2.Alert("Migrating database schema");
                _databaseMigrator.UpdateSchema();
                Console2.Success("Database schema migrated");
            }
            else if (input.Downgrade)
            {
                Console2.Alert("Downgrading database schema");
                _databaseMigrator.DowngradeSchema();
                Console2.Success("Database schema downgraded");
            }

            return true;
        }
    }
}
