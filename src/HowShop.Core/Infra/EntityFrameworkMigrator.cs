using System.Data.Entity.Migrations;
using SolidR.FluentMigrator;

namespace HowShop.Core.Infra
{
    public class EntityFrameworkMigrator : IDatabaseMigrator
    {
        public void UpdateSchema()
        {
            var migrator = new DbMigrator(new MigrationConfiguration());
            migrator.Update();
        }
    }
}