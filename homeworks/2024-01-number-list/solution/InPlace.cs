class InPlace
{
    private List<long> Numbers { get; set; } = [];


    // Generate a list of numbers between 1 and 100
    public void GenerateNumbers(long start, long end)
    {
        for (long i = start; i <= end; i++)
        {
            Numbers.Add(i);
        }
    }

    // Behind each pair of numbers (i.e. after 1 and 2, after 3 and 4, etc.), insert the sum of the number pair.
    //
    // 1
    // 2
    // <<< insert 3
    // 3
    // 4
    // <<< insert 7
    // 5
    // 6
    // <<< insert 11
    // ...
    public void InsertSumAfterPairs()
    {
        for (int i = 1; i < Numbers.Count; i += 3)
        {
            Numbers.Insert(i + 1, Numbers[i] + Numbers[i - 1]);
        }
    }

    // Remove all even numbers from the list
    public void RemoveEvenNumbers()
    {
        for (int i = Numbers.Count - 1; i >= 0; i--)
        {
            if (Numbers[i] % 2 == 0)
            {
                Numbers.RemoveAt(i);
            }
        }
    }

    // Exchange each number with the running total up until the number.
    public void ReplaceWithRunningTotal()
    {
        long runningTotal = 0;
        for (int i = 0; i < Numbers.Count; i++)
        {
            runningTotal += Numbers[i];
            Numbers[i] = runningTotal;
        }
    }

    // Calculate the sum of all numbers.
    public long CalculateSum()
    {
        long sum = 0;
        foreach (long number in Numbers)
        {
            sum += number;
        }

        return sum;
    }

    // Calculate the mean (rounded to 0 decimals) and the sum of all numbers. Add these three values. This is your result.
    public long CalculateResult()
    {
        long sum = CalculateSum();
        double mean = Math.Round(sum / (double)Numbers.Count);

        return (long)(mean + sum);
    }
}