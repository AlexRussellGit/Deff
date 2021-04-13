using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Logs
    {
        public static void LogIn(string login, int id )
        {
            string s = "USER " + login + " LOGGED IN AT " + DateTime.Now;
            if (id == 0)
            {
                s += " {ADMIN}";
            }
            EncryptDecrypt.Decrypt("LOGS.txt");
            System.IO.StreamWriter writer = new System.IO.StreamWriter("LOGS.txt", true);
            writer.WriteLine(s);
            writer.Close();
            EncryptDecrypt.Crypt("LOGS.txt");

        }

        public static void LogOut(string login, int id )
        {
            string s = "USER " + login + " LOGGED OUT AT " + DateTime.Now;
            if (id==0)
            {
                s += " {ADMIN}";
            }
            EncryptDecrypt.Decrypt("LOGS.txt");
            System.IO.StreamWriter writer = new System.IO.StreamWriter("LOGS.txt", true);
            writer.WriteLine(s);
            writer.Close();
            EncryptDecrypt.Crypt("LOGS.txt");
        }

        public static void LogOut(string login, int id, string str)
        {
            string s = "USER " + login + " LOGGED OUT" + str + " AT " + DateTime.Now;
            if (id == 0)
            {
                s += " {ADMIN}";
            }
            EncryptDecrypt.Decrypt("LOGS.txt");
            System.IO.StreamWriter writer = new System.IO.StreamWriter("LOGS.txt", true);
            writer.WriteLine(s);
            writer.Close();
            EncryptDecrypt.Crypt("LOGS.txt");
        }


        public static void AddUser(string login)
        {
            string s = "NEW USER " + login + " ADDED AT " + DateTime.Now + "\n";
            EncryptDecrypt.Decrypt("LOGS.txt");
            System.IO.StreamWriter writer = new System.IO.StreamWriter("LOGS.txt", true);
            writer.WriteLine(s);
            writer.Close();
            EncryptDecrypt.Crypt("LOGS.txt");
        }

        public static void DeleteUser(string login)
        {
            string s = "USER " + login + " DELETED AT " + DateTime.Now + "\n";
            EncryptDecrypt.Decrypt("LOGS.txt");
            System.IO.StreamWriter writer = new System.IO.StreamWriter("LOGS.txt", true);
            writer.WriteLine(s);
            writer.Close();
            EncryptDecrypt.Crypt("LOGS.txt");
        }

        public static void TransferRights(string login_adm, string login)
        {
            string s = "ADMIN RIGHTS CHANGED FROM " + login + " TO USER " + login_adm + " AT " + DateTime.Now + "\n";
            EncryptDecrypt.Decrypt("LOGS.txt");
            System.IO.StreamWriter writer = new System.IO.StreamWriter("LOGS.txt", true);
            writer.WriteLine(s);
            writer.Close();
            EncryptDecrypt.Crypt("LOGS.txt");
        }

        public static void InvalidPass(string login)
        {
            string s = "USER " + login + " WROTE INVALID PASSWORD AT " + DateTime.Now + "\n";
            EncryptDecrypt.Decrypt("LOGS.txt");
            System.IO.StreamWriter writer = new System.IO.StreamWriter("LOGS.txt", true);
            writer.WriteLine(s);
            writer.Close();
            EncryptDecrypt.Crypt("LOGS.txt");
        }

    }
}
