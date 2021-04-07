using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class ColorTextOut
    {
        public static void DarkRedText(string str) // ТЁМНО-КРАСНЫЙ ВЫВОД
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }
        public static void RedText(string str) // КРАСНВЫЙ ВЫВОД
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }
        public static void DarkCyanText(string str) // ТЁМНО-ЦИАНОВЫЙ ВЫВОД
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }
        public static void CyanText(string str) // ЦИАНОВЫЙ ВЫВОД
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }
        public static void YellowText(string str) // ЖЁЛТЫЙ ВЫВОД
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }
        public static void GreenText(string str) // ЗЕЛЁНЫЙ ВЫВОД
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }
    }
}
