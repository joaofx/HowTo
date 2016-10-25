using FluentMigrator;

namespace HowShop.Core.Migrations
{
    [Migration(201610251440)]
    public class AlterUserAddEmailPassword : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("User")
                .AddColumn("Email").AsString(255).Nullable()
                .AddColumn("Password").AsString(128).Nullable();
        }
    }
}