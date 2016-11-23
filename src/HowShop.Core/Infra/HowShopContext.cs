using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.ModelConfiguration.Conventions;
using HowShop.Core.Domain;
using HowShop.Core.Infra.SaveChangesHandlers;
using SolidR.Core;
using SolidR.Core.EntityFramework;

namespace HowShop.Core.Infra
{
    public class HowShopContext : DbContext
    {
        private readonly IEnumerable<ISaveChangesHandler> _saveChangesHandlers;

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Category> Categories { get; set; }

        public HowShopContext(IEnumerable<ISaveChangesHandler> saveChangesHandlers) : base(App.ConnectionString)
        {
            _saveChangesHandlers = saveChangesHandlers;

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
            foreach (var saveChangesHandler in _saveChangesHandlers)
                saveChangesHandler.HandleSaveChanges(this);
            
            return base.SaveChanges();
        }
    }
}