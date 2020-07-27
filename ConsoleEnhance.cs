// ReSharper disable HeapView.BoxingAllocation

using System;
using System.Collections.Generic;

namespace playCS
{
    public static class ConsoleEnhance
    {
        static readonly Random random = new Random();

        // static IList<ConsoleColor> consoleColors = ((IList<ConsoleColor>) Enum.GetValues(typeof(ConsoleColor)));
        static List<ConsoleColor> coloredConsoleColors = new List<ConsoleColor>()
        {
            ConsoleColor.DarkBlue,
            ConsoleColor.DarkGreen,
            ConsoleColor.DarkCyan,
            ConsoleColor.DarkRed,
            ConsoleColor.DarkMagenta,
            ConsoleColor.DarkYellow,
            ConsoleColor.Blue,
            ConsoleColor.Green,
            ConsoleColor.Cyan,
            ConsoleColor.Red,
            ConsoleColor.Magenta,
            ConsoleColor.Yellow,
        };

        public static void Rainbow()
        {
            foreach (ConsoleColor consoleColor in coloredConsoleColors)
            {
                Console.ForegroundColor = consoleColor;
                Console.WriteLine(consoleColor.ToString());
            }

            Console.ResetColor();
        }

        public static void RainbowWriteLine(string args)
        {
            Console.ForegroundColor = coloredConsoleColors[random.Next(0, coloredConsoleColors.Count)];
            Console.WriteLine(args);
            Console.ResetColor();
        }


        public static void HrLine()
        {
        }
        
    }
}