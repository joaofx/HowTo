using FluentMigrator;
using FluentMigrator.Infrastructure.Extensions;

namespace HowShop.Core.Migrations
{
    [Migration(201610102319)]
    public class CreateInitial : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Product")
                .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()    
                .WithColumn("Audit_UpdatedAt").AsDateTime().Nullable()
                .WithColumn("Audit_CreatedAt").AsDateTime().Nullable()
                .WithColumn("Name").AsString(64).NotNullable()
                .WithColumn("Price").AsDecimal().NotNullable();

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
                .WithColumn("IsDeleted").AsBoolean().NotNullable();

            //Create.Table("Product")
            //    .WithIdentity(this)
            //    .WithName(this);

            //.With(x => x.Name())
            //.WithMoney("Price");
        }
    }

    public static class MigrationExtensions
    {
        static MigrationExtensions()
        {
            //For(x => x.Name());
        }

        public static void CreateTable(this AutoReversingMigration migration, string tableName)
        {
            var version = migration.GetType().GetOneAttribute<MigrationAttribute>().Version;

        }
        
        //public static ICreateTableColumnOptionOrWithColumnSyntax With(this ICreateTableWithColumnSyntax syntax, Expression<Func<object, object>> )
        //{
        //    return syntax.WithColumn("Name").AsString(64).NotNullable();
        //}
        
        //public static ICreateTableColumnOptionOrWithColumnSyntax WithIdentity(this ICreateTableWithColumnSyntax syntax, IMigration migration)
        //{
        //    if (migration.Version)
        //    return Forever(_ => )
        //    var version = migration.GetType().GetOneAttribute<MigrationAttribute>().Version;
        //    return syntax.WithColumn("Name").AsString(64).NotNullable();
        //}

        //public static ICreateTableColumnOptionOrWithColumnSyntax WithName(this ICreateTableWithColumnSyntax syntax, IMigration migration, string columnName = "Name")
        //{
        //    var version = migration.GetType().GetOneAttribute<MigrationAttribute>().Version;
        //    return syntax.WithColumn("Name").AsString(64).NotNullable();
        //}
    }
}