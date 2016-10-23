using FubuCore.CommandLine;
using MediatR;
using SolidR.Core.FluentMigrator;

namespace SolidR.Core.ShellTasks
{
    [CommandDescription("Update database schema", Name = "db:update")]
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
