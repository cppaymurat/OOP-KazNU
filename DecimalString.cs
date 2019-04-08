
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp6
{
    struct word : IComparable<word>
    {
        public int value;
        public word(int d)
        {
            this.value = (int)d;
        }
        public int getVal()
        {
            return value;
        }
        public int CompareTo(word other)
        {
            if (this.value > other.value) return 1;
            if (this.value < other.value) return -1;
            return 0;
        }
        public static bool operator >(word a, word b)
        {
            if (a.CompareTo(b) == 1) return true;
            if (a.CompareTo(b) == -1) return false;
            return false;
        }
        public static bool operator <(word a, word b)
        {
            if (a.CompareTo(b) == -1) return true;
            if (a.CompareTo(b) == 1) return false;
            return false;
        }
        public static bool operator ==(word a, word b)
        {
            if (a.CompareTo(b) == 0) return true;
            return false;
        }
        public static bool operator !=(word a, word b)
        {
            if (a.CompareTo(b) == 1) return true;
            return false;
        }
        public static bool operator >=(word a, word b)
        {
            if (a.CompareTo(b) > -1) return true; return false;
        }
        public static bool operator <=(word a, word b)
        {
            if (a.CompareTo(b) < 1) return true; return false;
        }
    }
    class STRING : IComparable<STRING>
    {
        public word length;
        public string str;
        // конструктор без параметров
        public STRING()
        {
        }

        // конструктор, принимающий в качестве параметра строковый литерал
        public STRING(string str)
        {
            this.str = str;
            length = new word(str.Length);
        }

        // конструктор, принимающий в качестве параметра символ;
        public STRING(char ch)
        {
            str = Convert.ToString(ch);
            length = new word(1);
        }

        // Метод возвращающий длинну строки.
        public int getLength()
        {
            return length.getVal();
        }

        // Метод очищающий строку.
        public void Clear()
        {
            str = "";
            length = new word(0);
        }
        public int CompareTo(STRING other)
        {
            if (this.getLength() > other.getLength()) return 1;
            if (this.getLength() < other.getLength()) return -1;
            for (int i = 0; i < this.getLength(); i++)
            {
                if (this.str[i] < other.str[i]) return -1;
                else
                    if (this.str[i] > other.str[i]) return 1;
            }
            return 0;
        }
        public static bool operator >(STRING a, STRING b)
        {
            if (a.CompareTo(b) == 1) return true; return false;
        }
        public static bool operator <(STRING a, STRING b)
        {
            if (a.CompareTo(b) == -1) return true; return false;
        }
        public static bool operator >=(STRING a, STRING b)
        {
            if (a.CompareTo(b) >= 0) return true; return false;
        }
        public static bool operator <=(STRING a, STRING b)
        {
            if (a.CompareTo(b) <= 0) return true; return false;
        }
        public static bool operator ==(STRING a, STRING b)
        {
            if (a.CompareTo(b) == 0) return true; return false;
        }
        public static bool operator !=(STRING a, STRING b)
        {
            if (a.CompareTo(b) != 0) return true; return false;
        }
    }
    class Decimal : STRING, IComparable<Decimal>
    {
        public Decimal(int number)
        {
            str = Convert.ToString(number);
        }
        public int CompareTo(Decimal other)
        {
            int firstNum, secondNum;
            if (this.str[0] == '+')
            {
                firstNum = Convert.ToInt32(this.str.Substring(1));
            }
            else
            {
                firstNum = Convert.ToInt32(this.str);
            }
            if (other.str[0] == '0')
            {
                secondNum = Convert.ToInt32(other.str.Substring(1));
            }
            else
            {
                secondNum = Convert.ToInt32(other.str);
            }
            if (firstNum > secondNum) return 1;
            if (firstNum < secondNum) return -1;
            return 0;
        }
        public static bool operator >(Decimal a, Decimal b)
        {
            if (a.CompareTo(b) == 1) return true; return false;
        }
        public static bool operator <(Decimal a, Decimal b)
        {
            if (a.CompareTo(b) == -1) return true; return false;
        }
        public static bool operator >=(Decimal a, Decimal b)
        {
            if (a.CompareTo(b) >= 0) return true; return false;
        }
        public static bool operator <=(Decimal a, Decimal b)
        {
            if (a.CompareTo(b) <= 0) return true; return false;
        }
        public static bool operator ==(Decimal a, Decimal b)
        {
            if (a.CompareTo(b) == 0) return true; return false;
        }
        public static bool operator !=(Decimal a, Decimal b)
        {
            if (a.CompareTo(b) != 0) return true; return false;
        }

        public static Decimal operator -(Decimal a, Decimal b)
        {
            int firstNum, secondNum;
            if (a.str[0] == '+')
            {
                firstNum = Convert.ToInt32(a.str.Substring(1));
            }
            else
            {
                firstNum = Convert.ToInt32(a.str);
            }
            if (b.str[0] == '0')
            {
                secondNum = Convert.ToInt32(b.str.Substring(1));
            }
            else
            {
                secondNum = Convert.ToInt32(b.str);
            }
            int substraction = firstNum - secondNum;
            Decimal answer = new Decimal(substraction);
            return answer;
        }
        public static bool Equals(object a, object b)
        {
            if (a == b) return true; return false;
        }
        public static bool operator <(Decimal a, int b)
        {
            int firstNum;
            if (a.str[0] == '+')
            {
                firstNum = Convert.ToInt32(a.str.Substring(1));
            }
            else
            {
                firstNum = Convert.ToInt32(a.str);
            }
            int substraction = firstNum - b;
            if (substraction < 0) return true;
            return false;
        }
        public static bool operator >(Decimal a, int b)
        {
            int firstNum;
            if (a.str[0] == '+')
            {
                firstNum = Convert.ToInt32(a.str.Substring(1));
            }
            else
            {
                firstNum = Convert.ToInt32(a.str);
            }
            int substraction = firstNum - b;
            if (substraction > 0) return true;
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите a = ");
            int a = Convert.ToInt32(Console.ReadLine());
            Decimal first = new Decimal(a);
            Console.Write("Введите b = ");
            int b = Convert.ToInt32(Console.ReadLine());
            Decimal second = new Decimal(b);
            Console.Write("Арифметическая разность строк = ");
            Decimal c = first - second;
            Console.WriteLine(c.str);
            Console.Write("a > b? ");
            if (first > second) Console.Write("Да"); else Console.Write("Нет");
            Console.Write("\na < b? ");
            if (first < second) Console.Write("Да"); else Console.Write("Нет");
            Console.ReadKey();
        }
    }
}
