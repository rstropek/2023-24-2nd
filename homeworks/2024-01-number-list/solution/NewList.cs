static class NewList
{
    // Generate a list of numbers between start and end
    public static List<long> GenerateNumbers(long start, long end)
    {
        var numbers = new List<long>();
        for (long i = start; i <= end; i++)
        {
            numbers.Add(i);
        }
        return numbers;
    }

    // Behind each pair of numbers, insert the sum of the number pair.
    public static List<long> InsertSumAfterPairs(List<long> numbers)
    {
        var newNumbers = new List<long>();
        for (int i = 0; i < numbers.Count; i++)
        {
            newNumbers.Add(numbers[i]);
            if (i % 2 == 1)
            {
                newNumbers.Add(numbers[i] + numbers[i - 1]);
            }
        }
        return newNumbers;
    }

    // Remove all even numbers from the list
    public static List<long> RemoveEvenNumbers(List<long> numbers)
    {
        var newNumbers = new List<long>();
        foreach (var number in numbers)
        {
            if (number % 2 != 0)
            {
                newNumbers.Add(number);
            }
        }
        return newNumbers;
    }

    // Exchange each number with the running total up until the number.
    public static List<long> ReplaceWithRunningTotal(List<long> numbers)
    {
        var newNumbers = new List<long>();
        long runningTotal = 0;
        foreach (var number in numbers)
        {
            runningTotal += number;
            newNumbers.Add(runningTotal);
        }
        return newNumbers;
    }

    // Calculate the sum of all numbers.
    public static long CalculateSum(List<long> numbers)
    {
        long sum = 0;
        foreach (var number in numbers)
        {
            sum += number;
        }
        return sum;
    }

    // Calculate the mean (rounded to 0 decimals) and the sum of all numbers.
    public static long CalculateResult(List<long> numbers)
    {
        long sum = CalculateSum(numbers);
        double mean = Math.Round(sum / (double)numbers.Count);

        return (long)(mean + sum);
    }
}
