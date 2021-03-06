using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp8
{
    class EncryptDecrypt
    {
        public static void Crypt(string FileName) // ШИФРОВКА ФАЙЛА
        {
            short[] key = { 3, 1, 4, 2 };
            string[] rf = File.ReadAllLines(FileName);
            StreamWriter sw = new StreamWriter(FileName);
            for (int k = 0; k < rf.Length; k++)
            {
                string str = "";
                int n2 = key.Count();
                int n1;
                if (rf[k].Length % n2 == 0) n1 = rf[k].Length / n2;
                else n1 = rf[k].Length / n2 + 1;
                char[][] matr = new char[n1][];
                int c1 = 0;
                for (int i = 0; i < n1; i++)
                {
                    matr[i] = new char[n2];
                    for (int j = 0; j < n2; j++)
                    {
                        if (c1 >= rf[k].Length) matr[i][j] = ' ';
                        else matr[i][j] = rf[k][c1];
                        c1++;
                    }
                }
                for (int i = 0; i < n2; i++)
                    for (int j = 0; j < n1; j++)
                        str += matr[j][key[i] - 1];
                sw.WriteLine(str);
            }
            sw.Close();
        }
        public static void Decrypt(string FileName)   // ДЕШИФРОВКА ФАЙЛА
        {
            short[] key = { 3, 1, 4, 2 };
            string[] rf = File.ReadAllLines(FileName);
            StreamWriter sw = new StreamWriter(FileName);
            for (int k = 0; k < rf.Length; k++)
            {
                string str = "";
                int n2 = key.Count();
                int n1;
                if (rf[k].Length % n2 == 0) n1 = rf[k].Length / n2;
                else n1 = rf[k].Length / n2 + 1;

                char[][] matr = new char[n2][];
                int c1 = 0;
                for (int i = 0; i < n2; i++)
                    matr[i] = new char[n1];

                for (int i = 0; i < n2; i++)
                {
                    for (int j = 0; j < n1; j++)
                    {
                        matr[key[i] - 1][j] = rf[k][c1];
                        c1++;
                    }
                }
                for (int i = 0; i < n1; i++)
                    for (int j = 0; j < n2; j++)
                        str += matr[j][i];
                str = str.TrimEnd(' ');
                sw.WriteLine(str);
            }
            sw.Close();
        }
    }
}
