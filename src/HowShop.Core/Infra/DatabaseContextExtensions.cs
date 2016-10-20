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
            
            modelBuilder
                .Properties()
                .Where(p => p.Name.EndsWith("Buddy"))
                .Configure(p => p.HasColumnName(p.ClrPropertyInfo.Name.Replace("Buddy", string.Empty)));

            return modelBuilder;
        }
    }
}
