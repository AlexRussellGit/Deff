using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        /// <summary>
        /// Тёмно-красный текст
        /// </summary>
        static void DarkRedText(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }
        /// <summary>
        /// Красный текст
        /// </summary>
        static void RedText(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }
        /// <summary>
        /// Голубой текст
        /// </summary>
        static void CyanText(string str)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }
        /// <summary>
        /// Зеленый текст
        /// </summary>
        static void GreenText(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }
        static int ReadOnlyInt(int a, int b)  // Метод для чтения только целых положительных чисел
        {
            int value;
            bool ok = false;
            do
            {
                Console.Write("Введите значение: ");
                string buf = Console.ReadLine();
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
                    DarkRedText("Ошибка: ");
                    RedText("Значение не правильно!!!");
                    Console.WriteLine();
                    Console.WriteLine();
                }
            } while (ok == false);
            return value;
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            int Choise_0;
            do
            {
                GreenText("11 Лабораторная");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Главное Меню:\n 1. Работа со Stack (Стек)\n 2. Работа с List<T> (Кортеж)\n 3. Работа с MySortedDictionary<T> (Обобщенная коллекция)\n 0. Выход\n");
                Choise_0 = ReadOnlyInt(0, 3);
                switch (Choise_0)
                {
                    case 1:
                        {
                            //Настройка под 1 Задание
                            Stack<Class_Ships> Pringles_Ships = new Stack<Class_Ships>();
                            Pringles_Ships.Push(new Class_Steamboat_Ships());
                            Pringles_Ships.Push(new Class_Corvette_Ships());
                            Pringles_Ships.Push(new Class_Sailboat_Ships());
                            Pringles_Ships.Push(new Class_Steamboat_Ships("Удача", 31, 150, 275));
                            Pringles_Ships.Push(new Class_Corvette_Ships("Испепелитель", 32, 90, 10, 35));
                            Pringles_Ships.Push(new Class_Corvette_Ships("Грохот", 15, 54, 6, 15));
                            Pringles_Ships.Push(new Class_Steamboat_Ships("Геракл", 45, 140, 350));
                            Pringles_Ships.Push(new Class_Sailboat_Ships("Ленивец", 9, 70, 5));
                            Pringles_Ships.Push(new Class_Steamboat_Ships("Новая Земля", 35, 110, 310));
                            Pringles_Ships.Push(new Class_Corvette_Ships("Негатив", 3, 20, -100, 1));
                            int Counter_Stack = Pringles_Ships.Count();
                            //Конец настройки для 1 Задания
                            Console.Clear();
                            int Choise_1;
                            do
                            {
                                GreenText("1 Задание 11 Лабораторной");
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Второстепенное Меню:\n 1. Добавление объекта в словарь\n 2. Удаление объекта из словарь\n 3. Печать всех элементов в списке\n 4. Количество созданных объектов типа \"Корвет\"\n 5. Количество созданных объектов типа \"Пароход\"\n 6. Вывести на экран все объекты типа \"Парусник\" \n 0. Выход");
                                Console.WriteLine();
                                Choise_1 = ReadOnlyInt(0, 6);

                                switch (Choise_1)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            GreenText("1 Задание 11 Лабораторной");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            int Choise_Add_Ships;
                                            do
                                            {
                                                Console.WriteLine("Какой корабль хотели бы добавит?\n 1. Добавление Парохода\n 2. Добавление Парусника\n 3. Добавление Корвета\n 0. Выход");
                                                Choise_Add_Ships = ReadOnlyInt(0, 3);
                                                switch (Choise_Add_Ships)
                                                {
                                                    case 1:
                                                        {
                                                            Console.Clear();
                                                            GreenText("Добавление элемента");
                                                            Console.WriteLine();
                                                            Console.WriteLine();
                                                            string a;
                                                            int b, c, d;
                                                            Console.Write("(Имя) Введите значение: ");
                                                            a = Console.ReadLine();
                                                            Console.Write("(Скорость) ");
                                                            b = ReadOnlyInt(0, 1000);
                                                            Console.Write("(Водоизмещение) ");
                                                            c = ReadOnlyInt(0, 1000);
                                                            Console.Write("(Мощьность) ");
                                                            d = ReadOnlyInt(0, 1000);
                                                            Pringles_Ships.Push(new Class_Steamboat_Ships(a, b, c, d));
                                                            Console.WriteLine();
                                                            GreenText("Корабль создан.\n\nДля продолжения нажмите любую кнопку...");
                                                            Console.ReadKey();
                                                            Console.Clear();
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            Console.Clear();
                                                            GreenText("Добавление элемента");
                                                            Console.WriteLine();
                                                            Console.WriteLine();
                                                            string a;
                                                            int b, c, d;
                                                            Console.Write("(Имя) Введите значение: ");
                                                            a = Console.ReadLine();
                                                            Console.Write("(Скорость) ");
                                                            b = ReadOnlyInt(0, 1000);
                                                            Console.Write("(Водоизмещение) ");
                                                            c = ReadOnlyInt(0, 1000);
                                                            Console.Write("(Колличество парусов) ");
                                                            d = ReadOnlyInt(0, 1000);
                                                            Pringles_Ships.Push(new Class_Sailboat_Ships(a, b, c, d));
                                                            Console.WriteLine();
                                                            GreenText("Корабль создан.\n\nДля продолжения нажмите любую кнопку...");
                                                            Console.ReadKey();
                                                            Console.Clear();
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            Console.Clear();
                                                            GreenText("Добавление элемента");
                                                            Console.WriteLine();
                                                            Console.WriteLine();
                                                            string a;
                                                            int b, c, d, e;
                                                            Console.Write("(Имя) Введите значение: ");
                                                            a = Console.ReadLine();
                                                            Console.Write("(Скорость) ");
                                                            b = ReadOnlyInt(0, 1000);
                                                            Console.Write("(Водоизмещение) ");
                                                            c = ReadOnlyInt(0, 1000);
                                                            Console.Write("(Колличество парусов) ");
                                                            d = ReadOnlyInt(0, 1000);
                                                            Console.Write("(Колличество огнестрельного орудия) ");
                                                            e = ReadOnlyInt(0, 1000);
                                                            Pringles_Ships.Push(new Class_Corvette_Ships(a, b, c, d, e));
                                                            Console.WriteLine();
                                                            GreenText("Корабль создан.\n\nДля продолжения нажмите любую кнопку...");
                                                            Console.ReadKey();
                                                            Console.Clear();
                                                            break;
                                                        }
                                                    case 0: break;
                                                }
                                            } while (Choise_Add_Ships != 0);
                                            Console.Clear();
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            GreenText("1 Задание 11 Лабораторной");
                                            Counter_Stack = Pringles_Ships.Count();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            if (Counter_Stack > 0)
                                            {
                                                Pringles_Ships.Pop();
                                                GreenText("Эдемент Удален\n\nДля продолжения нажмите любую кнопку...");
                                            }
                                            else
                                            {
                                                GreenText("В Словаре нет элементов!!!\n\nДля продолжения нажмите любую кнопку...");
                                            }
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            GreenText("1 Задание 11 Лабораторной");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Counter_Stack = Pringles_Ships.Count();
                                            if (Counter_Stack > 0)
                                            {
                                                foreach (Class_Ships i in Pringles_Ships)
                                                {
                                                    i.Show();
                                                }
                                                GreenText("Для продолжения нажмите любую кнопку...");
                                            }
                                            else
                                            {
                                                GreenText("В Словаре нет элементов!!!\n\nДля продолжения нажмите любую кнопку...");
                                            }

                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.Clear();
                                            GreenText("1 Задание 11 Лабораторной");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Class_Corvette_Ships.Numb_Of_Corvette();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            GreenText("Для продолжения нажмите любую кнопку...");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.Clear();
                                            GreenText("1 Задание 11 Лабораторной");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            int Counter_For_Steamboat = 0;
                                            foreach (Class_Ships i in Pringles_Ships)
                                            {
                                                if (i is Class_Steamboat_Ships)
                                                    Counter_For_Steamboat++;
                                            }
                                            Console.WriteLine("Количество имеющихся объектов типа \"Пароход\" в списке: " + Counter_For_Steamboat);
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            GreenText("Для продолжения нажмите любую кнопку...");

                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    case 6:
                                        {
                                            Console.Clear();
                                            GreenText("1 Задание 11 Лабораторной");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            foreach (Class_Ships i in Pringles_Ships)
                                            {
                                                if (i is Class_Sailboat_Ships)
                                                    i.Show();
                                            }
                                            Console.WriteLine();
                                            GreenText("Для продолжения нажмите любую кнопку...");

                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    case 0: break;
                                }


                            } while (Choise_1 != 0);
                            Console.Clear();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            //Настройка под 2 Задание
                            List<Class_Ships> Convoy_Ships = new List<Class_Ships>();
                            Convoy_Ships.Add(new Class_Steamboat_Ships());
                            Convoy_Ships.Add(new Class_Corvette_Ships());
                            Convoy_Ships.Add(new Class_Sailboat_Ships());
                            Convoy_Ships.Add(new Class_Steamboat_Ships("Удача", 31, 150, 275));
                            Convoy_Ships.Add(new Class_Corvette_Ships("Испепелитель", 32, 90, 10, 35));
                            Convoy_Ships.Add(new Class_Corvette_Ships("Грохот", 15, 54, 6, 15));
                            Convoy_Ships.Add(new Class_Steamboat_Ships("Геракл", 45, 140, 350));
                            Convoy_Ships.Add(new Class_Sailboat_Ships("Ленивец", 9, 70, 5));
                            Convoy_Ships.Add(new Class_Steamboat_Ships("Новая Земля", 35, 110, 310));
                            Convoy_Ships.Add(new Class_Corvette_Ships("Негатив", 3, 20, -100, 1));
                            int Counter_Stack = Convoy_Ships.Count();
                            //Конец настройки для 2 Задания
                            int Choise_2;
                            do
                            {
                                GreenText("2 Задание 11 Лабораторной");
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Второстепенное Меню:\n 1. Добавление объекта в словарь\n 2. Удаление объектов с заданным именем из словаря\n 3. Вывод всех элементов словаря\n 4. Количество созданных объектов типа \"Корвет\"\n 5. Количество созданных объектов типа \"Пароход\"\n 6. Вывести на экран все объекты типа \"Парусник\" \n 0. Выход");
                                Console.WriteLine();
                                Choise_2 = ReadOnlyInt(0, 6);

                                switch (Choise_2)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            GreenText("2 Задание 11 Лабораторной");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            int Choise_Add_Ships;
                                            do
                                            {
                                                Console.WriteLine("Какой корабль хотели бы добавит?\n 1. Добавление Парохода\n 2. Добавление Парусника\n 3. Добавление Корвета\n 0. Выход");
                                                Choise_Add_Ships = ReadOnlyInt(0, 3);
                                                switch (Choise_Add_Ships)
                                                {
                                                    case 1:
                                                        {
                                                            Console.Clear();
                                                            GreenText("Добавление элемента");
                                                            Console.WriteLine();
                                                            Console.WriteLine();
                                                            string a;
                                                            int b, c, d;
                                                            Console.Write("(Имя) Введите значение: ");
                                                            a = Console.ReadLine();
                                                            Console.Write("(Скорость) ");
                                                            b = ReadOnlyInt(0, 1000);
                                                            Console.Write("(Водоизмещение) ");
                                                            c = ReadOnlyInt(0, 1000);
                                                            Console.Write("(Мощьность) ");
                                                            d = ReadOnlyInt(0, 1000);
                                                            Convoy_Ships.Add(new Class_Steamboat_Ships(a, b, c, d));
                                                            Console.WriteLine();
                                                            GreenText("Корабль создан.\n\nДля продолжения нажмите любую кнопку...");
                                                            Console.ReadKey();
                                                            Console.Clear();
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            Console.Clear();
                                                            GreenText("Добавление элемента");
                                                            Console.WriteLine();
                                                            Console.WriteLine();
                                                            string a;
                                                            int b, c, d;
                                                            Console.Write("(Имя) Введите значение: ");
                                                            a = Console.ReadLine();
                                                            Console.Write("(Скорость) ");
                                                            b = ReadOnlyInt(0, 1000);
                                                            Console.Write("(Водоизмещение) ");
                                                            c = ReadOnlyInt(0, 1000);
                                                            Console.Write("(Колличество парусов) ");
                                                            d = ReadOnlyInt(0, 1000);
                                                            Convoy_Ships.Add(new Class_Sailboat_Ships(a, b, c, d));
                                                            Console.WriteLine();
                                                            GreenText("Корабль создан.\n\nДля продолжения нажмите любую кнопку...");
                                                            Console.ReadKey();
                                                            Console.Clear();
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            Console.Clear();
                                                            GreenText("Добавление элемента");
                                                            Console.WriteLine();
                                                            Console.WriteLine();
                                                            string a;
                                                            int b, c, d, e;
                                                            Console.Write("(Имя) Введите значение: ");
                                                            a = Console.ReadLine();
                                                            Console.Write("(Скорость) ");
                                                            b = ReadOnlyInt(0, 1000);
                                                            Console.Write("(Водоизмещение) ");
                                                            c = ReadOnlyInt(0, 1000);
                                                            Console.Write("(Колличество парусов) ");
                                                            d = ReadOnlyInt(0, 1000);
                                                            Console.Write("(Колличество огнестрельного орудия) ");
                                                            e = ReadOnlyInt(0, 1000);
                                                            Convoy_Ships.Add(new Class_Corvette_Ships(a, b, c, d, e));
                                                            Console.WriteLine();
                                                            GreenText("Корабль создан.\n\nДля продолжения нажмите любую кнопку...");
                                                            Console.ReadKey();
                                                            Console.Clear();
                                                            break;
                                                        }
                                                    case 0: break;
                                                }
                                            } while (Choise_Add_Ships != 0);
                                            Console.Clear();
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            GreenText("2 Задание 11 Лабораторной");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            int Counter_Of_Deletes = 0;
                                            string a;
                                            Console.Write("Введите имя коробля(ей) который(ые) надо удалить: ");
                                            a = Console.ReadLine();
                                            foreach (Class_Ships i in Convoy_Ships)
                                            {
                                                if (a == i.Name)
                                                {
                                                    Console.Write("Удаляется элемент: ");
                                                    i.Show();
                                                    Convoy_Ships.Remove(i);
                                                    Counter_Of_Deletes++;
                                                    break;
                                                }

                                            }
                                            if (Counter_Of_Deletes > 0)
                                            {
                                                Console.WriteLine("Элемент(ы) удален(ы)!");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Ошибка!!! Элемент не найден!!!");
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            GreenText("Для продолжения нажмите любую кнопку...");

                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            GreenText("2 Задание 11 Лабораторной");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Counter_Stack = Convoy_Ships.Count();
                                            if (Counter_Stack > 0)
                                            {
                                                foreach (Class_Ships i in Convoy_Ships)
                                                {
                                                    i.Show();
                                                }
                                                GreenText("Для продолжения нажмите любую кнопку...");
                                            }
                                            else
                                            {
                                                GreenText("В Словаре нет элементов!!!\n\nДля продолжения нажмите любую кнопку...");
                                            }
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.Clear();
                                            GreenText("2 Задание 11 Лабораторной");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Class_Corvette_Ships.Numb_Of_Corvette();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            GreenText("Для продолжения нажмите любую кнопку...");

                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.Clear();
                                            GreenText("2 Задание 11 Лабораторной");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            int Counter_For_Steamboat = 0;
                                            foreach (Class_Ships i in Convoy_Ships)
                                            {
                                                if (i is Class_Steamboat_Ships)
                                                {
                                                    Counter_For_Steamboat++;
                                                }
                                            }
                                            Console.WriteLine("Количество имеющихся объектов типа \"Пароход\" в списке: " + Counter_For_Steamboat);
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            GreenText("Для продолжения нажмите любую кнопку...");

                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    case 6:
                                        {
                                            Console.Clear();
                                            GreenText("2 Задание 11 Лабораторной");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            foreach (Class_Ships i in Convoy_Ships)
                                            {
                                                if (i is Class_Sailboat_Ships)
                                                    i.Show();
                                            }
                                            Console.WriteLine();
                                            GreenText("Для продолжения нажмите любую кнопку...");

                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    case 0: break;
                                }
                                Console.Clear();

                            } while (Choise_2 != 0);
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            ///
                            MySortedDictionary<int, Class_Ships> Key_Value_Ships = new MySortedDictionary<int, Class_Ships>();
                            Key_Value_Ships.Add(1, new Class_Steamboat_Ships());
                            Key_Value_Ships.Add(2, new Class_Corvette_Ships());
                            Key_Value_Ships.Add(3, new Class_Sailboat_Ships());
                            Key_Value_Ships.Add(4, new Class_Steamboat_Ships("Удача", 31, 150, 275));
                            Key_Value_Ships.Add(5, new Class_Corvette_Ships("Испепелитель", 32, 90, 10, 35));
                            Key_Value_Ships.Add(6, new Class_Corvette_Ships("Грохот", 15, 54, 6, 15));
                            Key_Value_Ships.Add(7, new Class_Steamboat_Ships("Геракл", 45, 140, 350));
                            Key_Value_Ships.Add(8, new Class_Sailboat_Ships("Ленивец", 9, 70, 5));
                            Key_Value_Ships.Add(9, new Class_Steamboat_Ships("Новая Земля", 35, 110, 310));
                            Key_Value_Ships.Add(10, new Class_Corvette_Ships("Негатив", 3, 20, -100, 1));
                            int[] arr = new int[10];
                            for (int j = 0; j < arr.Length; j++)
                            {
                                arr[j] = j + 1;
                            }


                            ///

                            GreenText("3 Задание  11 Лабораторной");
                            Console.WriteLine();
                            Console.WriteLine();
                            int Choise_3;

                            do
                            {
                                Console.WriteLine("Второстепенное Меню:\n 1. Добавление объекта в словарь\n 2. Удаление объектов с ключем\n 3. Вывод всех элементов словаря\n 4. Создание клона\n 0. Выход");
                                Console.WriteLine();
                                Choise_3 = ReadOnlyInt(0, 4);
                                switch (Choise_3)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            GreenText("3 Задание 11 Лабораторной");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            int Choise_Add_Ships;
                                            do
                                            {
                                                Console.WriteLine("Какой корабль хотели бы добавит?\n 1. Добавление Парохода\n 2. Добавление Парусника\n 3. Добавление Корвета\n 0. Выход");
                                                Choise_Add_Ships = ReadOnlyInt(0, 3);
                                                switch (Choise_Add_Ships)
                                                {
                                                    case 1:
                                                        {
                                                            Console.Clear();
                                                            GreenText("Добавление элемента");
                                                            Console.WriteLine();
                                                            Console.WriteLine();
                                                            string a;
                                                            int b, c, d, Booler;
                                                            Console.Write("(Ключ) ");
                                                            Booler = ReadOnlyInt(0, 1000000);
                                                            if (Key_Value_Ships.GetByIndex(Booler) == null)
                                                            {
                                                                Console.Write("(Имя) Введите значение: ");
                                                                a = Console.ReadLine();
                                                                Console.Write("(Скорость) ");
                                                                b = ReadOnlyInt(0, 1000);
                                                                Console.Write("(Водоизмещение) ");
                                                                c = ReadOnlyInt(0, 1000);
                                                                Console.Write("(Мощьность) ");
                                                                d = ReadOnlyInt(0, 1000);
                                                                Key_Value_Ships.Add(Booler, new Class_Sailboat_Ships(a, b, c, d));
                                                                Console.WriteLine();
                                                                GreenText("Корабль создан.\n\nДля продолжения нажмите любую кнопку...");
                                                            }
                                                            else
                                                            {
                                                                GreenText("Корабль не создан - такой ключ уже существует.\n\nДля продолжения нажмите любую кнопку...");
                                                            }
                                                            Console.ReadKey();
                                                            Console.Clear();
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            Console.Clear();
                                                            GreenText("Добавление элемента");
                                                            Console.WriteLine();
                                                            Console.WriteLine();
                                                            string a;
                                                            int b, c, d, Booler;
                                                            Console.Write("(Ключ) ");
                                                            Booler = ReadOnlyInt(0, 1000000);
                                                            if (Key_Value_Ships.GetByIndex(Booler) == null)
                                                            {
                                                                Console.Write("(Имя) Введите значение: ");
                                                                a = Console.ReadLine();
                                                                Console.Write("(Скорость) ");
                                                                b = ReadOnlyInt(0, 1000);
                                                                Console.Write("(Водоизмещение) ");
                                                                c = ReadOnlyInt(0, 1000);
                                                                Console.Write("(Количество парусов) ");
                                                                d = ReadOnlyInt(0, 1000);
                                                                Key_Value_Ships.Add(Booler, new Class_Steamboat_Ships(a, b, c, d));
                                                                Console.WriteLine();
                                                                GreenText("Корабль создан.\n\nДля продолжения нажмите любую кнопку...");
                                                            }
                                                            else
                                                            {
                                                                GreenText("Корабль не создан - такой ключ уже существует.\n\nДля продолжения нажмите любую кнопку...");
                                                            }
                                                            Console.ReadKey();
                                                            Console.Clear();
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            Console.Clear();
                                                            GreenText("Добавление элемента");
                                                            Console.WriteLine();
                                                            Console.WriteLine();
                                                            string a;
                                                            int b, c, d, e, Buf;
                                                            Console.Write("(Ключ) ");
                                                            Buf = ReadOnlyInt(0, 100000);
                                                            if (Key_Value_Ships.GetByIndex(Buf) == null)
                                                            {
                                                                Console.Write("(Имя) Введите значение: ");
                                                                a = Console.ReadLine();
                                                                Console.Write("(Скорость) ");
                                                                b = ReadOnlyInt(0, 1000);
                                                                Console.Write("(Водоизмещение) ");
                                                                c = ReadOnlyInt(0, 1000);
                                                                Console.Write("(Количество парусов) ");
                                                                d = ReadOnlyInt(0, 1000);
                                                                Console.Write("(Количество огнестрельных орудий) ");
                                                                e = ReadOnlyInt(0, 1000);
                                                                Key_Value_Ships.Add(Buf, new Class_Corvette_Ships(a, b, c, d, e));
                                                                Console.WriteLine();
                                                                GreenText("Корабль создан.\n\nДля продолжения нажмите любую кнопку...");
                                                            }
                                                            else
                                                            {
                                                                GreenText("Корабль не создан - такой ключ уже существует.\n\nДля продолжения нажмите любую кнопку...");
                                                            }
                                                            Console.ReadKey();
                                                            Console.Clear();
                                                            break;
                                                        }
                                                    case 0: break;
                                                }
                                            } while (Choise_Add_Ships != 0);
                                            Console.Clear();
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            GreenText("3 Задание 11 Лабораторной");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            int Deleter = ReadOnlyInt(0, 1000);
                                            if (Key_Value_Ships.ContainsKey(Deleter) == false)////////////////////////////
                                            {
                                                Console.WriteLine("Элемет не найден");
                                                Console.WriteLine();
                                            }
                                            else
                                            {
                                                Key_Value_Ships.RemoveAtKey(Deleter);
                                                Console.WriteLine("Элемет удалён");
                                                Console.WriteLine();
                                            }
                                            Console.WriteLine();
                                            GreenText("Для продолжения нажмите любую кнопку...");

                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            GreenText("3 Задание 11 Лабораторной");
                                            var enumerator = Key_Value_Ships.GetEnumerator();
                                            while(enumerator.MoveNext())
                                            {
                                                if(enumerator.Current is Class_Sailboat_Ships)
                                                {
                                                    Class_Sailboat_Ships SailBoat = new Class_Sailboat_Ships();
                                                    SailBoat = (Class_Sailboat_Ships)enumerator.Current;
                                                    SailBoat.Show();
                                                }
                                                if(enumerator.Current is Class_Corvette_Ships)
                                                {
                                                    Class_Corvette_Ships Corvette = new Class_Corvette_Ships();
                                                    Corvette = (Class_Corvette_Ships)enumerator.Current;
                                                    Corvette.Show();
                                                }
                                                if(enumerator.Current is Class_Steamboat_Ships)
                                                {
                                                    Class_Steamboat_Ships SteamBoat = new Class_Steamboat_Ships();
                                                    SteamBoat = (Class_Steamboat_Ships)enumerator.Current;
                                                    SteamBoat.Show();
                                                }
                                            }
                                            //
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            GreenText("Для продолжения нажмите любую кнопку...");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.Clear();
                                            GreenText("3 Задание 11 Лабораторной");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            MySortedDictionary<int, Class_Ships> Clone = Key_Value_Ships.Clone();
                                            Console.WriteLine("Клон создан, удаляем в основном массиве 1 элемент, если он есть, и выводим оба массива");
                                            Console.WriteLine();
                                            if (Key_Value_Ships.GetByIndex(0) != null)
                                            {
                                                Key_Value_Ships.RemoveAt(0);
                                                Console.WriteLine("Элемет удалён");
                                                Console.WriteLine();
                                                Console.Write("Основной ");
                                                Key_Value_Ships.Show();
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                Console.Write("Клон ");
                                                Clone.Show();
                                            }
                                            else
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Элемет не найден");
                                                Console.WriteLine();
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            GreenText("Для продолжения нажмите любую кнопку...");

                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    case 0: break;
                                }
                            } while (Choise_3 != 0);

                            Console.Clear();
                            break;
                        }
                    case 0: break;

                }
            } while (Choise_0 != 0);
        }
    }
}
