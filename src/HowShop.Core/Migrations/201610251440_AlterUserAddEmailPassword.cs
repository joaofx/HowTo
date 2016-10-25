using FluentMigrator;

namespace HowShop.Core.Migrations
{
    [Migration(201610251440)]
    public class AlterUserAddEmailPassword : Migration
    {
        public override void Up()
        {
            Alter.Table("User")
                .AddColumn("Email").AsString(255).Nullable()
                .AddColumn("Password").AsString(128).Nullable();
        }

        public override void Down()
        {
            Delete.Column("Email").FromTable("User");
            Delete.Column("Password").FromTable("User");
        }
    }
}