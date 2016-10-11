using System.Data.Entity.Migrations;
using System.Reflection;
using SolidR.FluentMigrator;

namespace HowShop.Core.Infra
{
    public class EntityFrameworkMigrator : IDatabaseMigrator
    {
        public void UpdateSchema(Assembly assembly)
        {
            var migrator = new DbMigrator(new MigrationConfiguration());
            migrator.Update();
        }
    }
}