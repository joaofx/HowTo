using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using HowShop.Core.Domain;
using SolidR;
using SolidR.Domain;
using Z.EntityFramework.Plus;

namespace HowToEntityFramework.Infra
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base(App.ConnectionString)
        {
            Database.SetInitializer<DatabaseContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add<ForeignKeyNamingConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            DbInterception.Add(new NLogCommandInterceptor(Log.App));

            // TODO: IoC Configurable
            QueryFilterManager.Filter<ISoftDeletable>(q => q.Where(x => x.IsDeleted == false));

            // TODO: Move mappings
            modelBuilder.Entity<Product>()
                .HasMany(x => x.Stocks);

            //modelBuilder.Entity<Stock>().HasKey(x => new { x.Id, x.ProductId });

            modelBuilder
                .Properties()
                .Where(p => p.Name.EndsWith("Buddy"))
                .Configure(p => p.HasColumnName(p.ClrPropertyInfo.Name.Replace("Buddy", string.Empty)));
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

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}