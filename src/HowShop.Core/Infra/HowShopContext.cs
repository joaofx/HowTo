using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using HowShop.Core.Domain;
using SolidR.Core;
using SolidR.Core.Domain;
using SolidR.Core.EntityFramework;

namespace HowShop.Core.Infra
{
    public class HowShopContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Category> Categories { get; set; }

        public HowShopContext() : base(App.ConnectionString)
        {
            Database.SetInitializer<HowShopContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            DbInterception.Add(new NLogCommandInterceptor(App.Log));

            modelBuilder.Conventions.Add<ForeignKeyNamingConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.SoftDeletableFilter();
            modelBuilder.CustomMappings();
        }

        public override int SaveChanges()
        {
            // TODO: Some conventional configurable way
            foreach (var orphan in Stocks.Local.Where(x => x.Product == null).ToList())
            {
                Stocks.Remove(orphan);
            }

            // TODO: IoC Before Save Handlers
            var entitiesBeingCreated = ChangeTracker.Entries<IAuditable>()
                    .Where(p => p.State == EntityState.Added)
                    .Select(p => p.Entity);

            foreach (var entityBeingCreated in entitiesBeingCreated)
            {
                entityBeingCreated.Audit.BeingCreated();
            }

            var entitiesBeingUpdated = ChangeTracker.Entries<IAuditable>()
                    .Where(p => p.State == EntityState.Modified)
                    .Select(p => p.Entity);

            foreach (var entityBeingUpdated in entitiesBeingUpdated)
            {
                entityBeingUpdated.Audit.BeingUpdated();
            }

            return base.SaveChanges();
        }
    }
}