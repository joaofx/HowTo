using FubuCore.CommandLine;
using Import;
using MediatR;
using SolidR.Core;
using SolidR.Core.FluentMigrator;

namespace SolidR
{
    [CommandDescription("Update database schema", Name = "migrate")]
    public class MigrateUpCommand : FubuCommand<Unit>
    {
        private readonly IDatabaseMigrator _databaseMigrator;

        public MigrateUpCommand()
        {
            _databaseMigrator = App.Container.GetInstance<IDatabaseMigrator>();
        }

        public override bool Execute(Unit input)
        {
            Console2.Alert("Migrating database schema");
            _databaseMigrator.UpdateSchema();
            Console2.Success("Database schema migrated");
            return true;
        }
    }
}
