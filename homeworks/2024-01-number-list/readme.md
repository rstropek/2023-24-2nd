# List Exercise

## Description

* Generate a list of numbers between 1 and 100
* Behind each pair of numbers (i.e. after 1 and 2, after 3 and 4, etc.), insert the sum of the number pair.
* Remove all even numbers from the list
* Exchange each number with the running total up until the number.
* Calculate the mean (rounded to 0 decimals) and the sum of all numbers. Add these three values. This is your result.

## Part 1 - In-Place List Manipulation

Create a class `InPlace`. It **must** use `List<long>` internally. The class must have the following methods:

```cs
// Generate a list of numbers between 1 and 100
public void GenerateNumbers(long start, long end) { ... }

// Behind each pair of numbers (i.e. after 1 and 2, after 3 and 4, etc.),
// insert the sum of the number pair.
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
public void InsertSumAfterPairs() { ... }

// Remove all even numbers from the list
public void RemoveEvenNumbers() { ... }

// Exchange each number with the running total up until the number.
public void ReplaceWithRunningTotal() { ... }

// Calculate the sum of all numbers.
public long CalculateSum() { ... }

// Calculate the mean (rounded to 0 decimals) and the sum of all numbers. 
// Add these three values. This is your result.
public long CalculateResult() { ... }
```

Execute the methods as follows:

```cs
var inPlace = new InPlace();
inPlace.GenerateNumbers(1, 100);
Console.WriteLine(inPlace.CalculateSum());
inPlace.InsertSumAfterPairs();
Console.WriteLine(inPlace.CalculateSum());
inPlace.RemoveEvenNumbers();
Console.WriteLine(inPlace.CalculateSum());
inPlace.ReplaceWithRunningTotal();
Console.WriteLine(inPlace.CalculateSum());
long result = inPlace.CalculateResult();
Console.WriteLine($"Result: {result}");
```

The output should be:

```text
5050
10100
7550
255050
Result: 257600
```

## Part 2 - Static Implementations

Change your implementation to a static class `NewList`:

```cs
static class NewList
{
    // Generate a list of numbers between start and end
    public static List<long> GenerateNumbers(long start, long end) { ... }

    // Behind each pair of numbers, insert the sum of the number pair.
    public static List<long> InsertSumAfterPairs(List<long> numbers) { ... }

    // Remove all even numbers from the list
    public static List<long> RemoveEvenNumbers(List<long> numbers) { ... }

    // Exchange each number with the running total up until the number.
    public static List<long> ReplaceWithRunningTotal(List<long> numbers) { ... }

    // Calculate the sum of all numbers.
    public static long CalculateSum(List<long> numbers) { ... }

    // Calculate the mean (rounded to 0 decimals) and the sum of all numbers.
    public static long CalculateResult(List<long> numbers) { ... }
}
```

Execute the methods as follows:

```cs
var list = NewList.GenerateNumbers(1, 100);
Console.WriteLine(NewList.CalculateSum(list));
list = NewList.InsertSumAfterPairs(list);
Console.WriteLine(NewList.CalculateSum(list));
list = NewList.RemoveEvenNumbers(list);
Console.WriteLine(NewList.CalculateSum(list));
list = NewList.ReplaceWithRunningTotal(list);
Console.WriteLine(NewList.CalculateSum(list));
result = NewList.CalculateResult(list);
Console.WriteLine($"Result: {result}");
```

The output is the same as before.
