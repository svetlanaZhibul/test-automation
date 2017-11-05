using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Calculator.SimpleCalculator;


namespace NUnit.Calculator.Tests
{
    [TestFixture]
    public class NUnitSimpleCalculator
    {
        [TestCase("-5 + - 5", ExpectedResult = "-10")]
        [TestCase(" 5 + - 5", ExpectedResult = "0")]
        [TestCase(" 10 + 1.5", ExpectedResult = "11,5")]
        [TestCase(" 5.5 + 2.5", ExpectedResult = "8")]

        [TestCase(" -6 -- 6", ExpectedResult = "0")]
        [TestCase(" -6 - 6", ExpectedResult = "-12")]
        [TestCase("5 - 4.5", ExpectedResult = "0,5")]
        [TestCase("1.6 - 3.5", ExpectedResult = "-1,9")]

        [TestCase(" 10 / -10", ExpectedResult = "-1")]
        [TestCase("-15 / 4", ExpectedResult = "-3,75")]
        [TestCase("-15 / - 3", ExpectedResult = "5")]
        [TestCase(" 3 / 2 ", ExpectedResult = "1,5")]

        [TestCase("-5.0 * - 5", ExpectedResult = "25")]
        [TestCase("5.5 *  - 2", ExpectedResult = "-11")]
        [TestCase("2.3 * 4.1 ", ExpectedResult = "9,43")]
        [TestCase("-17 * 1.23 ", ExpectedResult = "-20,91")]

        [TestCase("5 - ww", ExpectedResult = "Wrong kind of input. Please, try again.")]
        [TestCase("2.3 * 4.1 + 9 ", ExpectedResult = "Wrong kind of input. Please, try again.")]
        [TestCase("2.3 - 4  9 ", ExpectedResult = "Wrong kind of input. Please, try again.")]
        [TestCase("1 _  9 ", ExpectedResult = "Wrong kind of input. Please, try again.")]
        public string TestCalculatorInputAndOutput
            (string expression)
        {
            return ProcessInput(expression);
        }

        [TestCase("-1 / -0")]
        [TestCase(" 2.3 / 0")]
        [TestCase(" -11 / 0")]
        [TestCase("0. / 0")]
        public void TestDivisionOperationException(string expression)
        {
            Assert.That(() => ProcessInput(expression), Throws.TypeOf<ArgumentException>());
        }

    }
}
