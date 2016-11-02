using FluentMigrator;
using HowShop.Core.Domain;

namespace HowShop.Core.Migrations
{
    [Migration(201611012354)]
    public class InsertAdminUser : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("User").Row(new
            {
                Name = "Admin",
                Email = "admin@shop.com",
                Profile = (int) Profile.Admin,
                Password = "123456",
                IsDeleted = false
            });
        }

        public override void Down()
        {
            Delete.FromTable("User").Row(new { Name = "Admin" });
        }
    }
}