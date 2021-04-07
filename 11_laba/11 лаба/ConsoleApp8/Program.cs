using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp8
{
    class Program
    {

        /// ГЛОБАЛЬНЫЕ ПЕРЕМЕННЫЕ
        public static string current_login = string.Empty; // ДАННЫЙ ПОЛЬЗОВАТЕЛЬ СИСТЕМЫ
        public static string current_password = string.Empty; // ПАРОЛЬ ДАННОГО ПОЛЬЗОВАТЕЛЯ СИСТЕМЫ
        public static bool admin_changed = false; // ПЕРЕМЕННАЯ ДЛЯ ПРОВЕРКИ СМЕНЫ АДМИНИСТРАТОРА ПОСЛЕ УДАЛЕНИЯ У.З. АДМИНИСТАРТОРА
        public static int user_id;  //id ПОЛЬЗОВАТЕЛЯ
        public static string str;  //ВРЕМЕННАЯ СТРОКА

        private static void SystemLogin() // ВХОД В СИСТЕМУ
        {
            int Choise_Login;
            do
            {
                Console.Clear();
                admin_changed = false;
                ColorTextOut.GreenText("Генерация кораблей стоящих в порту и их динамическое хранение \nв виде кортежей, списков и обобщенных коллекций\n\n");
                ColorTextOut.YellowText("Войти в систему?\n\n1.Войти\n0.Завыршить работу\n\n");
                Choise_Login = IntNumRangeIn.ReadOnlyInt(0, 1);
                switch (Choise_Login)
                {
                    case 1:
                        {
                            try
                            {
                                Console.Clear();
                                ColorTextOut.GreenText("Генерация кораблей стоящих в порту и их динамическое хранение \nв виде кортежей, списков и обобщенных коллекций\n\n");
                                ColorTextOut.YellowText("Вход в систему\n\n");
                                FileStream fs = new FileStream("Users.txt", FileMode.Open);
                                BinaryFormatter formatter = new BinaryFormatter();
                                Users user = (Users)formatter.Deserialize(fs);
                                fs.Close();
                                ColorTextOut.CyanText("Пользователь: ");
                                string _login = LoginPasswordTextIn.GetLogin();
                                ColorTextOut.CyanText("Пароль: ");
                                string _password = LoginPasswordTextIn.GetPassword();
                                for (int i = 0; i < user.Logins.Count; i++) // Ищем пользователя и проверяем правильность пароля.
                                {
                                    if (user.Logins[i] == _login && user.Passwords[i] == _password)
                                    {
                                        Console.WriteLine();
                                        Console.Write("Вы вошли в систему!\nДля продолжения нажмите любую клавишу...");
                                        current_login = user.Logins[i];
                                        current_password = user.Passwords[i];

                                        {// ЗАПИСЬ
                                            user_id = i;
                                            Logs.LogIn(current_login, user_id);
                                        }

                                        Console.ReadKey();
                                        Console.Clear();
                                        TheSystem();
                                        break;
                                    }
                                    else if (user.Logins[i] == _login & _password != user.Passwords[i])
                                    {
                                        ColorTextOut.RedText("\nНеверный пароль!\n");
                                        int Counter_Wrong_Pass = 0;
                                        while (_password != user.Passwords[i])
                                        {
                                            ColorTextOut.CyanText("Пароль: ");
                                            _password = LoginPasswordTextIn.GetPassword();
                                            if (_password != user.Passwords[i])
                                            {
                                                ColorTextOut.RedText("\nНеверный пароль!\n");
                                                Counter_Wrong_Pass++;
                                                if (Counter_Wrong_Pass == 3)
                                                {
                                                    ColorTextOut.RedText("\nВы ввели пароль неверно более 3 раз\nДля продолдения нажмите любую клавишу...");
                                                    Logs.InvalidPass(_login);
                                                    Console.ReadKey();
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine();
                                                Console.Write("Вы вошли в систему!\nДля продолжения нажмите любую клавишу...");
                                                current_login = user.Logins[i];
                                                current_password = user.Passwords[i];
                                                {// ЗАПИСЬ
                                                    user_id = i;
                                                    Logs.LogIn(current_login, i);
                                                }
                                                Console.ReadKey();
                                                Console.Clear();
                                                TheSystem();
                                            }
                                        }
                                        break;
                                    }
                                    else if (i == user.Logins.Count - 1)
                                    {
                                        Console.WriteLine();
                                        ColorTextOut.RedText("Пользователь " + _login + " не найден!\nДля продолжения нажмите любую клавишу...");
                                        Console.ReadKey();
                                    }

                                }
                            }
                            catch { Console.WriteLine("Error acquired!"); return; }
                            break;
                        }
                    case 0:
                        {
                            Console.Write("\n\nДля продолжения нажмите любую клавишу...");
                            Console.ReadKey();
                            break;
                        }
                }
            } while (Choise_Login != 0);

        }
        private static void TheSystem() // СИСТЕМА ПОД ДАННОГО ПОЛЬЗОВАТЕЛЯ 
        {
            int Choise_System;
            do
            {
                Console.Clear();
                ColorTextOut.GreenText("Генерация кораблей стоящих в порту и их динамическое хранение\nв виде кортежей, списков и обобщенных коллекций\n\n");
                ColorTextOut.DarkCyanText("Системное меню:\n1.Выполнение программы\n2.Управление пользователями\n0.Выход\n\n");
                Choise_System = IntNumRangeIn.ReadOnlyInt(0, 2);
                switch (Choise_System)
                {
                    case 1:
                        {
                            DefendedProgram.MainProg();
                            break;
                        }
                    case 2:
                        {
                            UsersConfig();
                            //проверка
                            if (admin_changed == true)
                            {
                                Choise_System = 0;
                            }
                            break;
                        }
                    case 0:
                        {
                            Logs.LogOut(current_login, user_id);
                            break;
                        }

                }
            } while (Choise_System != 0);
        }
        
        private static void UsersConfig() // УПРАВЛЕНИЕ ПОЛЬЗОВАТЕЛЯМИ
        {
            int Choise_System_Config;
            do
            {
                Console.Clear();
                ColorTextOut.GreenText("Выбор действий над пользователем\n\n");
                ColorTextOut.DarkCyanText("Системное меню:\n1.Показать пользователей\n2.Добавление пользователя\n3.Удаление пользователя\n4.Просмотр логов пользователей\n5.Передача прав администрара\n0.Выход\n\n");
                Choise_System_Config = IntNumRangeIn.ReadOnlyInt(0, 5);
                switch (Choise_System_Config)
                {
                    case 1:
                        {
                            Console.Clear();
                            AccManagement.ShowUsers();
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            AccManagement.AddUser();
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            AccManagement.DeleteUser();
                            Console.ReadKey();

                            //проверка
                            if (admin_changed == true)
                            {
                                Choise_System_Config = 0;
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            AccManagement.ShowLogsUsers();
                            Console.ReadKey();
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            AccManagement.AdminRightsTransfer();
                            Console.ReadKey();
                            break;
                        }
                    case 0: break;
                }
            } while (Choise_System_Config != 0);
        }

        static void Main(string[] args)
        {
            {
                SystemLogin();
            }
        }
    }
        
}
    
