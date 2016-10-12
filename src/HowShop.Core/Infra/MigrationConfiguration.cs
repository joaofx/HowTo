using System.Data.Entity.Migrations;

namespace HowShop.Core.Infra
{
    public class MigrationConfiguration : DbMigrationsConfiguration<HowToContext>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
    
}