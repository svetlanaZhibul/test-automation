using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//unit тестирование
namespace IntegerLibrary
{
    public class IntegerExtention
    {
        public static bool IsSimpleNumber(int number)
        {
            if (number<=1)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }
            for (int i=2; i<=number/2; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        public static bool IsExpOfTwo(int value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value));
            if (value == 1)
                return true;
            while ((value % 2) == 0)
            {
                if ((value /= 2) == 1)
                    return true;
            }
            return false;

        }

        public static bool IsExpOfInteger(int basis, int value)
        {
            if (basis <= 0)
                throw new ArgumentOutOfRangeException(nameof(basis));
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value));
            if (value == 1)
                return true;
            while ((value % basis) == 0)
            {
                if ((value /= basis) == 1)
                    return true;
            }
            return false;

        }

        public static int Factorial(int n)
        {        
            int factorial = 1;              
            for (int i = 2; i <= n; i++)
            {
                factorial = factorial * i;
            }
            return factorial;
        }
    }
}
