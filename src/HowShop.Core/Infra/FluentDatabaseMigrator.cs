using System;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner.Processors.SqlServer;
using HowShop.Core.Domain;
using SolidR.Core;
using SolidR.Core.FluentMigrator;

namespace HowShop.Core.Infra
{
    public class FluentDatabaseMigrator : IDatabaseMigrator
    {
        public void UpdateSchema()
        {
            var assembly = typeof(Product).Assembly;

            App.Log.Info("Migrating {0}", assembly.FullName);

            var announcer = new TextWriterAnnouncer(s =>
            {
                s = s.Replace(Environment.NewLine, string.Empty);

                if (string.IsNullOrEmpty(s) == false)
                {
                    App.Log.Debug(s);
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

            App.Log.Info("Database migrated");
        }

        public void DowngradeSchema()
        {
            var assembly = typeof(Product).Assembly;

            App.Log.Info("Migrating {0}", assembly.FullName);

            var announcer = new TextWriterAnnouncer(s =>
            {
                s = s.Replace(Environment.NewLine, string.Empty);

                if (string.IsNullOrEmpty(s) == false)
                {
                    App.Log.Debug(s);
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

            runner.Rollback(1);

            App.Log.Info("Database migrated");
        }
    }
}
