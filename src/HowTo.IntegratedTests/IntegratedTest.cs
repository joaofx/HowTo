using System;
using System.Data.Entity;
using System.Linq;
using HowShop.Core.Infra;
using MediatR;
using NUnit.Framework;
using SolidR.Core;
using SolidR.Core.FluentMigrator;
using SolidR.TestSupport;
using StructureMap;
using StructureMap.Pipeline;

namespace HowTo.IntegratedTests
{
    public class IntegratedTest
    {
        protected IContainer Container;
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
            Container = App.Container.CreateChildContainer();
            
            Fixture = Container.GetInstance<TestFixture>();

            App.Log.Info("Cleaning all Tables");
            DatabaseCleaner.CleanAllTables(App.ConnectionString);
        }

        [TearDown]
        public void IntegratedAfterEachTest()
        {
            Container.Dispose();
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
            var mediator = Container.GetInstance<IMediator>();
            return mediator.Send(message);
        }

        protected void WithDb(Action<HowShopContext> action)
        {
            using (var db = Container.GetInstance<HowShopContext>())
            {
                App.Log.Debug($"Using DbContext {db.GetHashCode()}");
                action(db);
            }
        }

        protected void SaveAll(params object[] entities)
        {
            using (var db = Container.GetInstance<DbContext>())
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