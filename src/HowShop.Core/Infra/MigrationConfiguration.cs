using System.Data.Entity.Migrations;

namespace HowShop.Core.Infra
{
    public class MigrationConfiguration : DbMigrationsConfiguration<HowShopContext>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
    
}