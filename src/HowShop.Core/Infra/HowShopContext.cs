using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using HowShop.Core.Domain;
using HowShop.Core.Infra.SaveChangesHandlers;
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
            new DeleteOrphanSaveChangesHandler().HandleSaveChanges(this);
            new AuditSaveChangesHandler().HandleSaveChanges(this);
            new IntegratableSaveChangesHandler().HandleSaveChanges(this);
            
            return base.SaveChanges();
        }
    }
}