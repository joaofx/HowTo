using FluentMigrator;

namespace HowShop.Core.Migrations
{
    [Migration(201610271328)]
    public class AlterUserAddProfile : Migration
    {
        public override void Up()
        {
            Alter.Table("User")
                .AddColumn("Profile").AsInt32().Nullable();
        }

        public override void Down()
        {
            Delete.Column("Profile").FromTable("User");
        }
    }
}