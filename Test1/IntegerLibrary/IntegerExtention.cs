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
    }
}
