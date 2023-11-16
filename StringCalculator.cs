namespace StringCalculator;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        List<int> numbersList = new List<int>();

        if (int.TryParse(numbers, out int numbersInteger))
        {
            numbersList.Add(numbersInteger);
        }
        else
        {
            numbersList.AddRange(ParseNumbersString(numbers));
        }

        if (numbersList.Any(n => n < 0))
        {
            throw new NegativeNumberException($"Negatives not allowed: {string.Join(",", numbersList.Where(n => n < 0))}");
        }

        return numbersList.Sum();
    }

    private List<int> ParseNumbersString(string numbers)
    {
        if (numbers.StartsWith("//"))
        {
            List<string> numbersLines = numbers.Split(Environment.NewLine).ToList();
            string separator = numbersLines.First().Replace("//", string.Empty);

            return numbersLines.Last().Split(separator).Select(x => int.Parse(x)).ToList();
        }
        else
        {
            numbers = numbers.Replace(Environment.NewLine, ",");

            List<string> numbersList = numbers.Split(",").ToList();

            return numbersList.Select(n => int.Parse(n)).ToList();
        }
    }
}

public class NegativeNumberException : Exception
{
    public NegativeNumberException(string message) : base(message)
    {
    }
}