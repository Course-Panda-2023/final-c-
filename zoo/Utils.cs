namespace zoo;


public static class Utils
{
    public static HashSet<int> GenerateUniqueRandomNumbers(int minValue, int maxValue, int count)
    {
        Random random = new Random();
        HashSet<int> uniqueNumbers = new HashSet<int>();

        while (uniqueNumbers.Count < count)
        {
            int randomNumber = random.Next(minValue, maxValue + 1);
            uniqueNumbers.Add(randomNumber);
        }

        return uniqueNumbers;
    }
}