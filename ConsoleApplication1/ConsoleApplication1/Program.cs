using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class Program
    {
        static void Main(string[] args)
        {

        }
            /*          List<int> list = new List<int>(5);
                        list.Add(12);
                        string s = "Hello";
                        s = s.Insert(1, "E");
                        s = string.Empty;
                        s.ToCharArray();
                        StringBuilder str = new StringBuilder(s,24);
                        str.Append("*");
            */
            /*int number = 1234321;
            var array = number.ToString().ToCharArray();//.OrderBy(c=>c);//получаем строковое представление->массив чаров
            Array.Sort<char>(array);
            string str1 = new string(array);
            int next = number;
            while (true)
            {
                next = next + 1;
                
            }*/
            public static long NextBiggerNumber(long number){
            if (number<0)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }
            if (IsNumberDecrease(number))
            {
                return -1;
            }
            string sNumber = ToSortedString(number);
            long nextNumber = ++number;
            string sNext = ToSortedString(nextNumber);
            while (sNumber != sNext)
            {
                sNext = ToSortedString(++nextNumber);
            }
            return nextNumber;

            }
        private static bool IsNumberDecrease(long number) {
            int prevDigit = (int)number % 10;
            int nextDigit = 0;
            number = number / 10;

            while (number !=0)
            {
                nextDigit = (int)number % 10;
                if (prevDigit > nextDigit)
                {
                    return false;
                }
                number = number/10;
                prevDigit = nextDigit;

            }
            return true;
        }
            private static string ToSortedString(long number)
            {
                char[] array = number.ToString().ToCharArray();
                Array.Sort(array);
                return new String(array);


            }
            

    }
}

