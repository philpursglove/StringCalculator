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
    }

    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            return int.Parse(numbers);
        }
    }
}
