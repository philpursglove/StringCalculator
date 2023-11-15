namespace StringCalculator;

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
            List<string> numbersList = numbers.Split(",").ToList();

            return numbersList.Select(n => int.Parse(n)).Sum();
        }
        else
        {
            return int.Parse(numbers);
        }
    }
}