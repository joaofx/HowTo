using System.ComponentModel;
using FubuCore.CommandLine;
using MediatR;
using SolidR.Core.FluentMigrator;

namespace SolidR.Core.ShellTasks
{
    [CommandDescription("Reset schema executing all down and then up migrations", Name = "db.reset")]
    public class DbResetTask : FubuCommand<Unit>
    {
        private readonly IDatabaseMigrator _databaseMigrator;

        public DbResetTask()
        {
            _databaseMigrator = App.Container.GetInstance<IDatabaseMigrator>();
        }

        public override bool Execute(Unit input)
        {
            Console2.Alert("Migrating database schema");
            _databaseMigrator.RecreateSchema();
            Console2.Success("Database schema migrated");
            return true;
        }
    }
}
