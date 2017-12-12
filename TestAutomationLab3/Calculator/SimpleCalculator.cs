using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class SimpleCalculator
    {
        public static string ProcessInput(string input)
        {
            Regex pattern = new Regex(@"^(\s*-?\d+\.?\d*\s*[\+\-\*\/]\s*-?\s*\d+\.?\d*\s*)$");
            Regex negative2ndOperandPattern = new Regex(@"\s*-?\d+\.?\d*\s*[\+\-\*\/]\s*-\s*\d+\.?\d*\s*");

            Regex numberPattern = new Regex(@"\s*-?\s*[0-9]+\.?\d*");
            Regex floatingNumberPattern = new Regex(@"\s*-?\s*[0-9]+\.\d+");

            Regex signPattern = new Regex(@"[\+\-\*\/]");
            
            if (!pattern.IsMatch(input))
            {
                return "Wrong kind of input. Please, try again.";
            }
            else
            {
                double[] numbers = new double[2];
                MatchCollection operands = numberPattern.Matches(input);

                for (int i = 0; i < operands.Count; i++)
                {
                    if (!floatingNumberPattern.IsMatch(operands[i].Value))
                    {
                        numbers[i] = Double.Parse(operands[i].Value.Replace(" ", "").Replace(".", ""), NumberStyles.Any, CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        numbers[i] = Double.Parse(operands[i].Value.Replace(" ", ""), NumberStyles.Any, CultureInfo.InvariantCulture);
                    }
                }

                string sign;
                Match operation;

                if (negative2ndOperandPattern.IsMatch(input))
                {
                    Console.WriteLine("2nd operand negative");
                    Regex negativeOperandPattern = new Regex(@"\d+\.?\d*\s*[\+\-\*\/]\s*-");
                    sign = negativeOperandPattern.Match(input).Value;
                    operation = signPattern.Match(sign);
                }
                else
                {
                    Console.WriteLine("2nd operand positive");
                    Regex positiveOperandPattern = new Regex(@"\d+\.?\d*\s*[\+\-\*\/]\s*\d+");
                    sign = positiveOperandPattern.Match(input).Value;
                    operation = signPattern.Match(sign);

                    if (operation.Value.Equals("-"))
                    {
                        numbers[1] = -numbers[1];
                    }
                }

                return Calculate(operation.Value, numbers);
    
            }
        }

        public static string Calculate(string operation, params double[] operands)
        {
            if (operands.Length == 2)
            {
                double res;
                switch (operation)
                {
                    case "+":
                        res = Sum(operands[0], operands[1]);
                        break;
                    case "-":
                        res = Subtract(operands[0], operands[1]);
                        break;
                    case "*":
                        res = Multiply(operands[0], operands[1]);
                        break;
                    case "/":
                        res = Divide(operands[0], operands[1]);
                        break;
                    default:
                        res = 0;
                        //Console.WriteLine("Operation not found. Please, try again."+operation.Value+"!");
                        break;
                }
                return res.ToString();
            }
            else
            {
                return "Wrong kind of input. Please, try again.";
            }
        }

        private static double Sum(double a, double b)
        {
            return a + b;
        }

        private static double Subtract(double a, double b)
        {
            return a - b;
        }

        private static double Multiply(double a, double b)
        {
            return a * b;
        }

        private static double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new ArgumentException(nameof(b));
            }
            return (a / b); 
        }
    }
}
