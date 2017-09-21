﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntegerLibrary; //(1)
using static IntegerLibrary.IntegerExtention; //only start with C# 6.0

namespace IntegerLibrary.Tests
{
    [TestClass]
    public class IntegerLibraryTests
    {
        [TestMethod]//атрибуты
        public void IsSimpleNumber_11_isSimple_true()
        {
            //Arrange
            int number = 11;
            bool expected = true;
            //Act
            //IntegerExtention.IsSimpleNumber(number); (1)
            bool actual = IsSimpleNumber(number);
            //Assert
            Assert.AreEqual(expected, actual);


        }

        [TestMethod]//атрибуты
        public void IsSimpleNumber_30_isSimple_false()
        {
            //Arrange
            int number = 30;
            bool expected = false;
            //Act
            //IntegerExtention.IsSimpleNumber(number); (1)
            bool actual = IsSimpleNumber(number);
            //Assert
            Assert.AreEqual(expected, actual);


        }
        [TestMethod]
        public void IsFactorial_4_is_24_true()
        {
            //Arrange
            int number = 4;
            bool expected = true;
            //Act
            bool actual = (IntegerExtention.Factorial(number) == 24);
            //Assert
            Assert.AreEqual(expected, actual);


        }

        [TestMethod]//атрибуты
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IsSimpleNumber_Minus30_isSimple_Throw_OutOfRangeExeption()
        {
            int number = -30;
            bool actual = IsSimpleNumber(number);

        }

        [TestMethod]//атрибуты
        public void IsExpOfTwo_234_isNotExp_false()
        {
            //Arrange
            int value = 234;
            bool expected = false;
            //Act
            bool actual = IsExpOfTwo(value);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]//атрибуты
        public void IsExpOfTwo_128_isExp_true()
        {
            //Arrange
            int value = 128;
            bool expected = true;
            //Act
            bool actual = IsExpOfTwo(value);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
