using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp8
{
    class AccManagement
    {
        public static void ShowUsers() // ПОКАЗ / ПОДСЧЁТ ПОЛЬЗОВАТЕЛЕЙ
        {
            ColorTextOut.GreenText("Показ пльзователей\n\n");
            try
            {

                FileStream fs = new FileStream("Users.txt", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                Users user = (Users)formatter.Deserialize(fs);

                ColorTextOut.DarkCyanText("Количество пользователей: ");
                ColorTextOut.RedText(user.Logins.Count + "\n\n");

                fs.Close();
                for (int i = 0; i < user.Logins.Count; i++) // Ищем пользователя и проверяем правильность пароля.
                {
                    Console.Write("Пользователь [" + i + "]: ");
                    ColorTextOut.CyanText(user.Logins[i]);
                    if (i == 0)
                    {
                        ColorTextOut.RedText("\t{Admin} ");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
            }
            catch { Console.WriteLine("Данных нет"); }
            ColorTextOut.DarkCyanText("Для подолжения нажмите любую клавишу...");
        }
        public static void AddUser() // ДОБАВЛЕНИЕ ПОЛЬЗОВАТЕЛЯ
        {


            if (Admin_Check())
            {
                FileStream fs = new FileStream("Users.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryFormatter formatter = new BinaryFormatter();
                Users user;
                try
                {
                    user = (Users)formatter.Deserialize(fs);
                }
                catch
                {
                    user = new Users();
                }
                bool login_absent = true;
                ColorTextOut.GreenText("Добавление нового пользователя\n\n");
                ColorTextOut.CyanText("Пользователь: ");
                string _login = LoginPasswordTextIn.GetLogin();
                for (int i = 0; i < user.Logins.Count; i++)
                {
                    if (_login == user.Logins[i])
                    {
                        login_absent = false;
                        break;
                    }
                }
                if (login_absent)
                {
                    ColorTextOut.CyanText("Пароль Пользователя: ");
                    string _password = LoginPasswordTextIn.GetPassword();
                    if (_login == "" || _password == "") { Console.WriteLine("Не введен логин или пароль!"); }
                    else
                    {
                        fs.SetLength(0);
                        user.Logins.Add(_login);
                        user.Passwords.Add(_password);
                        formatter = new BinaryFormatter();
                        formatter.Serialize(fs, user); // Сериализуем класс.
                        Logs.AddUser(_login);
                        ColorTextOut.DarkCyanText("\nПользователь Добавлен! Для продолжения нажмите любую клавишу...");
                    }
                }
                else
                {
                    ColorTextOut.DarkCyanText("\nТакой пользователь уже существует!\nДля продолжения нажмите любую клавишу...");
                }
                fs.Close();
            }

        }
        public static void DeleteUser() // УДАЛЕНИЕ ПОЛЬЗОВАТЕЛЯ
        {
            if (Admin_Check())
            {
                ColorTextOut.GreenText("Удаление пользователя\n\n");
                FileStream fs = new FileStream("Users.txt", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                Users user = (Users)formatter.Deserialize(fs);
                if (user.Logins.Count == 1)
                {
                    ColorTextOut.DarkRedText("Единственный пользователь не может быть удалён!\nДля прододжения нажмите любую клавишу...");
                }
                else
                {
                    ColorTextOut.CyanText("Пользователь: ");
                    string _login = LoginPasswordTextIn.GetLogin();
                    ColorTextOut.CyanText("Пароль Пользователя: ");
                    string _password = LoginPasswordTextIn.GetPassword();
                    if (Program.current_login == _login && Program.current_password == _password)
                    {
                        int Choise_Delete;
                        ColorTextOut.RedText("\nВы уверены что хотите удалить Администатора?\nВ данном случае система перезапустится и роль администатора перейдёт следующему по спику пользователю\n\n");
                        ColorTextOut.CyanText("1.Да\n2.Нет\n\n");
                        Choise_Delete = IntNumRangeIn.ReadOnlyInt(1, 2);
                        switch (Choise_Delete)
                        {
                            case 1:
                                {
                                    fs.SetLength(0);
                                    Program.admin_changed = true;
                                    user.Logins.Remove(_login);
                                    user.Passwords.Remove(_password);
                                    formatter.Serialize(fs, user); // Сериализуем класс.
                                    ColorTextOut.DarkCyanText("\n\nУчётная запись Администратора удалёна! Данная роль перешла следующему по списку пользователю!\nДля продолжения нажмите любую клавишу...");
                                    break;
                                }
                            case 2:
                                {
                                    ColorTextOut.DarkCyanText("\n\nУчётная запись администратора не удалена!\n Для продолжения нажмите любую клавишу...");
                                    break;
                                }
                        }

                    }
                    else
                    {
                        {
                            try
                            {
                                bool user_absent = true;
                                for (int i = 0; i < user.Logins.Count; i++)
                                {
                                    if (_login == user.Logins[i] & _password == user.Passwords[i])
                                    {
                                        user_absent = false;
                                        break;
                                    }
                                }
                                if (user_absent == true)
                                {
                                    ColorTextOut.DarkRedText("\nПользователь или пароль не верны! Для продолжения нажмите любую клавишу...");
                                }
                                else
                                {
                                    fs.SetLength(0);
                                    user.Logins.Remove(_login);
                                    user.Passwords.Remove(_password);
                                    formatter.Serialize(fs, user); // Сериализуем класс.
                                    Logs.DeleteUser(_login);
                                    ColorTextOut.DarkCyanText("\nПользователь удалён! Для продолжения нажмите любую клавишу...");
                                }
                            }
                            catch
                            {
                                ColorTextOut.DarkRedText("\nПользователь не навйлен! Для продолжения нажмите любую клавишу...");
                            }
                        }
                    }
                }
                fs.Close();
            }
        }
        public static void ShowLogsUsers() // ЛОГИ ПОЛЬЗОВАТЕЛЕЙ
        {
            if (Admin_Check())
            {
                ColorTextOut.GreenText("Показ логов пользователей\n\n");
                EncryptDecrypt.Decrypt("LOGS.txt");
                FileStream stream = new FileStream("LOGS.txt", FileMode.OpenOrCreate);
                StreamReader reader = new StreamReader(stream);
                string str = reader.ReadToEnd();
                stream.Close();
                EncryptDecrypt.Crypt("LOGS.txt");
                ColorTextOut.CyanText(str + "\n\n");
                ColorTextOut.DarkCyanText("Для продолжения нажмите любую клавишу...");
            }
        }
        public static void AdminRightsTransfer() // ПЕРЕДАЧА ПРАВ
        {
            if (Admin_Check())
            {
                ColorTextOut.GreenText("Передача прав Администрора\n\n");
                FileStream fs = new FileStream("Users.txt", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                Users user = (Users)formatter.Deserialize(fs);
                if (user.Logins.Count == 1)
                {
                    ColorTextOut.DarkRedText("Единственный пользователь не может передать права!\nДля прододжения нажмите любую клавишу...");
                }
                else
                {
                    ColorTextOut.CyanText("Пользователь: ");
                    string _login = LoginPasswordTextIn.GetLogin();
                    ColorTextOut.CyanText("Пароль Пользователя: ");
                    string _password = LoginPasswordTextIn.GetPassword();
                    if (Program.current_login == _login && Program.current_password == _password)
                    {
                        ColorTextOut.RedText("\nВы уже являетесь администратором\nДля прододжения нажмите любую клавишу...");
                    }
                    else
                    {
                        {
                            try
                            {
                                bool user_absent = true;
                                int NewAdmin = 0;
                                for (int i = 0; i < user.Logins.Count; i++)
                                {
                                    if (_login == user.Logins[i] & _password == user.Passwords[i])
                                    {
                                        user_absent = false;
                                        NewAdmin = i;
                                        break;
                                    }
                                }
                                if (user_absent == true)
                                {
                                    ColorTextOut.DarkRedText("\nЛогин пользователя или пароль не верны! Для продолжения нажмите любую клавишу...");
                                }
                                else
                                {
                                    fs.SetLength(0);
                                    user.Logins[0] = user.Logins[NewAdmin];
                                    user.Passwords[0] = user.Passwords[NewAdmin];
                                    user.Logins[NewAdmin] = Program.current_login;
                                    user.Passwords[NewAdmin] = Program.current_password;
                                    formatter.Serialize(fs, user); // Сериализуем класс.
                                    Logs.TransferRights(_login, Program.current_login);
                                    ColorTextOut.DarkCyanText("\nПрава Переданы! Для продолжения нажмите любую клавишу...");
                                }
                            }
                            catch
                            {
                                ColorTextOut.DarkRedText("\nПользователь не навйлен! Для продолжения нажмите любую клавишу...");
                            }
                        }
                    }
                }
                fs.Close();
            }
        }


        /// ВСПОМОГАТЕЛЬНАЯ ФУНКЦИЯ

        public static bool Admin_Check() // АДМИН-ПРИВЕЛЕГИИ
        {
            try
            {
                FileStream fs = new FileStream("Users.txt", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                Users user = (Users)formatter.Deserialize(fs);
                fs.Close();
                if (user.Logins[0] == Program.current_login && user.Passwords[0] == Program.current_password)
                {
                    return true;
                }
                else
                {
                    ColorTextOut.RedText("Пользователь не является Администаратором и не может выполнить данное действие!\nДля продолжения нажмите любую клавишу...");
                    return false;
                }
            }
            catch
            {
                ColorTextOut.RedText("Неизвестная ошибка, возможно нет пользователей!\nДля продолжения нажмите любую клавишу...");
                return false;
            }
        }
    }
}
