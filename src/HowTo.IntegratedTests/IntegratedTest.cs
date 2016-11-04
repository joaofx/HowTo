using System;
using System.Data.Entity;
using System.Linq;
using HowShop.Core.Infra;
using MediatR;
using NUnit.Framework;
using SolidR.Core;
using SolidR.Core.FluentMigrator;
using SolidR.TestFx;
using StructureMap;

namespace HowTo.IntegratedTests
{
    public class IntegratedTest
    {
        private IContainer _nestedContainer;

        protected IDatabaseCleaner DatabaseCleaner;
        protected IDatabaseMigrator DatabaseMigrator;
        protected TestFixture Fixture;

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
            _nestedContainer = App.Container.GetNestedContainer();

            Fixture = _nestedContainer.GetInstance<TestFixture>();

            App.Log.Info("Cleaning all Tables");
            DatabaseCleaner.CleanAllTables(App.ConnectionString);
        }

        [TearDown]
        public void IntegratedAfterEachTest()
        {
            _nestedContainer.Dispose();
        }

        [TestFixtureSetUp]
        public void IntegratedBeforeEachTestFixture()
        {
            DatabaseCleaner = App.Container.GetInstance<IDatabaseCleaner>();
            DatabaseMigrator = App.Container.GetInstance<IDatabaseMigrator>();

            App.Log.Info("Running Database Migration");
            DatabaseMigrator.UpdateSchema();  
        }

        protected TResult Send<TResult>(IRequest<TResult> message)
        {
            var mediator = _nestedContainer.GetInstance<IMediator>();
            return mediator.Send(message);
        }

        protected void WithDb(Action<HowShopContext> action)
        {
            using (var db = _nestedContainer.GetInstance<HowShopContext>())
            {
                action(db);
            }
        }

        protected void SaveAll(params object[] entities)
        {
            using (var db = _nestedContainer.GetInstance<DbContext>())
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.ValidateOnSaveEnabled = false;

                foreach (var entity in entities)
                {
                    var entry = db.ChangeTracker.Entries().FirstOrDefault(entityEntry => entityEntry.Entity == entity);

                    if (entry == null)
                    {
                        db.Set(entity.GetType()).Add(entity);
                    }
                }

                db.SaveChanges();
            };
        }
    }
}