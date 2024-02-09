using Roulette.Logic;

namespace Roulette.Tests;

public class PossibleNumbersTests
{
    [Fact]
    public void SingleNumbersTest()
    {
        var pb = new PossibleNumbers();
        AreEqual([
                [0], [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12], 
                [13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], 
                [24], [25], [26], [27], [28], [29], [30], [31], [32], [33], [34], [35], [36]
            ], pb.SingleNumbers.Select(n => new HashSet<int> { n }).ToList());
    }

    [Fact]
    public void BlackNumbersTest()
    {
        var pb = new PossibleNumbers();
        AreEqual([
                [1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36], 
                [2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35]
            ], pb.RedBlack);
    }

    [Fact]
    public void EvenOddTest()
    {
        var pb = new PossibleNumbers();
        AreEqual([
                [2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36],
                [1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35]
            ], pb.EvenOdd);
    }

    [Fact]
    public void HighLowTest()
    {
        var pb = new PossibleNumbers();
        AreEqual([
                [19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36],
                [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
            ], pb.HighLow);
    }

    [Fact]
    public void DozensTest()
    {
        var pb = new PossibleNumbers();
        AreEqual([
                [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12],
                [13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24],
                [25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36]
            ], pb.Dozens);
    }

    [Fact]
    public void RowTest()
    {
        var pb = new PossibleNumbers();
        AreEqual([
                [1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34],
                [2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35],
                [3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36]
            ], pb.Rows);
    }

    [Fact]
    public void StreetsTest()
    {
        var pb = new PossibleNumbers();
        AreEqual([
                [1, 2, 3], [4, 5, 6], [7, 8, 9], [10, 11, 12], [13, 14, 15], 
                [16, 17, 18], [19, 20, 21], [22, 23, 24], [25, 26, 27], 
                [28, 29, 30], [31, 32, 33], [34, 35, 36]
            ], pb.Streets);
    }

    [Fact]
    public void SplitsTest()
    {
        var pb = new PossibleNumbers();
        AreEqual([
                [1, 2], [2, 3], [4, 5], [5, 6], [7, 8], [8, 9], [10, 11], [11, 12], [13, 14], [14, 15], [16, 17], [17, 18],
                [19, 20], [20, 21], [22, 23], [23, 24], [25, 26], [26, 27], [28, 29], [29, 30], [31, 32], [32, 33], [34, 35], [35, 36],
                [1, 4], [4, 7], [7, 10], [10, 13], [13, 16], [16, 19], [19, 22], [22, 25], [25, 28], [28, 31], [31, 34],
                [2, 5], [5, 8], [8, 11], [11, 14], [14, 17], [17, 20], [20, 23], [23, 26], [26, 29], [29, 32], [32, 35],
                [3, 6], [6, 9], [9, 12], [12, 15], [15, 18], [18, 21], [21, 24], [24, 27], [27, 30], [30, 33], [33, 36]
            ], pb.Splits);
    }

    [Fact]
    public void SquaresTest()
    {
        var pb = new PossibleNumbers();
        AreEqual([
                [1, 2, 4, 5], [2, 3, 5, 6], [4, 5, 7, 8], [5, 6, 8, 9], [7, 8, 10, 11], [8, 9, 11, 12], 
                [10, 11, 13, 14], [11, 12, 14, 15], [13, 14, 16, 17], [14, 15, 17, 18], [16, 17, 19, 20], 
                [17, 18, 20, 21], [19, 20, 22, 23], [20, 21, 23, 24], [22, 23, 25, 26], [23, 24, 26, 27], 
                [25, 26, 28, 29], [26, 27, 29, 30], [28, 29, 31, 32], [29, 30, 32, 33], [31, 32, 34, 35], [32, 33, 35, 36],
                [1, 2, 4, 5], [4, 5, 7, 8], [7, 8, 10, 11], [10, 11, 13, 14], [13, 14, 16, 17], [16, 17, 19, 20], 
                [19, 20, 22, 23], [22, 23, 25, 26], [25, 26, 28, 29], [28, 29, 31, 32],
                [2, 3, 5, 6], [5, 6, 8, 9], [8, 9, 11, 12], [11, 12, 14, 15], [14, 15, 17, 18], [17, 18, 20, 21], 
                [20, 21, 23, 24], [23, 24, 26, 27], [26, 27, 29, 30], [29, 30, 32, 33],
                [3, 6, 9, 12], [6, 9, 12, 15], [9, 12, 15, 18], [12, 15, 18, 21], [15, 18, 21, 24], 
                [18, 21, 24, 27], [21, 24, 27, 30], [24, 27, 30, 33], [27, 30, 33, 36]
            ], pb.Squares);
    }

    [Fact]
    public void SixesTest()
    {
        var pb = new PossibleNumbers();
        AreEqual([
                [1, 2, 3, 4, 5, 6], [4, 5, 6, 7, 8, 9], [7, 8, 9, 10, 11, 12], [10, 11, 12, 13, 14, 15], 
                [13, 14, 15, 16, 17, 18], [16, 17, 18, 19, 20, 21], [19, 20, 21, 22, 23, 24], [22, 23, 24, 25, 26, 27], 
                [25, 26, 27, 28, 29, 30], [28, 29, 30, 31, 32, 33], [31, 32, 33, 34, 35, 36]
            ], pb.SixLines);
    }

    [Fact]
    public void TestAreEqual()
    {
        AreEqual([[1, 2], [3, 4]], [[3, 4], [1, 2]]);
        AreEqual([[1, 2], [3, 4]], [[1, 2], [3, 4]]);
        AreEqual([[1, 2], [3, 5]], [[1, 2], [3, 5]]);
    }


    private static void AreEqual(List<HashSet<int>> a, List<HashSet<int>> b)
    {
        // Return true if all lists in a are in b and vice versa.
        // The order of the lists in the lists doesn't matter.
        // The order of the numbers in the lists doesn't matter.
        // The numbers in the lists must be unique.

        Assert.Equal(a.Count, b.Count);

        foreach (var set in a)
        {
            Assert.Contains(b, l => l.SetEquals(set));
        }

        foreach (var set in b)
        {
            Assert.Contains(a, l => l.SetEquals(set));
        }
    }
}