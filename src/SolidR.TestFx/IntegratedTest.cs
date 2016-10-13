using System;
using System.Data.Entity;
using System.Linq;
using MediatR;
using NUnit.Framework;
using SolidR.FluentMigrator;

namespace SolidR.TestFx
{
    public class IntegratedTest
    {
        private readonly IDatabaseCleaner _databaseCleaner = App.Container.GetInstance<IDatabaseCleaner>();
        private readonly IDatabaseMigrator _databaseMigrator = App.Container.GetInstance<IDatabaseMigrator>();

        protected readonly IMediator Mediator = App.Container.GetInstance<IMediator>();

        static IntegratedTest()
        {
            App.Initialize(_ =>
            {
                _.Scan(s =>
                {
                    s.AssembliesFromApplicationBaseDirectory();
                    s.LookForRegistries();
                    s.WithDefaultConventions();
                });
            });
        }

        [SetUp]
        public void IntegratedBeforeEachTest()
        {
            App.Log.Info("Cleaning all Tables");
            _databaseCleaner.CleanAllTables(App.ConnectionString);
        }

        [TestFixtureSetUp]
        public void IntegratedBeforeEachTestFixture()
        {
            App.Log.Info("Running Database Migration");
            _databaseMigrator.UpdateSchema();  
        }

    }
}