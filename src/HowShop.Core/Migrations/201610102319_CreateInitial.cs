using FluentMigrator;

namespace HowShop.Core.Migrations
{
    [Migration(201610102319)]
    public class CreateInitial : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Product")
                .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(64).NotNullable()
                .WithColumn("Price").AsDecimal().NotNullable()
                .WithColumn("Audit_UpdatedAt").AsDateTime().Nullable()
                .WithColumn("Audit_CreatedAt").AsDateTime().Nullable();

            Create.Table("Stock")
                .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("ProductId").AsInt64()
                .WithColumn("StoreId").AsInt64()
                .WithColumn("Quantity").AsInt32();

            Create.Table("Store")
                .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString()
                .WithColumn("OpenAt").AsTime().Nullable()
                .WithColumn("CloseAt").AsTime().Nullable();

            Create.Table("Discount")
                .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("ProductId").AsInt64()
                .WithColumn("Price").AsDecimal()
                .WithColumn("Effective_From").AsDateTime().Nullable()
                .WithColumn("Effective_To").AsDateTime().Nullable();

            Create.Table("User")
                .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString()
                .WithColumn("YearOfBirth").AsInt32()
                .WithColumn("IsDeleted").AsBoolean().Nullable();
        }
    }
}