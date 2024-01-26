List<long> numbers = GenerateNumbers(1, 100);
Console.WriteLine(CalculateSum(numbers));
InsertSumAfterPairs(ref numbers);
Console.WriteLine(CalculateSum(numbers));
RemoveEvenNumbers(ref numbers);
Console.WriteLine(CalculateSum(numbers));
ReplaceWithRunningTotal(ref numbers);
Console.WriteLine(CalculateSum(numbers));
long result = CalculateResult(numbers);
Console.WriteLine($"Result: {result}");

// Generate a list of numbers between 1 and 100
static List<long> GenerateNumbers(long start, long end)
{
    List<long> numbers = [];
    for (long i = start; i <= end; i++)
    {
        numbers.Add(i);
    }

    return numbers;
}

// Behind each pair of numbers (i.e. after 1 and 2, after 3 and 4, etc.), insert the sum of the number pair.
static void InsertSumAfterPairs(ref List<long> numbers)
{
    for (int i = 1; i < numbers.Count; i += 2)
    {
        numbers.Insert(i + 1, numbers[i] + numbers[i - 1]);
    }
}

// Remove all even numbers from the list
static void RemoveEvenNumbers(ref List<long> numbers)
{
    for (int i = numbers.Count - 1; i >= 0; i--)
    {
        if (numbers[i] % 2 == 0)
        {
            numbers.RemoveAt(i);
        }
    }
}

// Exchange each number with the running total up until the number.
static void ReplaceWithRunningTotal(ref List<long> numbers)
{
    long runningTotal = 0;
    for (int i = 0; i < numbers.Count; i++)
    {
        runningTotal += numbers[i];
        numbers[i] = runningTotal;
    }
}

// Calculate the mean (rounded to 0 decimals) and the sum of all numbers. Add these three values. This is your result.
static long CalculateResult(List<long> numbers)
{
    long sum = CalculateSum(numbers);
    double mean = Math.Round(sum / (double)numbers.Count);

    return (long)(mean + sum);
}

static long CalculateSum(List<long> numbers)
{
    long sum = 0;
    foreach (long number in numbers)
    {
        sum += number;
    }

    return sum;
}