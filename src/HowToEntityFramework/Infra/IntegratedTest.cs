using HowShop.Core.Domain;
using NUnit.Framework;
using SolidR;
using SolidR.FluentMigrator;
using StructureMap;

namespace HowToEntityFramework.Infra
{
    public class IntegratedTest
    {
        private readonly IDatabaseCleaner _databaseCleaner = App.Container.GetInstance<IDatabaseCleaner>();
        private readonly IDatabaseMigrator _databaseMigrator = App.Container.GetInstance<IDatabaseMigrator>();

        static IntegratedTest()
        {
            App.Container = new Container(_ =>
            {
                _.Scan(s =>
                {
                    s.AssemblyContainingType<IntegratedTest>();
                    s.LookForRegistries();
                    s.WithDefaultConventions();
                });
            });
        }

        [SetUp]
        public void IntegratedBeforeEachTest()
        {
            Log.App.Info("Cleaning all Tables");
            _databaseCleaner.CleanAllTables(App.ConnectionString);
        }

        [TestFixtureSetUp]
        public void IntegratedBeforeEachTestFixture()
        {
            Log.App.Info("Running Database Migration");
            _databaseMigrator.UpdateSchema(typeof(Product).Assembly);  
        }        
    }
}