using FluentMigrator.Builders.Create.Table;

namespace HowShop.Core.Migrations
{
    /// <summary>
    /// TODO: Versioning conventions based on migration number
    /// </summary>
    public static class MigrationConventions
    {
        public static ICreateTableColumnOptionOrWithColumnSyntax WithPrimaryKey(this ICreateTableWithColumnSyntax createTable, string columnName = "Id")
        {
            return createTable.WithColumn(columnName).AsInt64().NotNullable().PrimaryKey().Identity();
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithName(this ICreateTableWithColumnSyntax createTable, string columnName = "Name")
        {
            return createTable.WithColumn("Name").AsString(64).NotNullable();
        }
    }
}
