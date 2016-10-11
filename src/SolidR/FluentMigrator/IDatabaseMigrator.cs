using System.Reflection;

namespace SolidR.FluentMigrator
{
    public interface IDatabaseMigrator
    {
        void UpdateSchema(Assembly assembly = null);
    }
}