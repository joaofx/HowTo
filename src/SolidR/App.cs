using System;

namespace SolidR
{
    public class App
    {
        public static Func<DateTime> Clock = () => DateTime.Now;

        public const string ConnectionString =
            "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=how_to_ef;Integrated Security=SSPI;";
    }
}
