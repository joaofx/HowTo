using FubuCore.CommandLine;
using Import;
using MediatR;
using SolidR.Core;
using SolidR.Core.FluentMigrator;

namespace SolidR
{
    [CommandDescription("Downgrade one version of database schema", Name = "downgrade")]
    public class MigrateDownCommand : FubuCommand<Unit>
    {
        private readonly IDatabaseMigrator _databaseMigrator;

        public MigrateDownCommand()
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
