using System.Data.Entity;
using System.Reflection;
using HowShop.Core.Domain;
using SolidR.Core;
using SolidR.Core.EntityFramework;

namespace HowShop.Core.Infra
{
    public static class DatabaseContextExtensions
    {
        public static DbModelBuilder CustomMappings(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasMany(x => x.Stocks);

            //modelBuilder.Entity<User>().Ignore(x => x.Currency);

            //modelBuilder
            //    .Conventions.Add();
            //      .Properties()
            //      .Configure(c =>
            //      {
            //          var nonPublicProperties = c.ClrPropertyInfo..ClrType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);

            //          foreach (var p in nonPublicProperties)
            //          {
            //              c.Property(p).HasColumnName(p.Name);
            //          }
            //      });

            modelBuilder.Types()
                .Configure(c =>
                {
                    var type = c.ClrType;
                    var nonPublicProperties = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);

                    foreach (var nonPublicProperty in nonPublicProperties)
                    {
                        if (nonPublicProperty.Name.EndsWith("Value"))
                        {
                            var publicPropertyName = nonPublicProperty.Name.Replace("Value", string.Empty);
                            var publicProperty = type.GetProperty(publicPropertyName);

                            if (publicProperty != null)
                            {
                                c.Ignore(publicPropertyName);
                                c.Property(nonPublicProperty.Name).HasColumnName(publicPropertyName);
                            }
                        }
                    }
                });

            //modelBuilder
            //    .Properties()
            //    .Where(p => p.Name.EndsWith("Value"))
            //    .Configure(p =>
            //    {
            //        var complexTypePropertyName = p.ClrPropertyInfo.Name.Replace("Value", string.Empty);
            //        var complexTypeProperty = p.ClrPropertyInfo.DeclaringType.GetProperty(complexTypePropertyName);

            //        if (complexTypeProperty != null)
            //        {
            //            p.HasColumnName(complexTypePropertyName);
            //        }
            //    });

            //modelBuilder.Properties().Configure(p =>
            //{
            //    App.Log.Debug($"{p.ClrPropertyInfo.DeclaringType.Name} - {p.ClrPropertyInfo.Name}");
            //});

            return modelBuilder;
        }
    }
}
