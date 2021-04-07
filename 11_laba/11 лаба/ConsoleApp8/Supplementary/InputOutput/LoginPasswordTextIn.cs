using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class LoginPasswordTextIn
    {
        public static String GetLogin() // ЛОГИН-ВВОД
        {
            String Loggin = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                // Ignore any key out of range.
                if (((int)key.Key) >= 65 && ((int)key.Key <= 90))
                {
                    // Append the character to the password.
                    Loggin += key.KeyChar;
                    ColorTextOut.DarkCyanText(key.KeyChar.ToString());
                }
                if (Loggin.Length > 15)
                {
                    ColorTextOut.RedText("\t\t(допустимый разер логина не больше 15 символов)");
                    break;
                }
                // Exit if Enter key is pressed.
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return Loggin;
        }
        public static String GetPassword() // ПАРОЛЬ-ВВОД
        {
            String Password = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                // Ignore any key out of range.
                if (((int)key.Key) >= 65 && ((int)key.Key <= 90) || ((int)key.Key) >= 48 && ((int)key.Key <= 57))
                {
                    // Append the character to the password.
                    Password += key.KeyChar;
                    ColorTextOut.DarkCyanText("*");
                }
                if (Password.Length > 15)
                {
                    ColorTextOut.RedText("\t\t(допустимый разер пароля не больше 15 символов)");
                    break;
                }
                // Exit if Enter key is pressed.
            } while (key.Key != ConsoleKey.Enter);

            System.Threading.Thread.Sleep(500);
            Console.WriteLine();
            return Password;
        }
    }
}
