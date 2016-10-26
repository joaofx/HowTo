using FubuCore.CommandLine;
using MediatR;
using SolidR.Core.FluentMigrator;

namespace SolidR.Core.ShellTasks
{
    [CommandDescription("Downgrade one version of database schema", Name = "db.rollback")]
    public class DbRollbackShellTask : FubuCommand<Unit>
    {
        private readonly IDatabaseMigrator _databaseMigrator;

        public DbRollbackShellTask()
        {
            _databaseMigrator = App.Container.GetInstance<IDatabaseMigrator>();
        }

        public override bool Execute(Unit input)
        {
            Console2.Alert("Downgrading database schema");
            _databaseMigrator.DowngradeSchema();
            Console2.Success("Database schema downgraded");
            return true;
        }
    }
}
