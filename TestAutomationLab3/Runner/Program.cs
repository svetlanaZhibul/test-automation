using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Calculator.SimpleCalculator;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            bool stop = true;

            Console.WriteLine("Enter expression to evaluate or end to exit.");
            while (stop)
            {
                string expression = Console.ReadLine();
                if (expression.Equals("end"))
                    stop = false;
                else
                    Console.WriteLine(ProcessInput(expression));
            }
            Console.WriteLine("Well done! Bye");

            Console.ReadKey();
        }
    }
}
