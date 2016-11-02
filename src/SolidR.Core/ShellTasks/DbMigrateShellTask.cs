using System.ComponentModel;
using FubuCore.CommandLine;
using SolidR.Core.FluentMigrator;

namespace SolidR.Core.ShellTasks
{
    [CommandDescription("Update database schema", Name = "db.migrate")]
    public class DbMigrateShellTask : FubuCommand<DbMigrateShellTask.DbMigrateInput>
    {
        private readonly IDatabaseMigrator _databaseMigrator;

        public DbMigrateShellTask()
        {
            Usage("Run migration to default environment").Arguments().ValidFlags();
            Usage("Run migration to a specific environment").Arguments(x => x.Env).ValidFlags();

            _databaseMigrator = App.Container.GetInstance<IDatabaseMigrator>();
        }

        public override bool Execute(DbMigrateInput input)
        {
            Console2.Alert("Migrating database schema on Environment {0}", input.Env);
            _databaseMigrator.UpdateSchema();
            Console2.Success("Database schema migrated");
            return true;
        }

        public class DbMigrateInput
        {
            public DbMigrateInput()
            {
                Env = "default";
            }

            [Description("Environment to run migration. Ex: dev, test and etc")]
            [FlagAlias("env", 'e')]
            public string Env { get; set; }
        }
    }
}
