using FluentMigrator;

namespace HowShop.Core.Migrations
{
    [Migration(201610192315)]
    public class AlterUserDropYearBirthAddSettings : Migration
    {
        public override void Up()
        {
            Delete.Column("YearOfBirth").FromTable("User");

            Alter.Table("User")
                .AddColumn("Language").AsString(5).Nullable()
                .AddColumn("TimeZone").AsString(255).Nullable()
                .AddColumn("Culture").AsString(5).Nullable()
                .AddColumn("Currency").AsString(3).Nullable();
        }

        public override void Down()
        {
            Create.Column("YearOfBirth").OnTable("User").AsInt32().Nullable();

            Delete.Column("Language").FromTable("User");
            Delete.Column("TimeZone").FromTable("User");
            Delete.Column("Culture").FromTable("User");
            Delete.Column("Currency").FromTable("User");
        }
    }
}