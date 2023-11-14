using NUnit.Framework;

namespace StringCalculator
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void When_String_Is_EMpty_Return_Zero()
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

        [Test]
        public void When_String_COntains_Two_Numbers_Return_The_Sum()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("1,1");
            Assert.That(result, Is.EqualTo(2));

        }
    }

    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            if (numbers.IndexOf(",") > -1)
            {
                int number1 = int.Parse(numbers.Substring(0, 1));
                int number2 = int.Parse(numbers.Substring(2, 1));

                return number1 + number2;
            }
            else
            {
                return int.Parse(numbers);
            }
        }
    }
}
