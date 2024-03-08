namespace Adder.Tests;

public class NumberAdderConsoleTests
{
    [Fact]
    public void AddingValidNumbers_ShouldPrintSums()
    {
        // Arrange
        var nac = new NumberAdderConsoleMock(["5", "6", "q"]);

        // Act
        var result = nac.AggregatedEnteredNumbers();

        // Assert
        Assert.Equal(11, result);
        Assert.Equal([
                "Enter numbers, 'q' to quit.", 
                "The current sum is 5", 
                "The current sum is 11"
            ], nac.Outputs);
    }

    [Fact]
    public void AddingWithInvalidNumber_ShouldPrintError()
    {
        // Arrange
        var nac = new NumberAdderConsoleMock(["5", "invalid", "q"]);

        // Act
        var result = nac.AggregatedEnteredNumbers();

        // Assert
        Assert.Equal(5, result);
        Assert.Equal([
                "Enter numbers, 'q' to quit.", 
                "The current sum is 5", 
                "The number you entered is not valid."
            ], nac.Outputs);
    }

    [Fact]
    public void AddingWithOverflow_ShouldPrintError()
    {
        // Arrange
        var nac = new NumberAdderConsoleMock([int.MaxValue.ToString(), "1", "q"]);

        // Act
        var result = nac.AggregatedEnteredNumbers();

        // Assert
        Assert.Equal(int.MaxValue, result);
        Assert.Equal([
                "Enter numbers, 'q' to quit.", 
                $"The current sum is {int.MaxValue}", 
                "The number you entered is too large."
            ], nac.Outputs);
    }
}