using System;
using System.Reflection;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner.Processors.SqlServer;

namespace SolidR.FluentMigrator
{
    public class FluentDatabaseMigrator : IDatabaseMigrator
    {
        public void UpdateSchema(Assembly assembly)
        {
            //App.Log.Framework.DebugFormat("Migrating {0}", migration.FullName);

            var announcer = new TextWriterAnnouncer(s =>
            {
                s = s.Replace(Environment.NewLine, string.Empty);

                if (string.IsNullOrEmpty(s) == false)
                {
                    //Log.Framework.DebugFormat(s);
                }
            });

            var migrationContext = new RunnerContext(announcer);
            var factory = new SqlServer2014ProcessorFactory();
            var processor = factory.Create(App.ConnectionString, announcer, new ProcessorOptions
            {
                Timeout = 60,
                PreviewOnly = false
            });

            var runner = new MigrationRunner(assembly, migrationContext, processor);

            runner.MigrateUp();

            //Log.Framework.DebugFormat("Database migrated");
        }
    }
}
