using System.Data.Entity;
using HowShop.Core.Domain;
using SolidR.Core.EntityFramework;

namespace HowShop.Core.Infra
{
    public static class DatabaseContextExtensions
    {
        public static DbModelBuilder CustomMappings(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasMany(x => x.Stocks);

            modelBuilder.Entity<User>().Ignore(x => x.Currency);

            modelBuilder
                .Conventions.Add();
                  .Properties()
                  .Configure(c =>
                  {
                      var nonPublicProperties = c.ClrPropertyInfo..ClrType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);

                      foreach (var p in nonPublicProperties)
                      {
                          c.Property(p).HasColumnName(p.Name);
                      }
                  });

            modelBuilder
                .Properties()
                .Where(p => p.Name.EndsWith("Buddy"))
                .Configure(p =>
                {
                    p.HasColumnName(p.ClrPropertyInfo.Name.Replace("Buddy", string.Empty));
                });

            return modelBuilder;
        }
    }
}
