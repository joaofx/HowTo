using System.Data.Entity.Migrations;

namespace HowShop.Core.Infra
{
    public class MigrationConfiguration : DbMigrationsConfiguration<DatabaseContext>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
    
}