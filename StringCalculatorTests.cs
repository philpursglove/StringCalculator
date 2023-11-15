using NUnit.Framework;

namespace StringCalculator
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void When_String_Is_Empty_Return_Zero()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("");
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void When_String_Contains_One_Number_Return_The_Number()
        {

            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("1");
            Assert.That(result, Is.EqualTo(1));
        }

        [TestCase(1,1,2)]
        [TestCase(10,10,20)]
        public void When_String_Contains_Two_Numbers_Return_The_Sum(int number1, int number2, int expectedResult)
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add($"{number1},{number2}");
            Assert.That(result, Is.EqualTo(expectedResult));

        }
    }
}
