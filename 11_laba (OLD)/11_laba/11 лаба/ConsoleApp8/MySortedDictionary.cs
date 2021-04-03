using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public class MySortedDictionary<K, T> : IEnumerable
    {
        private SortedList<K, T> sl;
        private int capacity;
        public MySortedDictionary()
        {
            sl = new SortedList<K, T>();
            capacity = 0;
        }
        public MySortedDictionary(int c)
        {
            sl = new SortedList<K, T>();
            capacity = c;
        }
        public MySortedDictionary(IDictionary<K, T> d)
        {
            sl = new SortedList<K, T>(d);
            capacity = d.Count();
        }
        public IEnumerator GetEnumerator()
        {
            return Values.GetEnumerator();
        }
        public int Capacity
        {
            get { return capacity; }
            set
            {
                if (value < 0) value = 0;
                capacity = value;
            }
        }
        public int Count
        {
            get { return sl.Count; }
        }
        public IList<K> Keys
        {
            get { return sl.Keys; }
        }
        public IList<T> Values
        {
            get { return sl.Values; }
            set { Values = value; }
        }
        public bool ContainsKey(object key)
        {
            return sl.ContainsKey((K)key);
        }
        public bool ContainsValue(object value)
        {

            return sl.ContainsValue((T)value);
        }
        public void Add(K key, T value)
        {
            if (ContainsKey(key) == true)
            {
                Console.WriteLine("Запись с таким именем уже существует", Console.ForegroundColor = ConsoleColor.Red);
                Console.WriteLine();
                Console.ResetColor();
                return;
            }
            sl.Add(key, value);
            if (Count > Capacity)
                Capacity++;
        }

        public void Clear()
        {
            Console.WriteLine("Очищаем словарь");
            sl.Clear();
            Console.WriteLine("Словарь очищен");
            Console.WriteLine();
        }
        public void Remove(object value)
        {
            MySortedDictionary<K, T> ms = new MySortedDictionary<K, T>(sl);
            int index = ms.IndexOfValue(value);
            K key = ms.GetKey(index);
            sl.Remove(key);
        }
        public void RemoveAt(int index)
        {
            sl.RemoveAt(index);
        }
        public void RemoveAtKey(K Key)
        {
            sl.Remove(Key);
        }
        public MySortedDictionary<K, T> Clone()
        {
            Console.WriteLine("Клонируем словарь");
            MySortedDictionary<K, T> clone = new MySortedDictionary<K, T>(sl) { Capacity = Capacity };
            Console.WriteLine("Клонирование завершено");
            Console.WriteLine();
            return clone;
        }
        public T GetByIndex(int index)
        {
            if (index > Count - 1)
            {
                Console.WriteLine("Записи под индексом " + index + " нет в словаре", Console.ForegroundColor = ConsoleColor.Red);
                Console.ResetColor();
                return default(T);
            }
            SortedList s = new SortedList(sl);
            T value = (T)s.GetByIndex(index);
            return value;
        }

        public K GetKey(int index)
        {
            if (index > Count - 1)
            {
                Console.WriteLine("Ключа с таким индексом нет в словаре", Console.ForegroundColor = ConsoleColor.Red);
                Console.ResetColor();
                return default(K);
            }
            SortedList s = new SortedList(sl);
            K key = (K)s.GetKey(index);
            return key;
        }
        public int IndexOfKey(object key)
        {
            return sl.IndexOfKey((K)key);
        }
        public int IndexOfValue(object value)
        {

            return sl.IndexOfValue((T)value);
        }
        public void SetByIndex(int index, object value)
        {
            if (index > Count - 1)
            {
                Console.WriteLine();
                Console.WriteLine("Ключа с таким индексом нет в словаре", Console.ForegroundColor = ConsoleColor.Red);
                Console.ResetColor();
            }
            else
            {
                MySortedDictionary<K, T> ms = new MySortedDictionary<K, T>(sl);
                K key = ms.GetKey(index);
                sl.RemoveAt(index);
                sl.Add(key, (T)value);
            }
        }
        public void Show()
        {
            Console.WriteLine("Словарь:");
            Console.WriteLine();
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine("{0})", GetKey(i));
                if (GetByIndex(i).GetType() == typeof(Class_Corvette_Ships) || GetByIndex(i).GetType() == typeof(Class_Sailboat_Ships) || GetByIndex(i).GetType() == typeof(Class_Steamboat_Ships))
                {
                    object obj = GetByIndex(i);
                    Class_Ships ship = (Class_Ships)obj;
                    ship.Show();
                }
                else
                    GetByIndex(i);
            }

        }
    }
}

