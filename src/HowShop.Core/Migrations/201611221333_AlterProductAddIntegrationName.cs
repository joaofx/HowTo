using FluentMigrator;

namespace HowShop.Core.Migrations
{
    [Migration(201611221333)]
    public class AlterProductAddIntegrationName : Migration
    {
        public override void Up()
        {
            Alter.Table("Product")
                .AddColumn("IntegrationName").AsString(128).Nullable();
        }

        public override void Down()
        {
            Delete.Column("IntegrationName").FromTable("Product");
        }
    }
}