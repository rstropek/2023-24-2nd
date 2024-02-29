HashSet<int> numbers = [1, 2, 3, 4, 5, 5];
foreach (var n in numbers)
{
    System.Console.WriteLine(n);
}

if (numbers.Contains(3))
{
    System.Console.WriteLine("yes");
}

HashSet<int> otherNumbers = [1, 2, 3, 4, 5];
if (numbers.SetEquals(otherNumbers))
{
    System.Console.WriteLine("Equal");
}

//System.Console.WriteLine("8".GetHashCode());