using System;
using NLog;
using StructureMap;

namespace SolidR
{
    public class App
    {
        public static Func<DateTime> Clock = () => DateTime.Now;

        public const string ConnectionString =
            "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=how_to_ef;Integrated Security=SSPI;";

        // TODO: Refactor
        public static Logger Log => SolidR.Log.App;
        public static IContainer Container { get; set; }
    }
}
