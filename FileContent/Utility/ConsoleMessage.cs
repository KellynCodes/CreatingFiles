using System;

namespace FileContent.Utility
{
    public class ConsoleMessage
    {
        public static void Message(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
