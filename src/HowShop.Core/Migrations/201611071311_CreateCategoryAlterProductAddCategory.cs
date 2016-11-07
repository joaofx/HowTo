using FluentMigrator;

namespace HowShop.Core.Migrations
{
    [Migration(201611071311)]
    public class CreateCategoryAlterProductAddCategory : Migration
    {
        public override void Up()
        {
            Create.Table("Category")
                .WithPrimaryKey()
                .WithName();

            Delete.FromTable("Product").AllRows();

            Alter.Table("Product")
                .AddColumn("CategoryId").AsInt64().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Category");
            Delete.Column("CategoryId").FromTable("Product");
        }
    }
}