using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;

namespace NextBiggerNumber.Tests
{
    [TestClass]
    public class NextBiggerNumberTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMethod1()
        {
            long number = -20;
            long actual = Program.NextBiggerNumber(number);
        }
    }
}
