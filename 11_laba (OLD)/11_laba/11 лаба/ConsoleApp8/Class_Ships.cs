using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    /// <summary>
    /// Класс "Корабли"
    /// </summary>
    public abstract class Class_Ships
    {
        protected string name;
        protected int speed;
        protected int displacement;

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public int Speed
        {
            set
            {
                if (value < 0)
                {
                    speed = 0;
                }
                else
                {
                    speed = value;
                }
            }
            get { return speed; }
        }

        public int Displacement
        {
            set
            {
                if (value < 0)
                {
                    displacement = 0;
                }
                else
                {
                    displacement = value;
                }
            }
            get { return displacement; }
        }

        public Class_Ships()
        {
            Name = "Пустой";
            Speed = 0;
            Displacement = 0;
        }

        public Class_Ships(string Name, int Speed, int Displacement)
        {
            this.Name = Name;
            this.Speed = Speed;
            this.Displacement = Displacement;
        }

        public abstract void Show();

        public override bool Equals(Object obj)
        {
            return Equals((Class_Ships)obj);
        }
        

        public override int GetHashCode()
        {
            return 0;
        }
    }
    /// <summary>
    /// Класс "Парусник", созданный от класса "Корабли"
    /// </summary>
    public class Class_Sailboat_Ships : Class_Ships
    {
        protected int velum_number;
        public int Velum_Number
        {
            set
            {
                if (value < 0)
                {
                    velum_number = 0;
                }
                else
                {
                    velum_number = value;
                }
            }
            get { return velum_number; }
        }
        public Class_Sailboat_Ships() : base()
        {
            Velum_Number = 0;
        }
        public Class_Sailboat_Ships(string Name, int Speed, int Displacement, int Velum_Numb) : base(Name, Speed, Displacement)
        {
            Velum_Number = Velum_Numb;
        }
        public override void Show()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("ТИП - ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("ПАРУСНИК");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("a) Название судна: \"" + name + "\"\nб) Cкорость судна: " + speed + " (узлов)\nв) Водоизмещение судна: " + displacement + " (тонн)");
            Console.WriteLine("г) Количество парусов на судне: " + velum_number + " (шт)");
            Console.WriteLine();
        }

    }
    /// <summary>
    /// Класс "Корвет", созданный от класса "Парусник"
    /// </summary>
    public class Class_Corvette_Ships : Class_Sailboat_Ships
    {
        int cannon_amount;
        static private int Numbers_Of_Class_Corvette_Ships = 0;
        public int Cannon_Amount
        {
            set
            {
                if (value < 0)
                {
                    cannon_amount = 0;
                }
                else
                {
                    cannon_amount = value;
                }
            }
            get
            {
                return cannon_amount;
            }
        }
        public Class_Corvette_Ships() : base()
        {
            Cannon_Amount = 0;
            Numbers_Of_Class_Corvette_Ships++;

        }
        public Class_Corvette_Ships(string Name, int Speed, int Displacement, int Velum_Numb, int Cannon_Am) : base(Name, Speed, Displacement, Velum_Numb)
        {
            Cannon_Amount = Cannon_Am;
            Numbers_Of_Class_Corvette_Ships++;

        }
        public override void Show()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("ТИП - ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("ПАРУСНИК");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("ПОДТИП - ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("КОРВЕТ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("a) Название судна: \"" + name + "\"\nб) Cкорость судна: " + speed + " (узлов)\nв) Водоизмещение судна: " + displacement + " (тонн)");
            Console.WriteLine("г) Количество парусов на судне: " + velum_number + " (шт)");
            Console.WriteLine("д) Количество огнестрельных орудий на судне: " + cannon_amount + " (шт)");
            Console.WriteLine();
        }
        static public void Numb_Of_Corvette()
        {
            Console.WriteLine("Количествво созданных объектов типа \"Корвет\" за данный сеанс работы программы: " + Numbers_Of_Class_Corvette_Ships);
        }
    }
    /// <summary>
    /// Класс "Пароход", созданный от класса "Корабли"
    /// </summary>
    public class Class_Steamboat_Ships : Class_Ships, ICloneable
    {
        int engine_capacity;
        public int Engine_Capacity
        {
            set
            {
                if (value < 0)
                {
                    engine_capacity = 0;
                }
                else
                {
                    engine_capacity = value;
                }
            }
            get { return engine_capacity; }
        }
        public Class_Steamboat_Ships() : base()
        {
            Engine_Capacity = 0;
        }
        public Class_Steamboat_Ships(string Name, int Speed, int Displacement, int Engine_Cap) : base(Name, Speed, Displacement)
        {
            Engine_Capacity = Engine_Cap;
        }
        public override void Show()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("ТИП - ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("ПАРОХОД");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("a) Название судна: \"" + name + "\"\nб) Cкорость судна: " + speed + " (узлов)\nв) Водоизмещение судна: " + displacement + " (тонн)");
            Console.WriteLine("г) Мощность дивгателя: " + engine_capacity + " (лс)");
            Console.WriteLine();
        }
        public object Clone()
        {
            return new Class_Steamboat_Ships("Клон " + this.name, this.speed, this.displacement, this.engine_capacity);
        }

    }
    public class Class_Ships_Enum : IEnumerator
    {
        public Class_Ships[] _people;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public Class_Ships_Enum(Class_Ships[] list)
        {
            _people = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _people.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Class_Ships Current
        {
            get
            {
                try
                {
                    return _people[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
