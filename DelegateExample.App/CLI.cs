using System;

namespace DelegateExample.App
{
    public static class CLI
    {
        private static void Print(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void PrintInfo(string message) => Print(message, ConsoleColor.Blue);
        public static void PrintError(string message) => Print(message, ConsoleColor.Red);

        public static void Show(string message) => Print(message, ConsoleColor.Yellow);
    }
}