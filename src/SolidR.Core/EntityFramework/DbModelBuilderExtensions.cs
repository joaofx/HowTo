using System.Data.Entity;
using System.Linq;
using SolidR.Core.Domain;
using Z.EntityFramework.Plus;

namespace SolidR.Core.EntityFramework
{
    public static class DbModelBuilderExtensions
    {
        public static DbModelBuilder SoftDeletableFilter(this DbModelBuilder modelBuilder)
        {
            QueryFilterManager.Filter<ISoftDeletable>(q => q.Where(x => x.IsDeleted == false));
            return modelBuilder;
        }
    }
}
