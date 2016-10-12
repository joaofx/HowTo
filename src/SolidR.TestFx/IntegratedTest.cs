using System.Data.Entity;
using System.Linq;
using NUnit.Framework;
using SolidR.FluentMigrator;

namespace SolidR.TestFx
{
    public class IntegratedTest
    {
        private readonly IDatabaseCleaner _databaseCleaner = App.Container.GetInstance<IDatabaseCleaner>();
        private readonly IDatabaseMigrator _databaseMigrator = App.Container.GetInstance<IDatabaseMigrator>();

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

        public void SaveAll(params object[] entities)
        {
            using (var db = App.Container.GetInstance<DbContext>())
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