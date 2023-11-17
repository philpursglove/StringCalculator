using NUnit.Framework;

namespace StringCalculator
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private StringCalculator _calculator;
        private int _result;

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

        [Test]
        public void When_We_Have_A_Newline_As_A_Separator_We_Dont_Break()
        {
            _result = _calculator.Add($"1,2{Environment.NewLine}3");
            Assert.That(_result, Is.EqualTo(6));
        }

        [TestCase("//;\r\n1;2;3")]
        [TestCase("///\r\n1/2/3")]
        [TestCase("//.\r\n1.2.3")]
        public void Allow_Custom_Separators(string numbersWithCustomSeparator)
        {
            _result = _calculator.Add(numbersWithCustomSeparator);
            Assert.That(_result, Is.EqualTo(6));

        }

        [Test]
        public void Throw_An_Exception_When_One_Or_More_Negative_Numbers_Are_Passed()
        {
            var exception = Assert.Throws<NegativeNumberException>(() => _calculator.Add("-1,-2"));
            Assert.That(exception.Message, Is.EqualTo("Negatives not allowed: -1,-2"));
        }

        [Test]
        public void Ignore_Numbers_Greater_Than_1000()
        {
            _result = _calculator.Add("1,1001,2,2002,3,3003");
            Assert.That(_result, Is.EqualTo(6));
        }
    }
}
