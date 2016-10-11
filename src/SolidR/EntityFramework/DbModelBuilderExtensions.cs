using System.Data.Entity;
using System.Linq;
using SolidR.Domain;
using Z.EntityFramework.Plus;

namespace SolidR.EntityFramework
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
