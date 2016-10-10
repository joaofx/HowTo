using HowShop.Core.Domain;
using NUnit.Framework;
using SolidR;
using SolidR.Migrators;

namespace HowToEntityFramework.Infra
{
    public class IntegratedTest
    {
        private readonly IDatabaseCleaner _databaseCleaner = new RespawnDatabaseCleaner();
        private readonly FluentDatabaseMigrator _databaseMigrator = new FluentDatabaseMigrator();
        
        [SetUp]
        public void IntegratedBeforeEachTest()
        {
            Log.App.Info("Cleaning all Tables");
            _databaseCleaner.CleanAllTables(App.ConnectionString);
        }

        [TestFixtureSetUp]
        public void IntegratedBeforeEachTestFixture()
        {
            _databaseMigrator.Assembly = typeof(Product).Assembly;

            Log.App.Info("Running Database Migration");
            _databaseMigrator.UpdateSchema();  
        }        
    }
}