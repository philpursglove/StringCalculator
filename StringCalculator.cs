namespace StringCalculator;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        numbers = numbers.Replace(Environment.NewLine, ",");

        if (numbers.IndexOf(",", StringComparison.InvariantCulture) > -1)
        {
            List<string> numbersList = numbers.Split(",").ToList();

            return numbersList.Select(n => int.Parse(n)).Sum();
        }
        else
        {
            return int.Parse(numbers);
        }
    }
}