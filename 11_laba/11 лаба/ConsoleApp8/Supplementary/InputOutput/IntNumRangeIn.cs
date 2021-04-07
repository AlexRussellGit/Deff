using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class IntNumRangeIn
    {
        public static int ReadOnlyInt(int a, int b) // ЦИФР-ВВОД
        {
            int value;
            bool ok = false;
            ConsoleKeyInfo key;
            do
            {
                ColorTextOut.CyanText("Введите значение: ");
                string buf = "";

                do
                {
                    key = Console.ReadKey(true);

                    // Ignore any key out of range.
                    if (((int)key.Key) >= 48 && ((int)key.Key <= 57))
                    {
                        // Append the character to the password.
                        buf += key.KeyChar;
                        ColorTextOut.DarkCyanText(key.KeyChar.ToString());
                    }
                    if (buf.Length > 5)
                    {
                        ColorTextOut.RedText("\t\t(допустимый разер не больше 5 символов)");
                        break;
                    }
                    // Exit if Enter key is pressed.
                } while (key.Key != ConsoleKey.Enter);

                ok = Int32.TryParse(buf, out value);
                if (value >= a && value <= b)
                {

                }
                else
                {
                    ok = false;
                }
                if (ok == false)
                {
                    ColorTextOut.DarkRedText("\nОшибка: ");
                    ColorTextOut.RedText("Значение не правильно!!!");
                    Console.WriteLine();
                    Console.WriteLine();
                }
            } while (ok == false);
            return value;
        }
    }
}
