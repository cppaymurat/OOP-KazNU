
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
        public int forfun;
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
    class BITSTRING : STRING, IComparable<BITSTRING>
    {
        public BITSTRING()
        {
            str = "";
            length = new word(0);
        }
        public BITSTRING(string s_)
        {
            if (VerifyString(s_) == 0)
            {
                Console.WriteLine("Введенная строка некорректна!");
                str = "";
                length = new word(0);
            }
            else
            {
                int id = 1;
                int len = 16;
                char sign = '+';
                if (s_[0] == '-') sign = '-';
                else
                {
                    id = 0;
                }
                while (s_[id] == '0' && id < s_.Length) id++;
                s_ = s_.Substring(id);
                len = s_.Length;
                while (len % 4 > 0) len++;
                while (s_.Length < len)
                {
                    s_ = (char)'0' + s_;
                }
                if (sign == '+') s_ = "0," + s_; else s_ = "1," + s_;
                str = s_;
                length = new word(str.Length);
            }
        }
        ~BITSTRING() { str = ""; length = new word(0); }
        protected int VerifyString(string s)
        {
            if (s.Length == 0) return 0;
            if (s[0] != '0' && s[0] != '1' && s[0] != '-') return 0;
            for (int n = 1; n < s.Length; n++)
            {
                if ((s[n] != '0') && (s[n] != '1')) return 0;
            }
            return 1;
        }
        public static bool Equals(object a, object b)
        {
            if (a == b) return true;
            return false;
        }
        public static bool operator >(BITSTRING a, BITSTRING b)
        {
            if (a.CompareTo(b) == 1) return true; return false;
        }
        public static bool operator <(BITSTRING a, BITSTRING b)
        {
            if (a.CompareTo(b) == -1) return true; return false;
        }
        public static bool operator >=(BITSTRING a, BITSTRING b)
        {
            if (a.CompareTo(b) >= 0) return true; return false;
        }
        public static bool operator <=(BITSTRING a, BITSTRING b)
        {
            if (a.CompareTo(b) <= 0) return true; return false;
        }
        public static bool operator ==(BITSTRING a, BITSTRING b)
        {
            if (a.CompareTo(b) == 0) return true; return false;
        }
        public static bool operator !=(BITSTRING a, BITSTRING b)
        {
            if (a.CompareTo(b) != 0) return true; return false;
        }
        public int CompareTo(BITSTRING other)
        {
            return this.str.CompareTo(other.str);
        }
        public static int toDecim(BITSTRING a)
        {
            if (a.getLength() == 0) return 0;
            int ans = 0;
            int id = 0;
            a.changeSign(a);
            for (int i = a.getLength() - 1; i > 1; i--)
            {
                ans += (int)Math.Pow(2, id) * (int)(a.str[i] - '0');
                id++;
            }
            ans *= (int)Math.Pow(-1, (int)(a.str[0] - '0'));
            return ans;
        }
        public static BITSTRING operator +(BITSTRING a, BITSTRING b)
        {
            int aDecim = toDecim(a);
            int bDecim = toDecim(b);
            int c = aDecim + bDecim;
            BITSTRING ans = new BITSTRING(Convert.ToString((int)Math.Abs(c), 2));
            if (c < 0) ans.str = "-" + ans.str;
            ans.changeSign(ans);
            return ans;
        }
        public void changeSign(BITSTRING z)
        {
            if (z.getLength() == 0) return;
            if (z.str[0] == '0') return;
            StringBuilder toChange = new StringBuilder(z.str);
            for (int i = 2; i < toChange.Length; i++)
            {
                toChange[i] = (toChange[i] == '1') ? '0' : '1';
            }
            for (int i = toChange.Length - 1; i >= 0; i--)
            {
                if (toChange[i] == '0')
                {
                    toChange[i]++;
                    break;
                }
                else
                {
                    toChange[i] = '0';
                }
            }
            z.str = Convert.ToString(toChange);
        }
    };
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите битовую строку a: ");
            string s = Console.ReadLine();
            BITSTRING a = new BITSTRING(s);
            Console.WriteLine("Введите битовую строку b: ");
            s = Console.ReadLine();
            BITSTRING b = new BITSTRING(s);
            Console.WriteLine("Прямый код для a: ");
            Console.WriteLine(a.str);
            Console.WriteLine("Прямой код для b: ");
            Console.WriteLine(b.str);
            Console.WriteLine("Дополнительный код для a: ");
            a.changeSign(a);
            Console.WriteLine(a.str);
            Console.WriteLine("Дополнительный код для b: ");
            b.changeSign(b);
            Console.WriteLine(b.str);
            Console.Write("a равно b? ");
            if (a == b)
            {
                Console.Write("Да");
            }
            else
            {
             Console.Write("Нет");
            }
            Console.WriteLine("\nАрифметическая сумма строк = ");
            BITSTRING c = a + b;
            Console.WriteLine(c.str);
            Console.ReadKey();
        }
    }
}
