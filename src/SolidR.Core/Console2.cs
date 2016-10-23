using System;

namespace SolidR.Core
{
    public class Console2
    {
        public static void Alert(string message, params object[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message, args);
            Console.ResetColor();
        }

        public static void Error(string message, params object[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message, args);
            Console.ResetColor();
        }

        public static void Normal(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }

        public static void Success(string message, params object[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message, args);
            Console.ResetColor();
        }
    }
}