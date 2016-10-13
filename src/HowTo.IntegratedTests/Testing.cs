using System;
using System.Linq;
using HowShop.Core.Infra;
using MediatR;
using SolidR;

namespace HowTo.IntegratedTests
{
    public class Testing
    {
        public static void WithDb(Action<HowShopContext> action)
        {
            using (var db = App.Container.GetInstance<HowShopContext>())
            {
                action(db);
            };
        }

        public static TResult Send<TResult>(IRequest<TResult> message)
        {
            using (var scopedContainer = App.Container.CreateChildContainer())
            {
                var mediator = scopedContainer.GetInstance<IMediator>();
                return mediator.Send(message);
            }
        }

        public static void SaveAll(params object[] entities)
        {
            using (var db = App.Container.GetInstance<HowShopContext>())
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.ValidateOnSaveEnabled = false;

                foreach (var entity in entities)
                {
                    var entry = db.ChangeTracker.Entries().FirstOrDefault(entityEntry => entityEntry.Entity == entity);

                    if (entry == null)
                    {
                        db.Set(entity.GetType()).Add(entity);
                    }
                }

                db.SaveChanges();
            };
        }
    }
}
