﻿using NUnit.Framework;

namespace StringCalculator
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private StringCalculator _calculator;
        private int _result = 0;

        [SetUp]
        public void Setup()
        {
            _calculator = new StringCalculator();
        }

        [Test]
        public void When_String_Is_Empty_Return_Zero()
        {
            _result = _calculator.Add("");
            Assert.That(_result, Is.EqualTo(0));
        }

        [Test]
        public void When_String_Contains_One_Number_Return_The_Number()
        {
            _result = _calculator.Add("1");
            Assert.That(_result, Is.EqualTo(1));
        }

        [TestCase(1,1,2)]
        [TestCase(10,10,20)]
        public void When_String_Contains_Two_Numbers_Return_The_Sum(int number1, int number2, int expectedResult)
        {
            _result = _calculator.Add($"{number1},{number2}");
            Assert.That(_result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void When_We_Have_An_Arbitrary_Number_Of_Numbers_We_Return_The_Sum()
        {
            _result = _calculator.Add("1,2,3,4,5,6,7,8,9");
            Assert.That(_result, Is.EqualTo(45));
        }
    }
}
